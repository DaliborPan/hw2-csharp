using HtmlAgilityPack;

namespace MenuScrapper
{
    public static class Utils
    {
        //Use this method to get HtmlDocument by url (see Constants.cs).
        //HtmlAgilityPack is required

        public static HtmlDocument GetHtmlDoc(string url)
        {
            var web = new HtmlWeb();
            return web.Load(url);
        }
    }
}
