namespace KatlaSport.DataAccess.OfficeCatalogue
{
    /// <summary>
    /// Represents a Employee.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets a employee ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a employee name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a employee address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets a employee phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the employee avatar.
        /// </summary>
        public byte[] Avatar { get; set; }

        /// <summary>
        /// Gets or sets the office identifier.
        /// </summary>
        public int OfficeId { get; set; }

        /// <summary>
        /// Gets or sets the office.
        /// </summary>
        public virtual Office Office { get; set; }
    }
}
