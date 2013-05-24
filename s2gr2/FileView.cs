using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace s2gr2
{
    public partial class FileView : UserControl
    {
        public FileView()
        {
            InitializeComponent();
            
        }

        private void loadPathBtn_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    treeView1.Nodes.Clear();
                    var directoryPath = Path.GetDirectoryName(ofd.FileName);
                    DealDirectories(directoryPath, null);
                }
            }
        }

        void DealDirectories(string path, TreeNode parent)
        {
            var di = new DirectoryInfo(path);

            var directories = di.GetDirectories();
            foreach (var directory in directories)
            {
                var node = parent != null
                    ? parent.Nodes.Add(directory.Name)
                    : treeView1.Nodes.Add(directory.Name);
                DealDirectories(directory.FullName, node);
            }
            var fileInfos = di.GetFiles();
            foreach (var fileInfo in fileInfos)
            {
                if (parent != null)
                    parent.Nodes.Add(fileInfo.Name);
                else
                    treeView1.Nodes.Add(fileInfo.Name);
            }
        }
    }
}
