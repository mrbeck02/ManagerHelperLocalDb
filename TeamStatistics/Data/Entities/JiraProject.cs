using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamStatistics.Data.Entities
{
    public class JiraProject
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; } = "";

        public string Domain { get; set; } = "";
    }
}
