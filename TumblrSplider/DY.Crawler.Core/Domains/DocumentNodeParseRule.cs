using System.Collections.Generic;
using DY.Crawler.Domains;
using DY.Crawler.Domains.interfaces;
using HtmlAgilityPack;

namespace DY.Crawler.Core.Domains
{
    public class DocumentNodeParseRule : Nameable
    {
        public virtual string AttributeName { get; set; }
        public virtual string RuleValue { get; set; }
        public virtual string Name { get; set; }
    }
}