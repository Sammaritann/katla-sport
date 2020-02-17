namespace KatlaSport.Services.OfficeManagement
{
    /// <summary>
    /// Represents a request for creating and updating a Employee.
    /// </summary>
    public class UpdateEmployeeRequest
    {
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
        /// Gets or sets the avatar.
        /// </summary>
        public byte[] Avatar { get; set; }

        /// <summary>
        /// Gets or sets the office identifier.
        /// </summary>
        public int OfficeId { get; set; }
    }
}
