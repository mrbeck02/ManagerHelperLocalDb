using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TeamStatistics.Data;
using TeamStatistics.Data.Entities;

namespace TeamStatistics.DAL
{
    internal class DeveloperRepository : IDeveloperRepository, IDisposable
    {
        private DataContext _context;

        public DeveloperRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Developer> GetDevelopers()
        {
            return _context.Developers.ToList();
        }

        public Developer GetDeveloperByID(Guid id)
        {
            return _context.Developers.Find(id);
        }

        public void InsertDeveloper(Developer developer)
        {
            _context.Developers.Add(developer);
        }

        public void DeleteDeveloper(Guid developerId)
        {
            var developer = _context.Developers.Find(developerId);

            if (developer != null) 
                _context.Developers.Remove(developer);
        }

        public void UpdateDeveloper(Developer developer)
        {
            _context.Entry(developer).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
