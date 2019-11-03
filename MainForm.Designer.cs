namespace KlpToJekyll
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label kitLogDatabaseLabel;
            System.Windows.Forms.Label jekyllProjectLabel;
            System.Windows.Forms.Label customerCategoryLabel;
            this.generateButton = new System.Windows.Forms.Button();
            this.kitlogDatabaseField = new System.Windows.Forms.TextBox();
            this.jekyllProjectField = new System.Windows.Forms.TextBox();
            this.customCategoryField = new System.Windows.Forms.TextBox();
            this.kitLogDatabaseButton = new System.Windows.Forms.Button();
            this.jekyllProjectButton = new System.Windows.Forms.Button();
            kitLogDatabaseLabel = new System.Windows.Forms.Label();
            jekyllProjectLabel = new System.Windows.Forms.Label();
            customerCategoryLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // kitLogDatabaseLabel
            // 
            kitLogDatabaseLabel.AutoSize = true;
            kitLogDatabaseLabel.Location = new System.Drawing.Point(13, 16);
            kitLogDatabaseLabel.Name = "kitLogDatabaseLabel";
            kitLogDatabaseLabel.Size = new System.Drawing.Size(89, 13);
            kitLogDatabaseLabel.TabIndex = 1;
            kitLogDatabaseLabel.Text = "Kit Log Database";
            // 
            // jekyllProjectLabel
            // 
            jekyllProjectLabel.AutoSize = true;
            jekyllProjectLabel.Location = new System.Drawing.Point(30, 43);
            jekyllProjectLabel.Name = "jekyllProjectLabel";
            jekyllProjectLabel.Size = new System.Drawing.Size(69, 13);
            jekyllProjectLabel.TabIndex = 5;
            jekyllProjectLabel.Text = "Jekyll Project";
            // 
            // customerCategoryLabel
            // 
            customerCategoryLabel.AutoSize = true;
            customerCategoryLabel.Location = new System.Drawing.Point(12, 70);
            customerCategoryLabel.Name = "customerCategoryLabel";
            customerCategoryLabel.Size = new System.Drawing.Size(87, 13);
            customerCategoryLabel.TabIndex = 6;
            customerCategoryLabel.Text = "Custom Category";
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(105, 93);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 0;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // kitlogDatabaseField
            // 
            this.kitlogDatabaseField.Location = new System.Drawing.Point(105, 13);
            this.kitlogDatabaseField.Name = "kitlogDatabaseField";
            this.kitlogDatabaseField.Size = new System.Drawing.Size(300, 20);
            this.kitlogDatabaseField.TabIndex = 2;
            this.kitlogDatabaseField.TextChanged += new System.EventHandler(this.kitlogDatabaseField_TextChanged);
            // 
            // jekyllProjectField
            // 
            this.jekyllProjectField.Location = new System.Drawing.Point(105, 40);
            this.jekyllProjectField.Name = "jekyllProjectField";
            this.jekyllProjectField.Size = new System.Drawing.Size(300, 20);
            this.jekyllProjectField.TabIndex = 3;
            this.jekyllProjectField.TextChanged += new System.EventHandler(this.jekyllProjectField_TextChanged);
            // 
            // customCategoryField
            // 
            this.customCategoryField.Location = new System.Drawing.Point(105, 67);
            this.customCategoryField.Name = "customCategoryField";
            this.customCategoryField.Size = new System.Drawing.Size(300, 20);
            this.customCategoryField.TabIndex = 4;
            // 
            // kitLogDatabaseButton
            // 
            this.kitLogDatabaseButton.Location = new System.Drawing.Point(411, 11);
            this.kitLogDatabaseButton.Name = "kitLogDatabaseButton";
            this.kitLogDatabaseButton.Size = new System.Drawing.Size(75, 23);
            this.kitLogDatabaseButton.TabIndex = 7;
            this.kitLogDatabaseButton.Text = "Select";
            this.kitLogDatabaseButton.UseVisualStyleBackColor = true;
            this.kitLogDatabaseButton.Click += new System.EventHandler(this.kitLogDatabaseButton_Click);
            // 
            // jekyllProjectButton
            // 
            this.jekyllProjectButton.Location = new System.Drawing.Point(411, 38);
            this.jekyllProjectButton.Name = "jekyllProjectButton";
            this.jekyllProjectButton.Size = new System.Drawing.Size(75, 23);
            this.jekyllProjectButton.TabIndex = 8;
            this.jekyllProjectButton.Text = "Select";
            this.jekyllProjectButton.UseVisualStyleBackColor = true;
            this.jekyllProjectButton.Click += new System.EventHandler(this.jekyllProjectButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 123);
            this.Controls.Add(this.jekyllProjectButton);
            this.Controls.Add(this.kitLogDatabaseButton);
            this.Controls.Add(customerCategoryLabel);
            this.Controls.Add(jekyllProjectLabel);
            this.Controls.Add(this.customCategoryField);
            this.Controls.Add(this.jekyllProjectField);
            this.Controls.Add(this.kitlogDatabaseField);
            this.Controls.Add(kitLogDatabaseLabel);
            this.Controls.Add(this.generateButton);
            this.Name = "MainForm";
            this.Text = "KitLogPro To Jekyll";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.TextBox kitlogDatabaseField;
        private System.Windows.Forms.TextBox jekyllProjectField;
        private System.Windows.Forms.TextBox customCategoryField;
        private System.Windows.Forms.Button kitLogDatabaseButton;
        private System.Windows.Forms.Button jekyllProjectButton;
    }
}

