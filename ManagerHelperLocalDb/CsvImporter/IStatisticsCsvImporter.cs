using System.Collections.Generic;
using ManagerHelperLocalDb.DAL;
using ManagerHelperLocalDb.Data.Entities;

namespace ManagerHelperLocalDb.CsvImporter
{
    public interface IStatisticsCsvImporter
    {
        void ImportData(List<StatisticsCsvEntry> csvEntries, Developer developer, IUnitOfWork unitOfWork);
    }
}
