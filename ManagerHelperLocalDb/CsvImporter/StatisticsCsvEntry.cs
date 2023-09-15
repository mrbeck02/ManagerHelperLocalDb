using System;

namespace ManagerHelperLocalDb.CsvImporter
{
    public class StatisticsCsvEntry
    {
        public DateTime Date { get; set; }
        public string Sprint { get; set; } = string.Empty;
        public string Quarter { get; set; } = string.Empty;
        public string Jira { get; set; } = string.Empty;
        public string Prod { get; set; } = string.Empty;
        public string Include { get; set; } = string.Empty;
        public int? SP { get; set; }

        public string Day1 { get; set; } = string.Empty;
        public string Day2 { get; set; } = string.Empty;
        public string Day3 { get; set; } = string.Empty;
        public string Day4 { get; set; } = string.Empty;
        public string Day5 { get; set; } = string.Empty;
        public string Day6 { get; set; } = string.Empty;
        public string Day7 { get; set; } = string.Empty;
        public string Day8 { get; set; } = string.Empty;
        public string Day9 { get; set; } = string.Empty;
        public string Day10 { get; set; } = string.Empty;

        public int? Done { get; set; }

        public string Rollover { get; set; } = string.Empty;

        public string Notes { get; set; } = string.Empty;
    }
}
