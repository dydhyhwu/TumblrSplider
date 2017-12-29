using System;

namespace DY.Crawler.Domains.interfaces
{
    public interface Projectable
    {
        Guid ProjectIdentifier { get; }
        void project_by(Guid project_identifier);
    }
}