using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

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
                JObject foxJSON = JObject.Parse(htmlText.InnerText);
                var foxResult = (string)foxJSON.SelectToken("itemListElement[0].item.itemListElement[0].url");
                return foxResult;
            }
            else
            {
                return ("Broken Fox Pull");
            }
        }
        public static string BreitbartParser(string url)
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);
            HtmlNode htmlText = doc.DocumentNode.SelectSingleNode("//div[@class='col8 top-article']");

            if (htmlText != null)
            {
                return htmlText.InnerHtml;
            }
            else
            {
                return ("Broken BB Pull");
            }
        }
        public static string CNNParser(string url)
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var htmlText = doc.DocumentNode.SelectSingleNode("//script");

            if (htmlText != null)
            {
                //    var CNNMatch = Regex.Match(htmlText, "uri\":\b");
                //    return CNNMatch.ToString();
                return htmlText.InnerText;
            }
            else
            {
                return ("Broken CNN Pull");
            }
        }
    }
}

