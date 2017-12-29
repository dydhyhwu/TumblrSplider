using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumblrSplider.Domains
{
    public static class XPathRules
    {
        public static string TumblrUserName = "/html[1]/body[1]/section[1]/section[1]/div[1]/div[1]/div/div[1]/div[1]/div[1]/div[1]/h3[1]/a[1]/span[1]";
        public static string TumblrPosts = "/tumblr[1]/posts[1]";
        public static string TumblrUserPhoto = "//photo-url";
        public static string TumblrUserVideo = "//video-player";
        public static string TumblrVideoSource = "/video[1]/source[1]";
    }
}
