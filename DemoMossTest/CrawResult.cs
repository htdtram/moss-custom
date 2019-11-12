using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoMossTest
{
    public class CrawResult
    {
        public static async Task<List<Source>> StartCrawTable(string url)
        {
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var trs = htmlDocument.DocumentNode.Descendants("tr").Where(node => node.FirstChild.Name.Equals("td")).ToList();

            var sources = new List<Source>();

            foreach (var tr in trs)
            {
                var tds = tr.Descendants("td").Where(node => node.FirstChild.Name.Equals("a")).ToList();
                foreach (var td in tds)
                {
                    var source = new Source
                    {
                        Name = td.Descendants("a").FirstOrDefault().InnerText,
                        Link = td.Descendants("a").FirstOrDefault().ChildAttributes("href").FirstOrDefault().Value
                    };
                    sources.Add(source);
                }
            }
            return sources;

        }

        public static async Task StartCrawDetail(string url)
        {
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var frames = htmlDocument.DocumentNode.Descendants("frame").ToList();

            Console.Write("a");

        }
    }
}
