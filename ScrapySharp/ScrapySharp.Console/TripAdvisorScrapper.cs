using HtmlAgilityPack;
using ScrapySharp.Network;
using System;

namespace ScrapySharp.Console
{
    internal static class TripAdvisorScrapper
    {
        static ScrapingBrowser Browser = new ScrapingBrowser();
        static string _tripAdvisorURL = "https://www.tripadvisor.com/Attraction_Review-g293960-d450851-Reviews-Faisal_Mosque-Islamabad_Islamabad_Capital_Territory.html";
        public static void Start()
        {
            System.Console.WriteLine("Trip Advisor scrapping started ....");
            System.Console.WriteLine();
            Browser.IgnoreCookies = true;
            Browser.AllowAutoRedirect = true;
            Browser.AllowMetaRedirect = true;
            GetTripComments();
            System.Console.WriteLine("Trip Advisor scrapping ended ....");
            System.Console.WriteLine();
        }

        private static void GetTripComments()
        {
            var pageHTML = GetPageHtml(_tripAdvisorURL);
            var commentsContainer = GetCommentsContainer(pageHTML);
        }

        private static string GetCommentsContainer(HtmlNode pageHTML)
        {
            var commentSectionNode = pageHTML.SelectNodes("//div[contains(@class, 'dHjBB')]");
            if (commentSectionNode == null) return string.Empty;
            return Utils.ConvertToPlainText(commentSectionNode.First().InnerText);
        }

        private static HtmlNode GetPageHtml(string url)
        {
            try
            {
                //var webGet = new HtmlWeb();
                //var document = webGet.Load(url);
                //System.Console.WriteLine(document.DocumentNode.OuterHtml);

                var webpage = Browser.NavigateToPage(new Uri(url));
                return webpage.Html;
            }
            catch (Exception ex)
            {
                var emptyHtmlNode = HtmlNode.CreateNode("<span></span>");
                return emptyHtmlNode;
            }
        }
    }
}
