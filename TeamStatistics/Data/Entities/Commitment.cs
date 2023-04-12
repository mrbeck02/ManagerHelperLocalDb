using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamStatistics.Data.Entities
{
    public class Commitment
    {
        [Key]
        public Guid Id { get; set; }

        #region Relationships

        public Guid SprintId { get; set; }

        public virtual Sprint Sprint { get; set; }

        #endregion
    }
}
