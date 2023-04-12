using CsvHelper;
using System.Globalization;
using System.IO;
using TeamStatistics.DAL;
using TeamStatistics.Data;
using TeamStatistics.Data.Entities;

namespace TeamStatistics.CsvImporter
{
    /// <summary>
    /// Imports the data from CSV into the database
    /// </summary>
    public class StatisticsCsvImporter : IStatisticsCsvImporter
    {
        public void ImportData(string csvPath, IUnitOfWork unitOfWork)
        {
            using (var reader = new StreamReader(csvPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var csvEntries = csv.GetRecords<StatisticsCsvEntry>();

                foreach (var csvEntry in csvEntries) 
                {
                }
            }
        }
    }
}
