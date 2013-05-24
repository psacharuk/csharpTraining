using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace s2gr2
{
	public partial class NotepadView : UserControl
	{
		public NotepadView()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			using(var ofd = new OpenFileDialog())
			{
				if(ofd.ShowDialog()==DialogResult.OK)
				{
					//var lines = File.ReadAllLines(ofd.FileName);
					//textBox1.Lines = lines;
					using(var stream = File.OpenRead(ofd.FileName))
					{
						var bytes = new byte[stream.Length];
						stream.Read(bytes, 0, (int)stream.Length);//casting to int is BAD/EVIL
						textBox1.Text = Encoding.UTF8.GetString(bytes);
					}
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			using (var sfd = new SaveFileDialog())
			{
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					//File.WriteAllLines(sfd.FileName, textBox1.Lines);
					//new Encoding(1252)

					using (var stream = File.OpenWrite(sfd.FileName))
					{
						using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(textBox1.Text)))
						{
							ms.WriteTo(stream);
						}
					}
				}
			}
		}
	}

       
}
