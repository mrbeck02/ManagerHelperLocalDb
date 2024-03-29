﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerHelperLocalDb.Data.Entities
{
    public class JiraIssue
    {
        [Key]
        public Guid Id { get; set; }

        public string? Number { get; set; }

        public int StoryPoints { get; set; }

        public bool IsRegressionBug { get; set; }

        public DateTime DateCreatedUtc { get; set; }

        public DateTime DateModifiedUtc { get; set; }

        public string? TimeZone { get; set; }

        #region Relationships

        [ForeignKey("JiraProject")]
        public Guid JiraProjectId { get; set; }

        public virtual JiraProject JiraProject { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        #endregion
    }
}
