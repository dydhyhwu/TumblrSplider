using System;
using System.Collections.Generic;
using DY.Crawler.Domains.interfaces;

namespace DY.Crawler.Core.Domains
{
    public class DSite : Aggregate, Nameable
    {
        public virtual Guid Identifier { get; set; }

        public virtual string Name { get; set; }

        public virtual string Uri { get; set; }

        public virtual string Host { get; set; }

        public virtual IDictionary<string, string> Headers { get; set; }

        public virtual string Url
        {
            get { return $"{Host}{Uri}"; }
        }
    }
}