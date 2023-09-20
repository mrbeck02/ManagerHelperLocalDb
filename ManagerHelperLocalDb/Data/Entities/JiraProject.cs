using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerHelperLocalDb.Data.Entities
{
    public class JiraProject
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; } = "";

        public string Domain { get; set; } = "";

        public JiraProject()
        {
        }
    }
}
