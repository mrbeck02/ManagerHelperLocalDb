using System;
using TeamStatistics.Data;
using TeamStatistics.Data.Entities;

namespace TeamStatistics.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DataContext _dataContext;
        private GenericRepository<Entry> _entryRepository;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        GenericRepository<Entry> IUnitOfWork.EntryRepository { get => _entryRepository ??= new GenericRepository<Entry>(_dataContext); }

        public void Save()
        {
            _dataContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}