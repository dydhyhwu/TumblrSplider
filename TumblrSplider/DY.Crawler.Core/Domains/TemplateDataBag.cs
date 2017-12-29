using System;
using DY.Crawler.Domains.interfaces;

namespace DY.Crawler.Core.Domains
{
    public class TemplateDataBag : Aggregate
    {
        public virtual Guid Identifier { get; set; }
        public virtual string Key { get; set; }
        public virtual int MaxValue { get; set; }
        public virtual int MinValue { get; set; }
    }
}