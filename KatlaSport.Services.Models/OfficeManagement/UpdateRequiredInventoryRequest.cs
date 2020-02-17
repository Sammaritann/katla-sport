namespace KatlaSport.Services.OfficeManagement
{
    /// <summary>
    /// Represents a request for creating and updating a required inventiry.
    /// </summary>
   public class UpdateRequiredInventoryRequest
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the office identifier.
        /// </summary>
        public int OfficeId { get; set; }
    }
}
