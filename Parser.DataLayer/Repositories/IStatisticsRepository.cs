using Parser.DataLayer.Models;

namespace Parser.DataLayer.Repositories
{
    public interface IStatisticsRepository
    {
        void AddStatistics(WordStatistics wordStatistics, int urlId);
        int AddUrl(string url);
        int? CheckContainsStatistics(string url);
        List<WordStatistics> GetStatisitics(int urlId);
    }
}