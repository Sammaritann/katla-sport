using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.OfficeCatalogue
{
    internal sealed class OfficeConfiguration : EntityTypeConfiguration<Office>
    {
        public OfficeConfiguration()
        {
            HasKey(o => o.OfficeId);

            Property(o => o.Code).IsRequired().HasColumnName("office_code");
            Property(o => o.Address).IsRequired().HasColumnName("office_address");
            Property(o => o.OfficeId).IsRequired().HasColumnName("office_id");
        }
    }
}
