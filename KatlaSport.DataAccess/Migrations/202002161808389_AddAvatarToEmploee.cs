using System.Data.Entity.Migrations;

namespace KatlaSport.DataAccess.Migrations
{
    public partial class AddAvatarToEmploee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.employee_records", "employee_avatar", c => c.Binary());
        }

        public override void Down()
        {
            DropColumn("dbo.employee_records", "employee_avatar");
        }
    }
}
