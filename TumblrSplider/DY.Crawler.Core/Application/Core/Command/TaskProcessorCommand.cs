using DY.Crawler.Domains;

namespace DY.Crawler.Core.Application.Core.Command
{
    public interface TaskProcessorCommand
    {
        void run(DTask task);
    }

    public interface ProjectProcessorCommand
    {
        void run(DProject project);
    }
}