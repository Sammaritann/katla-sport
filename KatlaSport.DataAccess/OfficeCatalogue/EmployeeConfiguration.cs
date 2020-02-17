using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.OfficeCatalogue
{
   internal sealed class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            ToTable("employee_records");
            HasKey(i => i.Id);
            HasRequired(i => i.Office).WithMany(o => o.Staff).HasForeignKey(e => e.OfficeId);
            Property(i => i.Id).HasColumnName("employee_id");
            Property(i => i.Name).HasColumnName("employee_name").IsRequired();
            Property(i => i.Address).HasColumnName("employee_address").IsRequired();
            Property(i => i.Phone).HasColumnName("employee_phone").IsRequired();
            Property(i => i.Avatar).HasColumnName("employee_avatar").IsOptional();
        }
    }
}
