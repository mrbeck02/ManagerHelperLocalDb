using System;
using System.Collections.Generic;
using TeamStatistics.Data.Entities;

namespace TeamStatistics.DAL
{
    public interface IDeveloperRepository : IDisposable
    {
        IEnumerable<Developer> GetDevelopers();
        Developer GetDeveloperByID(Guid developerId);
        void InsertDeveloper(Developer developer);
        void DeleteDeveloper(Guid developerId);
        void UpdateDeveloper(Developer developer);
        void Save();
    }
}
