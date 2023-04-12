using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamStatistics.Data.Entities
{
    public class Sprint
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; } = "";

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        #region Relationships

        public Guid QuarterId { get; set; }

        public virtual Quarter Quarter { get; set; }

        #endregion
    }
}
