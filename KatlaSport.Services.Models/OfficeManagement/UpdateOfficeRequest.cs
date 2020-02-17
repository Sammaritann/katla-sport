namespace KatlaSport.Services.OfficeManagement
{
    /// <summary>
    /// Represents a request for creating and updating a office.
    /// </summary>
    public class UpdateOfficeRequest
    {
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
