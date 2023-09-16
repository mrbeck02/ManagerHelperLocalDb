using System;

namespace ManagerHelperLocalDb.CsvImporter
{
    public class StatisticsCsvSupport
    {
        public DateTime Date { get; set; }
        public string Quarter { get; set; } = string.Empty;
        public string Sprint { get; set; } = string.Empty;
        public int Count { get; set; }

        public string JiraIssues { get; set; } = string.Empty;
    }
}
