using HtmlAgilityPack;

namespace FakeNewsProfiler
{
    public class SiteParsers
    {
        public static string FoxNewsParser(string url)
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);
            HtmlNode htmlText = doc.DocumentNode.SelectSingleNode("//script[@type='application/ld+json']");

            if (htmlText != null)
            {
                return htmlText.InnerText;
            }
            else
            {
                return ("Broken Pull");
            }
        }
    }
}