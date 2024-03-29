﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerHelperLocalDb.Data.Entities
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

        [ForeignKey("Sprint")]
        public Guid SprintId { get; set; }

        public virtual Sprint Sprint { get; set; } = null!;

        [ForeignKey("JiraIssueId")]
        public Guid JiraIssueId { get; set; }

        public virtual JiraIssue JiraIssue { get; set; } = null!;

        [ForeignKey("DeveloperId")]
        public Guid DeveloperId { get; set; }

        public virtual Developer Developer { get; set; } = null!;

        #endregion

    }
}
