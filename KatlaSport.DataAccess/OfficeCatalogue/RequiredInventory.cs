namespace KatlaSport.DataAccess.OfficeCatalogue
{
    /// <summary>
    /// Represents a required inventory.
    /// </summary>
    public class RequiredInventory
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
        /// Gets or sets the number.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        public string Path { get; set; }

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
