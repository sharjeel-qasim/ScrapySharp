using HtmlAgilityPack;
using ScrapySharp.Network;

namespace ScrapySharp.Console
{
    internal static class TripAdvisorScrapper
    {
        static ScrapingBrowser _browser = new ScrapingBrowser();
        static string _tripAdvisorURL = "https://www.tripadvisor.co.nz/Attraction_Review-g662316-d10038189-Reviews-Kashmir_Point-Murree_Punjab_Province.html";
        public static void Start()
        {
            System.Console.WriteLine("Trip Advisor scrapping started ....");
            System.Console.WriteLine();
            _browser.IgnoreCookies = true;
            GetTripComments();
            System.Console.WriteLine("Trip Advisor scrapping ended ....");
            System.Console.WriteLine();
        }

        private static void GetTripComments()
        {
            throw new NotImplementedException();
        }


        private static HtmlNode GetPageHtml(string url)
        {
            try
            {
                var webpage = _browser.NavigateToPage(new Uri(url));
                return webpage.Html;
            }
            catch
            {
                var emptyHtmlNode = HtmlNode.CreateNode("<span></span>");
                return emptyHtmlNode;
            }
        }
    }
}
