using System.Collections.Generic;
using DY.Crawler.Core.Application.Core.Processors;
using DY.Crawler.Core.Domains.DTOs;
using DY.Crawler.Core.Domains.Extensions;
using DY.Crawler.Domains;

namespace DY.Crawler.Core.Application.Core.DataAnalysis
{
    public class ResourceFieldDTOAnalysis
    {
        private int length;

        public ResourceFieldDTOAnalysis()
        {
            
        }

        public ResourceFieldDTOAnalysis on(int len)
        {
            this.length = len;
            return this;
        }

        public IEnumerable<ResourceInfo> parse(IEnumerable<ResourceFieldDTO> data)
        {
            var list = new List<ResourceInfo>();
            0.to(length - 1)
             .each(index =>
                   {
                       var item = new ResourceFieldDTOToInfoAnalysis().on(index).parse(data);
                       list.Add(item);
                   });
            return list;
        }
    }
}