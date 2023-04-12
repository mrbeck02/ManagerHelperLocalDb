using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TeamStatistics.Data;
using TeamStatistics.Data.Entities;

namespace TeamStatistics.DAL
{
    internal class EntryRepository : IEntryRepository, IDisposable
    {
        private DataContext _context;

        public EntryRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Entry> GetEntries()
        {
            return _context.Entries.ToList();
        }

        public Entry GetEntryByID(Guid id)
        {
            return _context.Entries.Find(id);
        }

        public void InsertEntry(Entry entry)
        {
            _context.Entries.Add(entry);
        }

        public void DeleteEntry(Guid entryId)
        {
            var entry = _context.Entries.Find(entryId);

            if (entry != null) 
                _context.Entries.Remove(entry);
        }

        public void UpdateEntry(Entry entry)
        {
            _context.Entry(entry).State = EntityState.Modified;
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
