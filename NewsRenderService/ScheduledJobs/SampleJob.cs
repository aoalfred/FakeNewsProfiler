using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using HtmlAgilityPack;


namespace NewsRenderService.ScheduledJobs
{
    // A simple scheduled job which can be invoked manually by submitting an HTTP
    // POST request to the path "/jobs/sample".

    public class NewsGrabber : ScheduledJob
    {
        public override Task ExecuteAsync()
        {
            string[] input = { "http://www.cnn.com", "http://www.foxnews.com", "http://www.breitbart.com", "http://www.msnbc.com" };
            List<string> Urls = new List<string>(input);
            foreach (var Url in Urls)
            {
                string htmlStripText = GetWebText(Url);
            }
        private static string GetWebText(string args)
        {
            var web = new HtmlWeb();
            var doc = web.Load(args);
            HtmlNode htmlText = doc.DocumentNode.SelectSingleNode("//body");
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