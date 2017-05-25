using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using HtmlAgilityPack;

namespace FakeNewsProfiler
{
    public partial class _Default : Page
    {
        public string htmlOutput;
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] input = { "http://www.cnn.com", "http://www.foxnews.com", "http://www.breitbart.com", "http://www.msnbc.com", "http://www.drudgereport.com" };
            htmlOutput = "<table>";
            List<string> Urls = new List<string>(input);
            foreach (var Url in Urls)
            {
                string htmlStripText = GetWebText(Url);
                htmlOutput += "<tr><td>";
                htmlOutput += (htmlStripText);
                htmlOutput += "</td></tr>";
            }
            htmlOutput += "</table>";
        }
        private static string GetWebText(string args)
        {
            var web = new HtmlWeb();
            var doc = web.Load(args);
            HtmlNode htmlText = doc.DocumentNode.SelectSingleNode("//a");
            if (htmlText != null)
            {
                return htmlText.InnerHtml;
            }
            else
            {
                return ("Broken Pull");
            }

        }
    }
}