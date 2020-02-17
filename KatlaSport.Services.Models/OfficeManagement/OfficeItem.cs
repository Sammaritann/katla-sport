namespace KatlaSport.Services.OfficeManagement
{
    /// <summary>
    /// Represents  a office.
    /// </summary>
    public class OfficeItem
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
    }
}
