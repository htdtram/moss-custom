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
        public static List<Result> StartCrawTable(string url)
        {
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var trs = htmlDocument.DocumentNode.Descendants("tr").Where(node => node.FirstChild.Name.Equals("td")).ToList();

            var results = new List<Result>();

            foreach (var tr in trs)
            {
                //var tds = tr.Descendants("td").Where(node => node.FirstChild.Name.Equals("a")).ToList();
                var tds = tr.Descendants("td").ToList();
                var result = new Result
                {
                    Source1 = tds[0].Descendants("a").FirstOrDefault().InnerText,
                    Source2 = tds[1].Descendants("a").FirstOrDefault().InnerText,
                    Link = tds[1].Descendants("a").FirstOrDefault().ChildAttributes("href").FirstOrDefault().Value,
                    NumberLine = tds[2].InnerText
                };
                results.Add(result);
            }
            return results;

        }

        public static void StartCrawDetail(string url)
        {
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var subUrl = url.Substring(0, url.LastIndexOf('/')+1);
            var frameLinks = htmlDocument.DocumentNode.Descendants("frame").ToList().Select(node=>subUrl+ node.ChildAttributes("src").FirstOrDefault().Value).Skip(1).ToList();
            var details = new List<Compare>();

            foreach (var link in frameLinks)
            {
                html = httpClient.GetStringAsync(link).Result;
                htmlDocument.LoadHtml(html);

                var text = htmlDocument.DocumentNode.Descendants("body").FirstOrDefault();
                //var detail = new Compare
                //{
                //    Name = text.Descendants("body").FirstOrDefault().InnerText

                //};
                //details.Add(detail);
            }

            Console.Write("a");

        }
    }
}
