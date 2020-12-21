using System;
using System;
using System.Net;
using System.Collections.Generic;
using System.Web;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;
using Microsoft;

namespace Lab_4_1
{
    class Lab_4_1
    {
        public class WebScanner : IDisposable
        {
            private readonly HashSet<Uri> _procLinks = new HashSet<Uri>();
            private readonly WebClient _webClient = new WebClient();

            private readonly HashSet<string> _ignoreFiles =
                new HashSet<string> { ".ico", ".xml" };
            private void onTargetFound(Uri page, string[] links, List <string> Alts)
            {
                TargetFound?.Invoke(page, links, Alts);
            }
            private void Process(string domain, Uri page, int count)
            {
                if (count <= 0) return;

                if (_procLinks.Contains(page)) return;
                _procLinks.Add(page);

                string _page = _webClient.DownloadString(page);

                var _images = (from image in Regex.Matches(_page, @"<img .*?\/>").Cast<Match>()
                               let url = Regex.Match(image.Value, @"src="".*?\""").Value.Replace(@"src=", "").Replace(@"""", "")         
                               let alt = Regex.Match(image.Value, @"alt="".*?\""").Value.Replace(@"alt=", "")
                               let _domain = page.Host
                               let loc = url.StartsWith("/")
                               select new { Ref = url, IsLocal = loc, Alt = alt }).ToArray();

                string[] loc_images = (from image in _images
                                  where image.IsLocal
                                  select ($"{page.Scheme}://{page.Host}{image.Ref} , {image.Alt}")).ToArray();

                string[] ex_images = (from image in _images
                                 where !image.IsLocal
                                 select ($"{image.Ref} ,{image.Alt} ")).ToArray();

                string[] all_images = loc_images.Union(ex_images).ToArray();

                List<string> alts = new List<string>();
                alts = (from image in _images
                        select image.Alt).ToList();

                if (all_images.Length > 0) onTargetFound(page, all_images,alts);

                var hrefs = (from href in Regex.Matches(_page, @"href=""[\/\w-\.:]+""").Cast<Match>()
                            let url = href.Value.Replace("href=", "").Trim('"')

                            let loc = url.StartsWith("/")
                            select new { Ref =  (domain + url), IsLocal = loc }).ToList();

                var locals = (from href in hrefs
                              where href.IsLocal
                              select new Uri(href.Ref)).ToList();
                foreach (var href in locals)
                {
                    string fileEx = Path.GetExtension(href.LocalPath).ToLower();
                    if (_ignoreFiles.Contains(fileEx)) continue;

                    Process(domain, href, --count);
                }
            }
            public event Action<Uri, string[],List<string>> TargetFound;
            public void Scan(Uri startPage,int pageCount)
            {
                
                _procLinks.Clear();
                string domain = $"{startPage.Scheme}://{startPage.Host}";
                Process(domain, startPage, pageCount);
                
            }
            public void Dispose()
            {
                _webClient.Dispose();
            }
            public void FindTarget(Uri a, Uri[] b)
            {
                WebClient client = new WebClient();
                string page = client.DownloadString(a);
                var _images = (from image in Regex.Matches(page, @"<img .*?\/>").Cast<Match>()
                               let url = Regex.Match(image.Value, @"src="".*?\""").Value.Replace(@"src=", "").Replace(@"""", "")
                               let alt = Regex.Match(image.Value, @"img alt="".*?\""").Value.Replace(@"img alt=", "").Replace(@"""", "")
                               let domain = a.Host
                               let loc = url.StartsWith("/")
                               select new { Ref = url, IsLocal = loc,Alt = alt }).ToArray();
                var loc_images = (from image in _images
                              where image.IsLocal
                              select new Uri( a.Scheme + image.Ref)).ToArray();

                var ex_images = (from image in _images
                                 where !image.IsLocal
                                 select new Uri(image.Ref)).ToArray();

                List<string> alts = new List<string>();
                alts = (from image in _images
                        select image.Alt).ToList();

                Uri[] all_images = loc_images.Union(ex_images).ToArray();
               
            }
        }
        static void Main(string[] args)
        {
            using(WebScanner scanner = new WebScanner())
            {
                scanner.TargetFound += (page, links,Alts) =>
                {
                    WebClient webClient = new WebClient();

                    //for (int j = 0; j < Alts.Length; j++) Console.WriteLine(Alts[j]);

                    Console.WriteLine($"\nPage:\n{page}\nLinks:");
                    int i = 0;
                    foreach (var _link in links)
                    {

                        
                        if (Regex.Match(_link, @", "".*?\""").Length >4)
                        {
                            var title = Regex.Match(_link, @", "".*?\""");
                            var link = _link.Replace(title.Value, "").Trim('"');
                            int level = Regex.Matches(link, @"\/").Count();
                            Console.WriteLine($"{link}\n caption: {title.Value.Replace(",","")}  \nlevel = {level}\n-------------------");
                        }
                        else
                        {

                            var link = _link.Replace(@",""""", "").Replace(",","").Trim('"');
                            int level = Regex.Matches(link, @"\/").Count();
                            Console.WriteLine($"{link}\ncaption: None  \nlevel = {level}\n-------------------");
                        }
                        i++;
                    }
                       
                };

                scanner.TargetFound += (page, links, Alts) =>
                {
                    using (var w = new StreamWriter(@"D:\Csv.csv"))
                    {
                        foreach (var _link in links)
                        {
                            if (Regex.Match(_link, @", "".*?\""").Length > 4)
                            {
                                var title = Regex.Match(_link, @", "".*?\""");

                                var link = _link.Replace(title.Value, "").Trim('"');
                                int level = Regex.Matches(link, @"\/").Count();
                                var line = string.Format("{0},{1},{2}", title.ToString().Replace(",", ""), link, level);
                                w.WriteLine(line);
                                w.Flush();
                            }
                            else 
                            {
                                var link = _link.Replace(@",""""", "").Replace(",", "").Trim('"');
                                int level = Regex.Matches(link, @"\/").Count();
                                var line = string.Format("{0},{1},{2}", "No Title", link, level);
                                w.WriteLine(line);
                                w.Flush();
                            } 
                            
                        }
                    }
                };
                scanner.Scan(new Uri("https://www.susu.ru"), 10);
                Console.WriteLine("Done");
                
            }
            
        }
    }
}
