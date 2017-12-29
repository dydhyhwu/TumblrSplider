using System;

namespace DY.Crawler.Domains.interfaces
{
    public interface Taskable
    {
        Guid TaskIdentifier { get; }
        void task_by(Guid task_identifier);
    }
}