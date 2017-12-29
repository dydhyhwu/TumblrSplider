using System.Linq;
using DY.Crawler.Core.Domains.DTOs;
using DY.Crawler.Domains;

namespace DY.Crawler.Core.Application.Core.DataAnalysis
{
    public class DocumentNodeAnalysis
    {
        private int node_index;

        public DocumentNodeAnalysis()
        {
            
        }

        public DocumentNodeAnalysis on(int index)
        {
            this.node_index = index;
            return this;
        }

        public CustomField parse(ResourceFieldDTO data)
        {
            var node = data.Nodes.ElementAt(node_index);
            var attribute_value = string.Empty;
            if (data.Def.AttributeName == "content")
            {
                attribute_value = node.InnerHtml;
            }
            else
            {
                attribute_value = node.GetAttributeValue(data.Def.AttributeName, "");
            }
            return new CustomField()
                   {
                       FieldDef = data.Def,
                       Value = attribute_value,
                       Name = data.Def.Name,
                   };
        }
    }
}