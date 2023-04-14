using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamStatistics.CsvImporter
{
    public interface IStatisticsCsvReader
    {
        List<StatisticsCsvEntry> ReadStatistics(string csvPath);
    }
}
