using DY.Crawler.Domains.interfaces;

namespace DY.Crawler.Core.Domains
{
    public class AccountData : Nameable
    {
        public virtual string Name { get; set; }
        public virtual string Value { get; set; }
    }
}