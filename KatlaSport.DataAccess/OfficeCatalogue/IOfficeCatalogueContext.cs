namespace KatlaSport.DataAccess.OfficeCatalogue
{
   public interface IOfficeCatalogueContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets the offices.
        /// </summary>
        IEntitySet<Office> Offices { get; }

        /// <summary>
        /// Gets the staf.
        /// </summary>
        IEntitySet<Employee> Staf { get; }

        /// <summary>
        /// Gets the required inventories.
        /// </summary>
        IEntitySet<RequiredInventory> RequiredInventories { get; }
    }
}
