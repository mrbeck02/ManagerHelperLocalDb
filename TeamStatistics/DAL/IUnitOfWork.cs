using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamStatistics.Data.Entities;

namespace TeamStatistics.DAL
{
    public interface IUnitOfWork
    {
        GenericRepository<Entry> EntryRepository { get; }
        void Save();
    }
}
