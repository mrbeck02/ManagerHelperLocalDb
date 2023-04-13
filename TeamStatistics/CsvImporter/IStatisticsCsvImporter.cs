using TeamStatistics.DAL;
using TeamStatistics.Data.Entities;

namespace TeamStatistics.CsvImporter
{
    public interface IStatisticsCsvImporter
    {
        void ImportData(string csvPath, Developer developer, IUnitOfWork unitOfWork);
    }
}
