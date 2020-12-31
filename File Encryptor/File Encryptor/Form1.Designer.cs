namespace File_Decryptor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.file_list = new System.Windows.Forms.ListBox();
            this.add_files = new System.Windows.Forms.Button();
            this.remove_button = new System.Windows.Forms.Button();
            this.encrypt_button = new System.Windows.Forms.Button();
            this.passbox = new System.Windows.Forms.TextBox();
            this.decrypt_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // file_list
            // 
            this.file_list.AllowDrop = true;
            this.file_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.file_list.FormattingEnabled = true;
            this.file_list.ItemHeight = 15;
            this.file_list.Location = new System.Drawing.Point(243, 10);
            this.file_list.Name = "file_list";
            this.file_list.Size = new System.Drawing.Size(312, 439);
            this.file_list.TabIndex = 0;
            // 
            // add_files
            // 
            this.add_files.Location = new System.Drawing.Point(12, 12);
            this.add_files.Name = "add_files";
            this.add_files.Size = new System.Drawing.Size(75, 23);
            this.add_files.TabIndex = 1;
            this.add_files.Text = "Add Files";
            this.add_files.UseVisualStyleBackColor = true;
            this.add_files.Click += new System.EventHandler(this.add_files_Click);
            // 
            // remove_button
            // 
            this.remove_button.Location = new System.Drawing.Point(12, 41);
            this.remove_button.Name = "remove_button";
            this.remove_button.Size = new System.Drawing.Size(75, 23);
            this.remove_button.TabIndex = 2;
            this.remove_button.Text = "Remove";
            this.remove_button.UseVisualStyleBackColor = true;
            this.remove_button.Click += new System.EventHandler(this.remove_button_Click);
            // 
            // encrypt_button
            // 
            this.encrypt_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.encrypt_button.Enabled = false;
            this.encrypt_button.Location = new System.Drawing.Point(8, 426);
            this.encrypt_button.Name = "encrypt_button";
            this.encrypt_button.Size = new System.Drawing.Size(75, 23);
            this.encrypt_button.TabIndex = 3;
            this.encrypt_button.Text = "Encrypt";
            this.encrypt_button.UseVisualStyleBackColor = true;
            this.encrypt_button.Click += new System.EventHandler(this.encrypt_button_Click);
            // 
            // passbox
            // 
            this.passbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.passbox.Location = new System.Drawing.Point(97, 397);
            this.passbox.Name = "passbox";
            this.passbox.Size = new System.Drawing.Size(136, 23);
            this.passbox.TabIndex = 4;
            // 
            // decrypt_button
            // 
            this.decrypt_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.decrypt_button.Enabled = false;
            this.decrypt_button.Location = new System.Drawing.Point(158, 426);
            this.decrypt_button.Name = "decrypt_button";
            this.decrypt_button.Size = new System.Drawing.Size(75, 23);
            this.decrypt_button.TabIndex = 5;
            this.decrypt_button.Text = "Decrypt";
            this.decrypt_button.UseVisualStyleBackColor = true;
            this.decrypt_button.Click += new System.EventHandler(this.decrypt_button_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 400);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Encryption key:";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(567, 459);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.decrypt_button);
            this.Controls.Add(this.passbox);
            this.Controls.Add(this.encrypt_button);
            this.Controls.Add(this.remove_button);
            this.Controls.Add(this.add_files);
            this.Controls.Add(this.file_list);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "File Encryptor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button remove_button;
        private System.Windows.Forms.ListBox file_list;
        private System.Windows.Forms.Button add_files;
        private System.Windows.Forms.Button encrypt_button;
        private System.Windows.Forms.TextBox passbox;
        private System.Windows.Forms.Button decrypt_button;
        private System.Windows.Forms.Label label1;
    }
}

