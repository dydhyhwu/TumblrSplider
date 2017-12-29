using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DY.Crawler.Core.Application.Core.Command;
using DY.Crawler.Core.Domains.Extensions;
using DY.Crawler.Domains;

namespace DY.Crawler.Core.Application.Core.Processors
{
    public class ProjectProcessor : ProjectProcessorCommand
    {
        public ProjectProcessor()
        {
            
        }

        public void run(DProject project)
        {
            if (project.UrlTemplate.empty()) return;
            var tasks = project.UrlTemplate.generate();
            tasks.each(x => project.task(x));
        }
    }
}
