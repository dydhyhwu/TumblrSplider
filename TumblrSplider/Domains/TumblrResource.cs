using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumblrSplider.Domains
{
    public class TumblrResource
    {
        public TumblrResource(IEnumerable<string> photos, IEnumerable<string> videos)
        {
            Photos = photos;
            Videos = videos;
        }

        public IEnumerable<string> Photos;
        public IEnumerable<string> Videos;
    }
}
