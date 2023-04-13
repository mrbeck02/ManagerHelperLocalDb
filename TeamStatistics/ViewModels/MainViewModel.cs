using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TeamStatistics.CsvImporter;
using TeamStatistics.DAL;
using TeamStatistics.Data;
using TeamStatistics.Data.Entities;
using TeamStatistics.ViewModels.Support;

namespace TeamStatistics.ViewModels
{
    public class MainViewModel : PropertyChangedNotifier, IMainViewModel, IDisposable
    {
        private IStatisticsCsvImporter _statisticsCsvImporter;
        private IDbContextFactory<DataContext> _contextFactory;

        #region Properties

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

        private ObservableCollection<ComboBoxItemViewModel<Developer>> _developerOptions;
        private ComboBoxItemViewModel<Developer> _selectedDeveloperOption;

        public ObservableCollection<ComboBoxItemViewModel<Developer>> DeveloperOptions
        {
            get => _developerOptions;
            private set
            {
                _developerOptions = value;
                OnPropertyChanged(nameof(DeveloperOptions));
            }
        }

        public ComboBoxItemViewModel<Developer> SelectedDeveloperOption
        {
            get => _selectedDeveloperOption;
            set
            {
                var origValue = _selectedDeveloperOption;

                var montageSelected = false;

                if (_developerOptions.Count > 0)
                {
                    montageSelected = _developerOptions.Any(o => o.IsSelected);
                }

                // if we're setting the developer option to the same developer, skip it.
                if (value != null && _selectedDeveloperOption != null && value.Value == _selectedDeveloperOption.Value && montageSelected)
                    return;


                if (value == null)
                {
                    OnPropertyChanged(nameof(SelectedDeveloperOption));
                    return;
                }

                foreach (var item in _developerOptions)
                {
                    item.IsSelected = false;
                }

                _selectedDeveloperOption = value;
                _selectedDeveloperOption.IsSelected = true;

                OnPropertyChanged(nameof(SelectedDeveloperOption));
            }
        }

        #endregion

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

            initializeViewModel();
        }

        private void initializeViewModel()
        {
            _developerOptions = createDeveloperOptions();

            if (_developerOptions.Count > 0)
            {
                _selectedDeveloperOption = _developerOptions[0];
                _selectedDeveloperOption.IsSelected = true;
            }
        }

        protected ObservableCollection<ComboBoxItemViewModel<Developer>> createDeveloperOptions()
        {
            var unitOfWork = new UnitOfWork(_contextFactory.CreateDbContext());
            var allOptions = new List<ComboBoxItemViewModel<Developer>>();

            var developers = unitOfWork.DeveloperRepository.Get();
            allOptions.AddRange(developers.Select(m => new ComboBoxItemViewModel<Developer>(m, m.GetFullName())));
            allOptions.Sort();

            return new ObservableCollection<ComboBoxItemViewModel<Developer>>(
                allOptions.ToList());
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
