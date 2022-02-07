using Parser.BusinessLayer.Models;
using Parser.Core;

namespace Parser.BusinessLayer.Services
{
    public interface IHtmlService
    {
        Result<List<WordModel>> GetWordsStatisticsByUrl(string url);
    }
}