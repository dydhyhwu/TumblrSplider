using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumblrSplider.Domains;
using TumblrSplider.Infrastructures.Services;

namespace TumblrSplider.Infrastructures.ServicesImpl
{
    public class TumblrServiceImpl : TumblrService
    {
        private PageService page_service;

        public TumblrServiceImpl(PageService page_service)
        {
            this.page_service = page_service;
        }

        public IEnumerable<string> get_followers(string user_name)
        {
            var base_url = $"http://{user_name}.tumblr.com/following/page/@page_index";
            return page_service.tumblr_followers_page(base_url);
        }

        public TumblrResource get_posts(string user_name)
        {

            var url = $"http://{user_name}.tumblr.com/api/read?start=@start&num=@page_size";
            return page_service.tumblr_posts_page(url);
        }
    }
}
