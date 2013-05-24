using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace s2gr2
{

    public partial class LinkForm : Form
    {
        public LinkForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var str = GetUrl("http://www.wp.pl");
            var regexp = new Regex("<a href=\"(.*)\">(.*)</a>");
            var matches = regexp.Matches(str);

            foreach (Match match in matches)
            {
                if (!match.Success)
                    continue;
                var str1 = match.Groups[0].Value;
                var str2 = match.Groups[1].Value;

            }

            var lst = new List<LinkItem>();
            lst.Add(new LinkItem() { Name = "wp", Href = "wp.pl" });
            lst.Add(new LinkItem() { Name = "onet", Href = "onet.pl" });
           
            dataGridView1.DataSource = lst;
        }
    }
    class LinkItem
    {
        public string Name { get; set; }
        public string Href { get; set; }
    }
}
