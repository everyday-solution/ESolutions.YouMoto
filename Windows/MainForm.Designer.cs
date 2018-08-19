namespace ESolutions.Youmoto.Windows
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
            System.Windows.Forms.ColumnHeader columnHeader1;
            System.Windows.Forms.ColumnHeader columnHeader2;
            System.Windows.Forms.ColumnHeader columnHeader3;
            this.filesListView = new System.Windows.Forms.ListView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.selectFilesButton = new System.Windows.Forms.Button();
            this.uploadFilesButton = new System.Windows.Forms.Button();
            this.copyUrlToClipboardButton = new System.Windows.Forms.Button();
            columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "local file";
            columnHeader1.Width = 480;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "status";
            columnHeader2.Width = 129;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "url";
            columnHeader3.Width = 707;
            // 
            // filesListView
            // 
            this.filesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader1,
            columnHeader2,
            columnHeader3});
            this.filesListView.FullRowSelect = true;
            this.filesListView.Location = new System.Drawing.Point(12, 78);
            this.filesListView.Name = "filesListView";
            this.filesListView.Size = new System.Drawing.Size(1435, 803);
            this.filesListView.TabIndex = 0;
            this.filesListView.UseCompatibleStateImageBehavior = false;
            this.filesListView.View = System.Windows.Forms.View.Details;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog";
            this.openFileDialog1.Filter = "Image Files(*.png;*.jpg)|*.png;*jpg";
            this.openFileDialog1.Multiselect = true;
            // 
            // selectFilesButton
            // 
            this.selectFilesButton.Location = new System.Drawing.Point(12, 12);
            this.selectFilesButton.Name = "selectFilesButton";
            this.selectFilesButton.Size = new System.Drawing.Size(296, 60);
            this.selectFilesButton.TabIndex = 1;
            this.selectFilesButton.Text = "select files";
            this.selectFilesButton.UseVisualStyleBackColor = true;
            this.selectFilesButton.Click += new System.EventHandler(this.selectFilesButton_Click);
            // 
            // uploadFilesButton
            // 
            this.uploadFilesButton.Location = new System.Drawing.Point(12, 887);
            this.uploadFilesButton.Name = "uploadFilesButton";
            this.uploadFilesButton.Size = new System.Drawing.Size(296, 60);
            this.uploadFilesButton.TabIndex = 2;
            this.uploadFilesButton.Text = "upload files";
            this.uploadFilesButton.UseVisualStyleBackColor = true;
            this.uploadFilesButton.Click += new System.EventHandler(this.uploadFilesButton_Click);
            // 
            // copyUrlToClipboardButton
            // 
            this.copyUrlToClipboardButton.Location = new System.Drawing.Point(314, 887);
            this.copyUrlToClipboardButton.Name = "copyUrlToClipboardButton";
            this.copyUrlToClipboardButton.Size = new System.Drawing.Size(296, 60);
            this.copyUrlToClipboardButton.TabIndex = 3;
            this.copyUrlToClipboardButton.Text = "url to clipboard";
            this.copyUrlToClipboardButton.UseVisualStyleBackColor = true;
            this.copyUrlToClipboardButton.Click += new System.EventHandler(this.copyUrlToClipboardButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1459, 959);
            this.Controls.Add(this.copyUrlToClipboardButton);
            this.Controls.Add(this.uploadFilesButton);
            this.Controls.Add(this.selectFilesButton);
            this.Controls.Add(this.filesListView);
            this.Name = "MainForm";
            this.Text = "Youmoto";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView filesListView;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button selectFilesButton;
        private System.Windows.Forms.Button uploadFilesButton;
        private System.Windows.Forms.Button copyUrlToClipboardButton;
    }
}

