using Microsoft.EntityFrameworkCore;
using System;
using TeamStatistics.CsvImporter;
using TeamStatistics.DAL;
using TeamStatistics.Data;
using TeamStatistics.ViewModels.Support;

namespace TeamStatistics.ViewModels
{
    public class MainViewModel : PropertyChangedNotifier, IMainViewModel, IDisposable
    {
        private IStatisticsCsvImporter _statisticsCsvImporter;
        private IDbContextFactory<DataContext> _contextFactory;
        private string _csvPath = @"C:\Temp";

        public string CsvPath
        {
            get => _csvPath;
            set
            {
                if (string.CompareOrdinal(_csvPath, value) == 0)
                    return;

                _csvPath = value;
                OnPropertyChanged(nameof(CsvPath));
            }
        }

        #region Commands

        public RelayCommand _importCsvCommand;
        private bool disposedValue;

        public RelayCommand ImportCsvCommand => _importCsvCommand ??= new RelayCommand(importCsvCommand);

        private void importCsvCommand(object obj)
        {
            _statisticsCsvImporter.ImportData(CsvPath, new UnitOfWork(_contextFactory.CreateDbContext()));
        }

        #endregion

        public MainViewModel(IDbContextFactory<DataContext> contextFactory, 
            IStatisticsCsvImporter statisticsCsvImporter)
        {
            _statisticsCsvImporter = statisticsCsvImporter;
            _contextFactory = contextFactory;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
