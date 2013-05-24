using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using common;

namespace s2gr2
{
	public partial class LinkView : UserControl
	{
		private readonly IMessageBoxService _messageBoxService;

		public LinkView(IMessageBoxService messageBoxService)
		{
			InitializeComponent();
			_messageBoxService = messageBoxService;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var lst = new List<LinkItem>();

			var str = GetUrl("http://www.wp.pl");

			//string openingStr = "<a href=\"";
			//string endingStr = "</a>";
			//int lastIdx = 0;
			//while (true)
			//{
			//    int idxStart = str.IndexOf(openingStr, lastIdx);
			//    if (idxStart == -1)
			//        break;

			//    int idxEnd = str.IndexOf(endingStr, idxStart);
			//    if (idxEnd == -1)
			//        break;

			//    var item = new LinkItem();

			//    string link = str.Substring(idxStart + openingStr.Length, idxEnd - idxStart - openingStr.Length);
			//    int k = link.IndexOf("\"");
			//    if (k != -1)
			//        item.Href = link.Substring(0, k);
			//    else
			//        item.Href = link;

			//    int kA = str.IndexOf(">", idxStart);
			//    if(kA!=-1)
			//        item.Name = str.Substring(kA + 1, idxEnd - kA - 1);

			//    lst.Add(item);
			//    lastIdx = idxEnd;
			//}

			var regex = new Regex("<a href=\"([^\"]*)\">(.*)</a>", RegexOptions.IgnoreCase|RegexOptions.Compiled);
			var matches = regex.Matches(str);
			foreach (Match match in matches)
			{
				if(!match.Success)
					continue;

				//var str1 = match.Groups[0].Value;
				var str2 = match.Groups[1].Value;
				var str3 = match.Groups[2].Value;
				lst.Add(new LinkItem(){Href = str2, Name = str3});
			}

			//var s1 = "aseg";
			//var s2 = "aseg";
			//var s3 = "aseg";

			//var s4 = s1 + s2 + s3;
			//var s5 = string.Format("s1: {0} s2: {1} s3: {2}", s1, s2, s3);
			//var sb = new StringBuilder();
			//sb.Append(s1);
			//sb.Append(s2);
			//sb.Append(s3);
			//var s6 = sb.ToString();

			dataGridView1.DataSource = lst;

			_messageBoxService.ShowMessage("done");
		}

		static string GetUrl(string url)
		{
			var request = (HttpWebRequest)WebRequest.Create(url);

			request.Method = "GET";
			var response = request.GetResponse();

			var dataStream = response.GetResponseStream();

			var ms = new MemoryStream();

			int count;
			var size = (int)response.ContentLength;
			var buf = new byte[size];
			do
			{
				count = dataStream.Read(buf, 0, size);
				ms.Write(buf, 0, count);
			} while (dataStream.CanRead && count > 0);

			var bytes = ms.ToArray();
			dataStream.Close();
			response.Close();
			ms.Close();
			return Encoding.UTF8.GetString(bytes);
		}

		class LinkItem
		{
			public string Name { get; set; }
			public string Href { get; set; }
		}
	}
}
