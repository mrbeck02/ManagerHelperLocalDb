using System;
using System.ComponentModel.DataAnnotations;

namespace TeamStatistics.Data.Entities
{
    public class JiraSupportIssue
    {
        [Key]
        public Guid Id { get; set; }

        public bool WasInitiallyCommitted { get; set; }

        public DateTime DateCreatedUtc { get; set; }

        public DateTime DateModifiedUtc { get; set; }

        public string TimeZone { get; set; } = "";


        #region Relationships

        public Guid SprintId { get; set; }

        public virtual Sprint Sprint { get; set; }

        public Guid JiraIssueId { get; set; }

        public virtual JiraIssue JiraIssue { get; set; }

        public Guid DeveloperId { get; set; }

        public virtual Developer Developer { get; set; }

        #endregion

    }
}
