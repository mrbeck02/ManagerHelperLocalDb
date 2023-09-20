using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerHelperLocalDb.Data.Entities
{
    public class Commitment
    {
        [Key]
        public Guid Id { get; set; }

        public bool DidComplete { get; set; }

        public bool IncludeInData { get; set; }

        public bool WasInitiallyCommitted { get; set; }

        public string? Notes { get; set; }

        public DateTime DateCreatedUtc { get; set; }

        public DateTime DateModifiedUtc { get; set; }

        public string? TimeZone { get; set; }


        #region Relationships

        [ForeignKey("Sprint")]
        public Guid SprintId { get; set; }

        public virtual Sprint Sprint { get; set; } = null!; // these can be null if we use laze loading

        [ForeignKey("JiraIssue")]
        public Guid JiraIssueId { get; set; }

        public virtual JiraIssue JiraIssue { get; set; } = null!;

        [ForeignKey("Developer")]
        public Guid DeveloperId { get; set; }

        public virtual Developer Developer { get; set; } = null!;

        #endregion
    }
}
