using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using DY.Crawler.Domains.Enums;
using DY.Crawler.Domains.interfaces;
using DY.Crawler.Domains.Interfaces;

namespace DY.Crawler.Domains
{
    public class ResourceInfo : Aggregate, Nameable, Taskable, Recordable, Phaseable
    {
        public ResourceInfo()
        {
            fields = new List<CustomField>();   
        }

        private IList<CustomField> fields;
        public virtual Guid Identifier { get; set; }
        public virtual string Name { get; set; }
        public virtual Guid TaskIdentifier { get; protected set; }
        public DateTime RecordTime { get; set; }
        public virtual Phase Phase { get; set; }


        public virtual IEnumerable<CustomField> Fields
        {
            get { return fields; }
            protected set { fields = new List<CustomField>(value); }
        }

        public virtual void task_by(Guid task_identifier)
        {
            TaskIdentifier = task_identifier;
        }

        public virtual ResourceInfo field(CustomField field)
        {
            fields.Add(field);
            return this;
        }
    }
}
