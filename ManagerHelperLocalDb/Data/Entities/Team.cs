using System.Collections.Generic;

namespace ManagerHelperLocalDb.Data.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        #region Relationships
        public virtual ICollection<Developer> Developers { get; set; } = new List<Developer>();
        #endregion
    }
}
