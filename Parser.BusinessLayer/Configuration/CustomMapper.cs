using AutoMapper;
using Parser.BusinessLayer.Models;
using Parser.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.BusinessLayer.Configuration
{
    public class CustomMapper
    {
        private static Mapper _instance;

        public static Mapper GetInstance()
        {
            if (_instance == null)
            {
                InitCustomMapper();
            }
            return _instance;
        }

        public static void InitCustomMapper()
        {
            _instance = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<WordStatistics, WordModel>();

            }));
        }
    }
}
