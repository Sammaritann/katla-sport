namespace KatlaSport.Services.OfficeManagement
{
    /// <summary>
    /// Represents  a required inventiry.
    /// </summary>
   public class RequiredInventoryItem
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public int Id { get; set; }

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
