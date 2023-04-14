using System.Collections.Generic;
using TeamStatistics.DAL;
using TeamStatistics.Data.Entities;

namespace TeamStatistics.CsvImporter
{
    public interface IStatisticsCsvImporter
    {
        void ImportData(List<StatisticsCsvEntry> csvEntries, Developer developer, IUnitOfWork unitOfWork);
    }
}
