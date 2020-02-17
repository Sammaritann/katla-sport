namespace KatlaSport.DataAccess.OfficeCatalogue
{
    internal sealed class OfficeCatalogueContext : DomainContextBase<ApplicationDbContext>, IOfficeCatalogueContext
    {
        public OfficeCatalogueContext(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEntitySet<Office> Offices => GetDbSet<Office>();

        public IEntitySet<Employee> Staf => GetDbSet<Employee>();

        public IEntitySet<RequiredInventory> RequiredInventories => GetDbSet<RequiredInventory>();
    }
}
