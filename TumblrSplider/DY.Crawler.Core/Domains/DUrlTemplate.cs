using System;
using System.Collections.Generic;
using DY.Crawler.Domains.interfaces;

namespace DY.Crawler.Core.Domains
{
    public class DUrlTemplate : Aggregate
    {
        public virtual Guid Identifier { get; set; }
        public virtual string Url { get; set; }
        public virtual string Host { get; set; }
        public virtual TemplateDataBag DataBag { get; set; }
    }
}