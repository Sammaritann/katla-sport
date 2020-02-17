using System.Collections.Generic;

namespace KatlaSport.DataAccess.OfficeCatalogue
{
    /// <summary>
    /// Represents a office model.
    /// </summary>
    public class Office
    {
        /// <summary>
        /// Gets or sets the office identifier.
        /// </summary>
        public int OfficeId { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the staff.
        /// </summary>
        public virtual ICollection<Employee> Staff { get; set; }

        /// <summary>
        /// Gets or sets the inventories.
        /// </summary>
        public virtual ICollection<RequiredInventory> Inventories { get; set; }
    }
}
