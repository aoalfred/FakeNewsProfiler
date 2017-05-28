using System;
using System.Web.UI;

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
            htmlOutput += "<tr><td>";
            htmlStripText = SiteParsers.BreitbartParser("http://www.breitbart.com");
            htmlOutput += (htmlStripText);
            htmlOutput += "</td></tr>";
            htmlOutput += "<tr><td>";
            htmlStripText = SiteParsers.CNNParser("http://www.cnn.com");
            htmlOutput += "</td></tr>";
            htmlOutput += "</table>";
        }
    }
}