using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.DataLayer.Models
{
    public class WordStatistics 
    {
        public int Id { get; set; }

        public string Word { get; set; }

        public int Count { get; set; }


        /// <summary>
        /// Для теста переопределила метод сравнения объектов
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            var wordStat = obj as WordStatistics;

            if (wordStat == null)
            {
                return false;
            }

            if (Count != wordStat.Count || Word != wordStat.Word)
            {
                return false;
            }

            return true;
        }
    }
}
