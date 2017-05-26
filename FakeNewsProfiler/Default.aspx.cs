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
            string htmlStripText = SiteParsers.FoxNewsParser("http://www.foxnews.com");
            htmlOutput += "<tr><td>";
            htmlOutput += (htmlStripText);
            htmlOutput += "</td></tr>";
            htmlOutput += "</table>";
        }
    }
}