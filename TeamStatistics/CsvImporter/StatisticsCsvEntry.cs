using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamStatistics.CsvImporter
{
    public class StatisticsCsvEntry
    {
        public DateTime Date { get; set; }
        public string Sprint { get; set; }
        public string Quarter { get; set; }
        public string Jira { get; set; }
        public string Prod { get; set; }
        public string Include { get; set; }
        public int? SP { get; set; }

        public string Day1 { get; set; }
        public string Day2 { get; set; }
        public string Day3 { get; set; }
        public string Day4 { get; set; }
        public string Day5 { get; set; }
        public string Day6 { get; set; }
        public string Day7 { get; set; }
        public string Day8 { get; set; }
        public string Day9 { get; set; }
        public string Day10 { get; set; }

        public int Done { get; set; }

        public string Rollover { get; set; }
    }
}
