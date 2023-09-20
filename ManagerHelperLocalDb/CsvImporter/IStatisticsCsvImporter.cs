using ManagerHelperLocalDb.DAL;
using ManagerHelperLocalDb.Data.Entities;
using System.Collections.Generic;

namespace ManagerHelperLocalDb.CsvImporter
{
    public interface IStatisticsCsvImporter
    {
        void ImportData(List<StatisticsCsvEntry> csvEntries, Developer developer, IUnitOfWork unitOfWork);
    }
}
