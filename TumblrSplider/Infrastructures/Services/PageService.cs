using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumblrSplider.Domains;

namespace TumblrSplider.Infrastructures.Services
{
    public interface PageService
    {
        IEnumerable<string> tumblr_followers_page(string url_template);
        TumblrResource tumblr_posts_page(string url_template);
    }
}
