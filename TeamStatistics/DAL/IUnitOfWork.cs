using TeamStatistics.Data.Entities;

namespace TeamStatistics.DAL
{
    public interface IUnitOfWork
    {
        GenericRepository<Commitment> CommitmentRepository { get; }
        GenericRepository<Entry> EntryRepository { get; }
        GenericRepository<Developer> DeveloperRepository { get; }

        GenericRepository<Quarter> QuarterRepository { get; }

        GenericRepository<Sprint> SprintRepository { get; }

        GenericRepository<JiraIssue> JiraIssueRepository { get; }

        GenericRepository<Product> ProductRepository { get; }

        GenericRepository<JiraProject> JiraProductRepository { get; }

        void Save();
    }
}
