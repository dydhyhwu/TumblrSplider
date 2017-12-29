using System.Collections.Generic;
using System.Linq;
using DY.Crawler.Core.Domains;
using DY.Crawler.Core.Domains.DTOs;
using HtmlAgilityPack;

namespace DY.Crawler.Core.Application.Core.DataAnalysis
{
    public class ResourceFieldDefAnalysis
    {
        private HtmlDocument document;
        public ResourceFieldDefAnalysis()
        {
            document = new HtmlDocument();
        }

        public ResourceFieldDefAnalysis on(string content)
        {
            document.LoadHtml(content);
            return this;
        }

        public IEnumerable<ResourceFieldDTO> parse(IEnumerable<DocumentNodeParseRule> data)
        {
            return data.Select(x => new ResourceFieldDTO
                                    {
                                        Def = x,
                                        Nodes = document.DocumentNode.SelectNodes(x.RuleValue),
                                    });
        }
    }
}