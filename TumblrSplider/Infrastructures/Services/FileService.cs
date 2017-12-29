using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumblrSplider.Domains;

namespace TumblrSplider.Infrastructures.Services
{
    public interface FileService
    {
        bool Download(string url, string root_path);
        bool Save(Stream stream, string path);
        bool Save(TumblrResource resource, string path);
        bool DownloadByUrls(IEnumerable<string> urls, string user_name, string sub_dir);
    }
}
