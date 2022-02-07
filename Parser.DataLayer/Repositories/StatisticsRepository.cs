using Dapper;
using Microsoft.Data.SqlClient;
using Parser.DataLayer.Models;
using System.Data;

namespace Parser.DataLayer.Repositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        public List<WordStatistics> GetStatisitics(int urlId)
        {
            using (var connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                var result = connection.Query<WordStatistics>("[dbo].[GetStatistics]",
                    param: new { urlId = urlId },
                    commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }

        public int? CheckContainsStatistics(string url)
        {
            using (var connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                var result = connection.QueryFirstOrDefault<int?>("[dbo].[Geturl]",
                    param: new { searchUrl = url },
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public int AddUrl(string url)
        {
            using (var connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                var result = connection.QuerySingle<int>("[dbo].[AddUrl]",
                    param: new { addUrl = url },
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public void AddStatistics(WordStatistics wordStatistics, int urlId)
        {
            using (var connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                var result = connection.Execute("[dbo].[AddStatistics]",
                    param: new { urlId = urlId, word = wordStatistics.Word, count = wordStatistics.Count },
                    commandType: CommandType.StoredProcedure);
            }
        }

    }
}
