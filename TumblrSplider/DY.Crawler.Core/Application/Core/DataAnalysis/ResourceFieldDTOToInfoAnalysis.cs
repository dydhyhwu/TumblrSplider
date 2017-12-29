using System.Collections.Generic;
using System.Linq;
using DY.Crawler.Core.Application.Core.Processors;
using DY.Crawler.Core.Domains.DTOs;
using DY.Crawler.Core.Domains.Extensions;
using DY.Crawler.Domains;

namespace DY.Crawler.Core.Application.Core.DataAnalysis
{
    public class ResourceFieldDTOToInfoAnalysis
    {
        private int node_index;

        public ResourceFieldDTOToInfoAnalysis()
        {
            
        }

        public ResourceFieldDTOToInfoAnalysis on(int index)
        {
            this.node_index = index;
            return this;
        }

        public ResourceInfo parse(IEnumerable<ResourceFieldDTO> data)
        {
            var info = new ResourceInfo();
            data.each(x =>
                      {
                          var field = new DocumentNodeAnalysis().on(node_index).parse(x);
                          info.field(field);
                      });
            return info;
        }
    }
}