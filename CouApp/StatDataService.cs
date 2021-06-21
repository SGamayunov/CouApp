using CouApp.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace CouApp
{
    public class StatDataService
    {
        private IDbConnection Db { get; }
        public StatDataService(IDbConnection connection)
        {
            Db = connection;
        }
        public List<MonthStat> GetStat(Month month, Category category)
        {
            string sql = "select a_year as year, a_month as month, sr.name_ru as region, c.name_ru as category, count " +
                         "from " +
                         "   abd.cross_table t, " +
                         "   abd.s_region sr, " +
                         "   abd.s_category c " +
                         "where " +
                         "   t.region_id = sr.id and " +
                         "   t.category_id = c.id and"+
                         "   t.a_month = @pMonth and "+
                         "   t.category_id = @pCategory";
            var result = Db.Query<MonthStat>(sql, new { pMonth = month, pCategoryId = category.Id }).ToList();
            return result;
        }
    }
}
