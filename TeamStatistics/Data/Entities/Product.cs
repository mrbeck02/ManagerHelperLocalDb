﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamStatistics.Data.Entities
{
    public enum ProductEnum
    {
        CARA = 1, CM, CRT, EPMM, PPS, PFS, SMARTonFHIR, AvailabilityAPI, ReferralAPI, Cognito, Launcher, Dynatrace, Other
    };

    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = "";

        #region Relationships

        public virtual ICollection<JiraIssue> JiraIssues { get; set; } = new HashSet<JiraIssue>();

        #endregion
    }
}
