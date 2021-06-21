using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouApp.Data
{
    public class MonthStat
    {
        public string Category { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public string Region { get; set; }
        public string YearStr { get { return $"{Year} год"; } }
        public int Count { get; set; }
    }
}
