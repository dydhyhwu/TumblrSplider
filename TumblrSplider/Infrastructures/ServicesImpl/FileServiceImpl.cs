using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DY.Crawler.Core.Domains.Extensions;
using TumblrSplider.Domains;
using TumblrSplider.Infrastructures.Services;

namespace TumblrSplider.Infrastructures.ServicesImpl
{
    public class FileServiceImpl : FileService
    {
        private HttpClient client;

        public FileServiceImpl(HttpClient client)
        {
            this.client = client;
        }
        public bool Download(string url, string root_path)
        {
            try
            {
                var stream = client.GetStreamAsync(url).Result;
                var path = root_path + "/" + url.Split('/').Last();
                Save(stream, path);
                stream.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(Stream stream, string path)
        {
            using (var file_stream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                var buffers = new byte[102400];
                var len = 1;
                while (len > 0)
                {
                    len = stream.Read(buffers, 0, 102400);
                    file_stream.Write(buffers, 0, len);
                }
            }
            return true;
        }

        public bool Save(TumblrResource resource, string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            using (var writer = new StreamWriter(path + "/result.txt"))
            {
                resource.Photos.each(x => writer.WriteLine(x));
                resource.Videos.each(x => writer.WriteLine(x));
            }
            return true;
        }

        public bool DownloadByUrls(IEnumerable<string> urls, string user_name, string sub_dir)
        {
            var path = String.Format("./Data/{0}/{1}", user_name, sub_dir);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            urls.each(x => Download(x, path));
            return true;
        }
    }
}
