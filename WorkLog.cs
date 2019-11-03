using System;
using System.Data.Odbc;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;

namespace KlpToJekyll
{
    /// <summary>
    /// Loads information from the KitLog MsAccess database so that it can be provided to the renderer.
    /// </summary>
    public class WorkLog
    {
        public string shortDescription { get; private set; }
        public string comments { get; private set; }
        public string image1Caption { get; private set; }
        public string image1FileName { get; private set; }
        public System.Drawing.Image image1 { get; private set; }
        public string image2Caption { get; private set; }
        public string image2FileName { get; private set; }
        public System.Drawing.Image image2 { get; private set; }
        public string image3Caption { get; private set; }
        public string image3FileName { get; private set; }
        public System.Drawing.Image image3 { get; private set; }
        public DateTime dateOfWork { get; private set; }
        public string category { get; private set; }
        public string customCategory { get; set; }
        public decimal hours { get; private set; }
        public string manualRefNumber { get; private set; }

        private string postFileName;

        /// <summary>
        /// Loads data from the current row in the kitlog database
        /// </summary>
        /// <param name="reader"></param>
        public void Load(OdbcDataReader reader)
        {
            shortDescription = reader.GetString(reader.GetOrdinal("short_description"));
            comments = reader.GetString(reader.GetOrdinal("comments"));
            image1Caption = reader.GetString(reader.GetOrdinal("caption_1"));
            image2Caption = reader.GetString(reader.GetOrdinal("caption_2"));
            image3Caption = reader.GetString(reader.GetOrdinal("caption_3"));
            dateOfWork = reader.GetDate(reader.GetOrdinal("date_of_work"));
            image1 = ImageFromColumn("photo_1", reader);
            image2 = ImageFromColumn("photo_2", reader);
            image3 = ImageFromColumn("photo_3", reader);
            category = reader.GetString(reader.GetOrdinal("expense_category_name"));
            manualRefNumber = reader.GetString(reader.GetOrdinal("manual_ref_number"));
            hours = Decimal.Round(Convert.ToDecimal(reader.GetDouble(reader.GetOrdinal("number_of_hours"))), 2, MidpointRounding.AwayFromZero);

            string dateOfWorkString = dateOfWork.ToString("yyyy-MM-dd");
            string fileDescription = Regex.Replace(shortDescription.Replace(' ', '-'), "[^a-zA-Z0-9-]", "");
            string baseName = dateOfWorkString + "-" + fileDescription;
            postFileName = baseName + ".md";
            image1FileName = baseName + "-" + 1 + ".jpg";
            image2FileName = baseName + "-" + 2 + ".jpg";
            image3FileName = baseName + "-" + 3 + ".jpg";
        }

        /// <summary>
        /// Writes the post and images in the current worklog to the Jekyll site
        /// </summary>
        public void Write( string jekyllDirectory)
        {
            string postsDirectory = jekyllDirectory + "\\_posts\\";
            Directory.CreateDirectory(postsDirectory);
            WritePost(postsDirectory);

            string imagesDirectory = jekyllDirectory + "\\assets\\images\\";
            Directory.CreateDirectory(imagesDirectory);
            WriteImage(image1, imagesDirectory + image1FileName);
            WriteImage(image2, imagesDirectory + image2FileName);
            WriteImage(image3, imagesDirectory + image3FileName);
        }

        private void WritePost( String directory)
        {
            PostRenderer renderer = new PostRenderer(this);
            string rendered = renderer.TransformText();
            File.WriteAllText( directory + postFileName, rendered);
        }

        /// <summary>
        /// Writes an image, if it exists, to the Jekyll image folder
        /// </summary>
        /// <param name="image"></param>
        /// <param name="name"></param>
        private void WriteImage(System.Drawing.Image image, string name)
        {
            if (image != null)
            {
                using (FileStream fs = File.Create(name))
                {
                    image.Save(fs, ImageFormat.Jpeg);
                }
            }
        }

        /// <summary>
        /// Loads an image from a column with the given name if one exists
        /// </summary>
        /// <param name="column"></param>
        /// <param name="reader"></param>
        /// <returns></returns>
        private System.Drawing.Image ImageFromColumn(string column, OdbcDataReader reader)
        {
            try
            {
                int ordinal = reader.GetOrdinal(column);
                if (!reader.IsDBNull(ordinal))
                {
                    MemoryStream ms = new MemoryStream();
                    using (Stream dbs = reader.GetStream(ordinal))
                    {
                        dbs.CopyTo(ms);
                    }

                    return System.Drawing.Image.FromStream(ms);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return null;
        }
    }
}
