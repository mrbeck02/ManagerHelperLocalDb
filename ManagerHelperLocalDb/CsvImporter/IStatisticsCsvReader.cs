using System.Collections.Generic;

namespace ManagerHelperLocalDb.CsvImporter
{
    public interface IStatisticsCsvReader
    {
        List<StatisticsCsvEntry> ReadStatistics(string csvPath);
    }
}
