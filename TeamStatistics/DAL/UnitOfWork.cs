using System;
using TeamStatistics.Data;
using TeamStatistics.Data.Entities;

namespace TeamStatistics.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DataContext _dataContext;
        private GenericRepository<Commitment> _commitmentRepository;
        private GenericRepository<Entry> _entryRepository;
        private GenericRepository<Developer> _developerRepository;
        private GenericRepository<Quarter> _quarterRepository;
        private GenericRepository<Sprint> _sprintRepository;
        private GenericRepository<JiraIssue> _jiraIssueRepository;
        private GenericRepository<Product> _productRepository;
        private GenericRepository<JiraProject> _jiraProjectRepository;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public GenericRepository<Commitment> CommitmentRepository { get => _commitmentRepository ??= new GenericRepository<Commitment>(_dataContext); }
        public GenericRepository<Entry> EntryRepository { get => _entryRepository ??= new GenericRepository<Entry>(_dataContext); }

        public GenericRepository<Developer> DeveloperRepository { get => _developerRepository ??= new GenericRepository<Developer>(_dataContext); }

        public GenericRepository<Quarter> QuarterRepository { get => _quarterRepository ??= new GenericRepository<Quarter>(_dataContext); }

        public GenericRepository<Sprint> SprintRepository { get => _sprintRepository ??= new GenericRepository<Sprint>(_dataContext); }

        public GenericRepository<JiraIssue> JiraIssueRepository { get => _jiraIssueRepository ??= new GenericRepository<JiraIssue>(_dataContext); }

        public GenericRepository<Product> ProductRepository { get => _productRepository ??= new GenericRepository<Product>(_dataContext); }

        public GenericRepository<JiraProject> JiraProductRepository { get => _jiraProjectRepository ??= new GenericRepository<JiraProject>(_dataContext); }

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