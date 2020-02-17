using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.OfficeCatalogue
{
    internal sealed class RequiredInventoryConfiguration : EntityTypeConfiguration<RequiredInventory>
    {
        public RequiredInventoryConfiguration()
        {
            HasKey(r => r.Id);
            HasRequired(r => r.Office).WithMany(o => o.Inventories).HasForeignKey(r => r.OfficeId);
            Property(r => r.Name).HasColumnName("required_inventory_name").IsRequired();
            Property(r => r.Id).HasColumnName("required_inventory_id");
            Property(r => r.Number).HasColumnName("required_inventory_chapter_nember").IsRequired();
            Property(r => r.Path).HasColumnName("required_inventory_path").IsRequired();
        }
    }
}
