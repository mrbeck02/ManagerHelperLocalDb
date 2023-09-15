using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagerHelperLocalDb.Data.Entities
{
    public class Developer
    {
        [Key]
        public Guid Id { get; set; }

        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public DateTime DateCreatedUtc { get; set; }

        public DateTime DateModifiedUtc { get; set; }

        public string TimeZone { get; set; } = "";

        #region Relationships

        public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

        #endregion

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
