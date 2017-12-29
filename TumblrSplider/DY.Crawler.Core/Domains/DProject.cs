using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DY.Crawler.Core.Domains;
using DY.Crawler.Domains.enums;
using DY.Crawler.Domains.Enums;
using DY.Crawler.Domains.interfaces;
using DY.Crawler.Domains.Interfaces;

namespace DY.Crawler.Domains
{
    public class DProject : Aggregate, Nameable, Recordable, Phaseable
    {
        public DProject()
        {
            tasks = new List<DTask>();
        }
        private IList<DTask> tasks { get; set; }
        public virtual Guid Identifier { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime RecordTime { get; set; }
        public virtual ProjectType Type { get; set; }
        public virtual Phase Phase { get; set; }
        public virtual DUrlTemplate UrlTemplate { get; set; }

        public virtual IEnumerable<DTask> Tasks
        {
            get { return tasks; }
        }

        public virtual void task(DTask task)
        {
            task.project_by(Identifier);
            tasks.Add(task);
        }
    }
}
