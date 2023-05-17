using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamStatistics.Data.Entities
{
    public class JiraIssueProduct
    {
        public Guid JiraIssueId { get; set; }

        public JiraIssue JiraIssue { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
