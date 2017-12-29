namespace DY.Crawler.Domains.interfaces
{
    public interface Crawlerable
    {
        string Url { get; set; }
        void init(string uri);
    }
}