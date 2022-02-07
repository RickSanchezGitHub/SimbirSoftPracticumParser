using HtmlAgilityPack;
using NLog;
using Parser.BusinessLayer.Configuration;
using Parser.BusinessLayer.Models;
using Parser.Core;
using Parser.Core.Enum;
using Parser.DataLayer.Models;
using Parser.DataLayer.Repositories;
using System.Text.RegularExpressions;

namespace Parser.BusinessLayer.Services
{
    public class HtmlService : IHtmlService
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly IStatisticsRepository _repository = new StatisticsRepository();

        /// <summary>
        /// Получает всю статистику
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Result<List<WordModel>> GetWordsStatisticsByUrl(string url)
        {
            List<WordStatistics> statistics;

            if (!IsUrl(url))
            {
                _logger.Error("Не соответствует шаблону url");
                return new Result<List<WordModel>>(0,"введите адрес, соотвествующий шаблону");
            }

            int? urlId = _repository.CheckContainsStatistics(url);

            if (urlId != null)
            {
                _logger.Info("В бд уже есть такая url " + url);

                statistics = _repository.GetStatisitics(urlId.Value);

                var entity = new Result<List<WordModel>>(Status.ok, CustomMapper.GetInstance().Map<List<WordModel>>(statistics));

                return entity;
            }

            var htmlContent = GetHtmlCodeByUrl(url);

            statistics = ParserService.GetWordsStatisitics(htmlContent);

            urlId = _repository.AddUrl(url);

            foreach (var item in statistics)
            {
                _repository.AddStatistics(item, urlId.Value);
            }

            var result = new Result<List<WordModel>>(Status.ok,CustomMapper.GetInstance().Map<List<WordModel>>(statistics));

            return result;
        }

        /// <summary>
        /// Соответствует-ли ссылка url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsUrl(string url)
            => new Regex(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)")
            .IsMatch(url);

        /// <summary>
        /// Получает HTML-код
        /// </summary>
        /// <param name="url">URL-адрес сайта</param>
        /// <returns></returns>
        private HtmlDocument GetHtmlCodeByUrl(string url)
        {
            HtmlDocument result;
            var htmlWeb = new HtmlWeb();

            try
            {
                htmlWeb.OverrideEncoding = System.Text.Encoding.UTF8;
                result = htmlWeb.Load(url);
                _logger.Info("Стрвница успешно получена");
                return result;
            }
            catch (Exception ex)
            {
                _logger.Error("Не удалось получить страницу");
                throw new Exception();
            }
        }
    }
}
