using System;
using System.Windows.Forms;
using System.Data.Odbc;

namespace KlpToJekyll
{
    /// <summary>
    /// A basic UI to allow selection of the kitlog database, jekyll directory, and define a customer category
    /// </summary>
    public partial class MainForm : Form
    {
        private OpenFileDialog kitLogDatabaseFileDialog;
        private FolderBrowserDialog jekyllProjectFileDialog;

        public MainForm()
        {
            InitializeComponent();

            kitLogDatabaseFileDialog = new OpenFileDialog();
            kitLogDatabaseFileDialog.Filter = "Database File (*.mdb)|*.mdb";
            kitLogDatabaseFileDialog.Title = "Open Database File";

            jekyllProjectFileDialog = new FolderBrowserDialog();
            jekyllProjectFileDialog.Description = "Open Jekyll Folder";
        }

        /// <summary>
        /// Restore values from the last run
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            kitlogDatabaseField.Text = Properties.Settings.Default.kitlogDatabaseLocation;
            jekyllProjectField.Text = Properties.Settings.Default.jekyllProjectLocation;
            customCategoryField.Text = Properties.Settings.Default.customCategoryName;
            UpdateGeneratable();
        }

        /// <summary>
        /// Save off values to be used on the next startup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (IsAccessDbValid())
            {
                Properties.Settings.Default.kitlogDatabaseLocation = kitlogDatabaseField.Text;
            }

            if( IsJekyllValid())
            {
                Properties.Settings.Default.jekyllProjectLocation = jekyllProjectField.Text;
            }

            Properties.Settings.Default.customCategoryName = customCategoryField.Text;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Does the actual export when the button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generateButton_Click(object sender, EventArgs e)
        {
            try
            {
                int exported = 0;
                string file = kitlogDatabaseField.Text;
                string connString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};DBQ=" + file;
                using (OdbcConnection conn = new OdbcConnection(connString))
                {
                    conn.Open();

                    using (OdbcCommand command = conn.CreateCommand())
                    {
                        command.CommandText = @"SELECT * FROM work_logs 
                            LEFT JOIN expense_categories ON work_logs.expense_category_id = expense_categories.expense_category_id";
                        using (OdbcDataReader reader = command.ExecuteReader())
                        {
                            var workLog = new WorkLog();
                            workLog.customCategory = customCategoryField.Text;
                            while (reader.Read())
                            {
                                workLog.Load(reader);
                                workLog.Write(jekyllProjectField.Text);
                                exported++;
                            }
                        }
                    }
                }

                MessageBox.Show($"Completed exporting {exported} work logs to Jekyll.", "Success!");
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        /// <summary>
        /// Opens a file selector allowing selection of the kit log database file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kitLogDatabaseButton_Click(object sender, EventArgs e)
        {
            kitLogDatabaseFileDialog.FileName = kitlogDatabaseField.Text;
            if (kitLogDatabaseFileDialog.ShowDialog() == DialogResult.OK)
            {
                kitlogDatabaseField.Text = kitLogDatabaseFileDialog.FileName;
            }
        }

        /// <summary>
        /// Opens a folder selector to pick the Jekyll path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jekyllProjectButton_Click(object sender, EventArgs e)
        {
            jekyllProjectField.Text = jekyllProjectField.Text;
            if (jekyllProjectFileDialog.ShowDialog() == DialogResult.OK)
            {
                jekyllProjectField.Text = jekyllProjectFileDialog.SelectedPath;
            }
        }

        /// <summary>
        /// Determines if the current kitlog database is valid or not
        /// </summary>
        /// <returns></returns>
        private bool IsAccessDbValid()
        {
            return System.IO.File.Exists(kitlogDatabaseField.Text);
        }

        /// <summary>
        /// Determines if the current jekyll folder is valid or not
        /// </summary>
        /// <returns></returns>
        private bool IsJekyllValid()
        {
            return System.IO.Directory.Exists(jekyllProjectField.Text);
        }

        /// <summary>
        /// Determines if everything needed to export from kitlog has been selected
        /// </summary>
        private void UpdateGeneratable()
        {
            generateButton.Enabled = IsAccessDbValid() && IsJekyllValid();
        }

        /// <summary>
        /// Show a basic error dialog for an exception
        /// </summary>
        /// <param name="ex"></param>
        private void ShowException( Exception ex)
        {
            MessageBox.Show(
                    $"Error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
        }

        /// <summary>
        /// Handles a change in the value of the Kit Log database field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kitlogDatabaseField_TextChanged(object sender, EventArgs e)
        {
            UpdateGeneratable();
        }

        /// <summary>
        /// Handles a change in the value of the Jekyll location field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jekyllProjectField_TextChanged(object sender, EventArgs e)
        {
            UpdateGeneratable();
        }
    }
}
