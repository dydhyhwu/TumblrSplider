using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using DY.Crawler.Core.Domains.Extensions;
using HtmlAgilityPack;
using TumblrSplider.Domains;
using TumblrSplider.Infrastructures.Services;

namespace TumblrSplider.Infrastructures.ServicesImpl
{
    public class PageServiceImpl : PageService
    {
        private HttpClient client;

        public PageServiceImpl(HttpClient client)
        {
            this.client = client;
        }
        public IEnumerable<string> tumblr_followers_page(string url_template)
        {
            var page_index = 1;
            var list = new List<string>();
            while (true)
            {
                var content = url_template.Replace("@page_index", page_index.ToString()).get_content(client);
                var doc = new HtmlDocument();
                doc.LoadHtml(content);
                var nodes = doc.DocumentNode.SelectNodes(XPathRules.TumblrUserName);
                if (nodes == null) break;
                nodes.each(x => list.Add(x.InnerHtml));

                page_index += 1;
            }
            return list;
        }

        public TumblrResource tumblr_posts_page(string url_template)
        {
            var page_size = get_tumblr_posts_page_num(url_template, 50);
            var all_videos = new List<string>();
            var all_photos = new List<string>();
            for (int index = 1; index <= page_size; index++)
            {
                var start = (index - 1) * 50;
                var content = url_template.Replace("@start", start.ToString()).Replace("@page_size", "50").get_content(client);
                var doc = new HtmlDocument();
                doc.LoadHtml(content);
                var photos = doc.DocumentNode.SelectNodes(XPathRules.TumblrUserPhoto);
                if (photos != null)
                {
                    all_photos.AddRange(photos.Select(x => x.InnerHtml).Distinct());
                }
                var videos_players = doc.DocumentNode.SelectNodes(XPathRules.TumblrUserVideo);
                if (videos_players != null)
                {
                    var videos = videos_players
                        .Select(x =>
                                {
                                    var temp_doc = new HtmlDocument();
                                    temp_doc.LoadHtml(x.InnerHtml
                                                       .Replace("\n&lt;", "<")
                                                       .Replace("&gt;\n", ">")
                                                       .Replace("&lt;", "<")
                                                       .Replace("&gt;", ">")
                                    );
                                    var video = temp_doc.DocumentNode.SelectSingleNode(XPathRules.TumblrVideoSource);
                                    if (video == null) return string.Empty;
                                    return video.GetAttributeValue("src", "");
                                })
                        .Where(x => !string.IsNullOrEmpty(x))
                        .Distinct();
                    all_videos.AddRange(videos);
                }
            }
            return new TumblrResource(all_photos, all_videos);
        }

        private int get_tumblr_posts_page_num(string url_template, int page_size)
        {
            var content = url_template.Replace("@start", "0").Replace("@page_size", page_size.ToString()).get_content(client);
            if (string.IsNullOrEmpty(content)) return 0;
            var doc = new HtmlDocument();
            doc.LoadHtml(content);
            var page_num = doc.DocumentNode.SelectSingleNode(XPathRules.TumblrPosts).GetAttributeValue("total", 1);
            return page_num % page_size > 0 ? page_num / page_size + 1 : page_num / page_size;
        }
    }
}
