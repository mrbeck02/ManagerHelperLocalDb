using System;
using System.Collections.Generic;
using TeamStatistics.Data.Entities;

namespace TeamStatistics.DAL
{
    public interface IEntryRepository : IDisposable
    {
        IEnumerable<Entry> GetEntries();
        Entry GetEntryByID(Guid entryId);
        void InsertEntry(Entry entry);
        void DeleteEntry(Guid entryId);
        void UpdateEntry(Entry entry);
        void Save();
    }
}
