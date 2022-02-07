using HtmlAgilityPack;
using Parser.DataLayer.Models;
using System.Text.RegularExpressions;

namespace Parser.BusinessLayer.Services
{
    public static class ParserService
    {
        public static List<WordStatistics> GetWordsStatisitics(HtmlDocument htmlDocument)
        {

            List<WordStatistics> result;
            
            var content = new List<string>();

            IEnumerable<HtmlNode> nodes = htmlDocument.DocumentNode.Descendants().Where(n =>
                     n.NodeType == HtmlNodeType.Text &&
                     n.ParentNode.Name != "script" &&
                     n.ParentNode.Name != "style");

            foreach (var node in nodes)
            {
                GetContent(node, content);
            }

            var words = GetWords(content);

            result = GetStatistics(words);

            return result;
        }

        /// <summary>
        /// Получает весь текст
        /// </summary>
        /// <param name="htmlNodes"></param>
        /// <param name="words"></param>
        private static void GetContent(HtmlNode htmlNodes, List<string> words)
        {
            if (htmlNodes.ChildNodes.Count == 0)
            {
                if (htmlNodes.InnerText.IsNormalized()
                    && !string.IsNullOrWhiteSpace(htmlNodes.InnerText)
                    && !htmlNodes.XPath.Contains("script"))
                    words.Add(htmlNodes.InnerText.Normalize());
                return;
            }

            foreach (var childNode in htmlNodes.ChildNodes)
                GetContent(childNode, words);
        }

        /// <summary>
        ///  Получает сами слова
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static List<string> GetWords(List<string> text)
        {
            var words = new List<string>();
            foreach (var line in text)
            {
                var cleanLine = line
                    .ToLowerInvariant()
                    .Split(new char[] { ',', ';', ':', '!', '?', '.' });
                foreach (var word in cleanLine)
                {
                    var clearWord = word
                    .Trim(new char[] { ',', ';', ':', '!', '?', '\"', '\'',
                        '(', ')', '}', '{', '[', ']', '\t', '\n', '\\' });
                    var setWords = clearWord
                        .Split(' ');
                    BuildWord(words, setWords);
                }
            }
            return words;
        }

        /// <summary>
        /// Формирует само слово
        /// </summary>
        /// <param name="words"></param>
        /// <param name="setWords"></param>
        private static void BuildWord(List<string> words, string[] setWords)
        {
            foreach (var setSymbol in setWords)
            {
                string word = "";
                for (int i = 0; i < setSymbol.Length; i++)
                {
                    if (char.IsLetter(setSymbol[i]))
                        word += setSymbol[i];
                    else if (word.Length > 0
                        && '-'.Equals(setSymbol[i])
                        && i + 1 < setSymbol.Length
                        && char.IsLetter(setSymbol[i + 1]))
                        word += setSymbol[i];
                }
                if (!string.IsNullOrWhiteSpace(word))
                    words.Add(word.ToLowerInvariant());
            }
        }

        /// <summary>
        /// Получает статистику
        /// <returns></returns>
        private static List<WordStatistics> GetStatistics(List<string> words)
        {
            var statistics = new Dictionary<string, int>();
            var result = new List<WordStatistics>();

            foreach (var word in words)
            {
                if (statistics.ContainsKey(word))
                    statistics[word]++;
                else
                    statistics.Add(word, 1);
            }

            foreach (var elem in statistics)
                result.Add(new WordStatistics{ Word = elem.Key, Count = elem.Value});
            return result;
        }

    }
}
