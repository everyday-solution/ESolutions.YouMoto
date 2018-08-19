using ESolutions.Youmoto.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESolutions.Youmoto.Windows
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void selectFilesButton_Click(Object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileListItems = this.openFileDialog1.FileNames
                    .Select(runner => new FileViewModel(new FileInfo(runner)))
                    .Select(runner => new ListViewItem(new String[] { runner.File.FullName, String.Empty, String.Empty }) { Tag = runner })
                    .ToArray();
                this.filesListView.Items.AddRange(fileListItems);
            }
        }

        private void uploadFilesButton_Click(Object sender, EventArgs e)
        {
            var allFileModels = this.filesListView.Items.Cast<ListViewItem>().Select(runner => runner.Tag as FileViewModel);
            Task.Run(() =>
            {
                this.UploadFiles(allFileModels);
            });
        }

        private delegate void UploadFilesHandler(IEnumerable<FileViewModel> allFileModels);
        private void UploadFiles(IEnumerable<FileViewModel> allFileModels)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UploadFilesHandler(this.UploadFiles), new Object[] { allFileModels });
            }
            else
            {
                foreach (var runner in allFileModels)
                {
                    runner.Status = "reading image....";
                    this.UpdateView(runner);
                    var imageData = this.ReadImageToArray(runner);
                    var targetGuid = Guid.NewGuid();
                    runner.Status = "uploading...";
                    this.UpdateView(runner);
                    runner.CloudUrl = BlobHandler.WriteImage(imageData, targetGuid);
                    runner.Status = "ready!";
                    this.UpdateView(runner);
                }

                this.filesListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                this.filesListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private delegate void UpdateViewHandler(FileViewModel model);
        private void UpdateView(FileViewModel fileViewModel)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateViewHandler(this.UpdateView), new Object[] { fileViewModel });
            }
            else
            {
                var item = this.filesListView.Items.Cast<ListViewItem>().FirstOrDefault(runner => runner.Tag == fileViewModel);
                var viewModel = item.Tag as FileViewModel;
                item.SubItems[1].Text = viewModel.Status;
                item.SubItems[2].Text = viewModel?.CloudUrl?.ToString() ?? String.Empty;
            }
        }

        private Byte[] ReadImageToArray(FileViewModel fileViewModel)
        {
            Byte[] imageData = null;
            using (var stream = new MemoryStream())
            {
                using (Image bitmap = Bitmap.FromFile(fileViewModel.File.FullName))
                {
                    bitmap.Save(stream, ImageFormat.Jpeg);
                    imageData = stream.GetBuffer();
                }
            }

            return imageData;
        }

        private void copyUrlToClipboardButton_Click(Object sender, EventArgs e)
        {
            var lines = this.filesListView.Items
                .Cast<ListViewItem>()
                .Select(runner => runner.Tag as FileViewModel)
                .Select(runner => runner.CloudUrl.ToString());
            var clipboardContent = String.Join(Environment.NewLine, lines);
            Clipboard.SetText(clipboardContent);
        }
    }
}
