using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumblrSplider.Domains;

namespace TumblrSplider.Infrastructures.Services
{
    public interface TumblrService
    {
        IEnumerable<string> get_followers(string user_name);
        TumblrResource get_posts(string user_name);
    }
}
