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
    public partial class NotepadLoader : UserControl
    {
        public NotepadLoader()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var lines = File.ReadAllLines(ofd.FileName);
                    textBox1.Lines = lines;
                }
            }    
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllLines(sfd.FileName, textBox1.Lines);
                }
            }
        }
    }
}
