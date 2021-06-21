using CouApp.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace CouApp
{
    public class DictionaryService
    {
        private IDbConnection DbConnection { get; }
        public DictionaryService(IDbConnection dbConnection)
        {
            DbConnection = dbConnection;

            _regions = DbConnection.Query<Region>("select id as code, name_ru as name from abd.s_region where st_city=1 and st_view=1").ToList();
            _categories = DbConnection.Query<Category>("select id, code, name_ru as name from abd.s_category").ToList();
        }

        public List<Month> Months { get
            {
                return new List<Month>() 
                { 
                    new Month() { Id = 1, Name = "Январь" },
                    new Month() { Id = 2, Name = "Февраль" },
                    new Month() { Id = 3, Name = "Март" },
                    new Month() { Id = 4, Name = "Апрель" },
                    new Month() { Id = 5, Name = "Май" },
                    new Month() { Id = 6, Name = "Июнь" },
                    new Month() { Id = 7, Name = "Июль" },
                    new Month() { Id = 8, Name = "Август" },
                    new Month() { Id = 9, Name = "Сентябрь" },
                    new Month() { Id = 10, Name = "Октябрь" },
                    new Month() { Id = 11, Name = "Ноябрь" },
                    new Month() { Id = 12, Name = "Декабрь" }
                };
            }
        }

        private List<Region> _regions;

        public List<Region> Regions { get => _regions; }

        private List<Category> _categories;
        public List<Category> Categories { get => _categories; }

    }
}
