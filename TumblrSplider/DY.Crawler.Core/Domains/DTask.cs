using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DY.Crawler.Core.Domains;
using DY.Crawler.Core.Domains.Extensions;
using DY.Crawler.Domains.Enums;
using DY.Crawler.Domains.interfaces;
using DY.Crawler.Domains.Interfaces;

namespace DY.Crawler.Domains
{
    public class DTask : Aggregate, Nameable, Taskable, Recordable, Projectable, Phaseable
    {
        public DTask()
        {
            rules = new List<DocumentNodeParseRule>();
            results = new List<ResourceInfo>();
            sites = new List<DSite>();
        }

        private IList<DocumentNodeParseRule> rules { get; set; }
        private IList<DSite> sites { get; set; }
        private IList<ResourceInfo> results { get; set; }
        public virtual Guid Identifier { get; set; }
        public virtual string Name { get; set; }
        public virtual Guid TaskIdentifier { get; protected set; }
        public virtual Guid ProjectIdentifier { get; protected set; }
        public virtual DateTime RecordTime { get; set; }
        public virtual Phase Phase { set; get; }
        public virtual Account Account { get; set; }

        public virtual IEnumerable<DSite> Sites
        {
            get { return sites; }
        }

        public virtual IEnumerable<DocumentNodeParseRule> Rules
        {
            get { return rules; }
        }

        public virtual IEnumerable<ResourceInfo> Results
        {
            get { return results; }
        }


        public virtual DTask init(DSite site)
        {
            sites.Add(site);
            return this;
        }

        public virtual DTask result(ResourceInfo info)
        {
            info.task_by(Identifier);
            results.Add(info);
            return this;
        }

        public virtual DTask def(DocumentNodeParseRule def)
        {
            rules.Add(def);
            return this;
        }

        public virtual void task_by(Guid task_identifier)
        {
            TaskIdentifier = task_identifier;
        }

        public virtual void project_by(Guid project_identifier)
        {
            ProjectIdentifier = project_identifier;
        }
    }
}
