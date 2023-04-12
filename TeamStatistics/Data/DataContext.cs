using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamStatistics.Data.Entities;

namespace TeamStatistics.Data
{
    public class DataContext : DbContext
    {
        public DbSet<IssueStatus> IssueStatuses { get; set; }
        public DbSet<Quarter> Quarters { get; set; }
        public DbSet<Sprint> Sprints { get; set; }

        public DbSet<Developer> Developers { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=c:\\Temp\\mydb.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IssueStatus>().HasData(
                    new IssueStatus {  Id = (int)IssueStatusEnum.inprogress, Name = "In Progress" },
                    new IssueStatus { Id = (int)IssueStatusEnum.open, Name = "Open" },
                    new IssueStatus { Id = (int)IssueStatusEnum.readyforrelease, Name = "Ready for Release" },
                    new IssueStatus { Id = (int)IssueStatusEnum.readyfortest, Name = "Ready for Test" },
                    new IssueStatus { Id = (int)IssueStatusEnum.intest, Name = "In Test" },
                    new IssueStatus { Id = (int)IssueStatusEnum.done, Name = "Done" },
                    new IssueStatus { Id = (int)IssueStatusEnum.todo, Name = "To Do" }
                    );

        }
    }
}
