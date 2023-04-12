using TeamStatistics.DAL;

namespace TeamStatistics.CsvImporter
{
    public interface IStatisticsCsvImporter
    {
        void ImportData(string csvPath, IUnitOfWork unitOfWork);
    }
}
