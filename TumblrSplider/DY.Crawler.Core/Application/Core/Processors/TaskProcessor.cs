using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using DY.Crawler.Core.Application.Core.Command;
using DY.Crawler.Core.Application.Core.DataAnalysis;
using DY.Crawler.Core.Domains.Extensions;
using DY.Crawler.Domains;
using HtmlAgilityPack;

namespace DY.Crawler.Core.Application.Core.Processors
{
    public class TaskProcessor : TaskProcessorCommand
    {
        private HttpClient client;

        public TaskProcessor()
        {
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            client = new HttpClient(handler);
        }
        public void run(DTask task)
        {
            task
                .Sites
                .Select(x => x.Url)
                .Select(x => x.get_content(client))
                .SelectMany(x => x.load(task.Rules))
                .each(x => task.result(x));
        }
    }
}
