using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamStatistics.CsvImporter
{
    public class StatisticsCsvSupport
    {
        public DateTime Date { get; set; }
        public string Quarter { get; set; }
        public string Sprint { get; set; }
        public int Count { get; set; }

        public string JiraIssues { get; set; }
    }
}
