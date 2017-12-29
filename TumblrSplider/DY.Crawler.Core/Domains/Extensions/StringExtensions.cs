using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DY.Crawler.Core.Application.Core.DataAnalysis;
using DY.Crawler.Domains;

namespace DY.Crawler.Core.Domains.Extensions
{
    public static class StringExtensions
    {
        public static IEnumerable<ResourceInfo> load(this string source, IEnumerable<DocumentNodeParseRule> defs)
        {
            var dtos = new ResourceFieldDefAnalysis().on(source).parse(defs);
            var min_fields = dtos.Min(x => x.Nodes.Count);
            return new ResourceFieldDTOAnalysis().on(min_fields).parse(dtos); ;
        }
    }
}
