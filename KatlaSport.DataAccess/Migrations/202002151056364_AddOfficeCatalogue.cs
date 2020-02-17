namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddOfficeCatalogue : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.employee_records",
                c => new
                    {
                        employee_id = c.Int(nullable: false, identity: true),
                        employee_name = c.String(nullable: false),
                        employee_address = c.String(nullable: false),
                        employee_phone = c.String(nullable: false),
                        OfficeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.employee_id)
                .ForeignKey("dbo.Offices", t => t.OfficeId, cascadeDelete: true)
                .Index(t => t.OfficeId);

            CreateTable(
                "dbo.Offices",
                c => new
                    {
                        office_id = c.Int(nullable: false, identity: true),
                        office_code = c.String(nullable: false),
                        office_address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.office_id);

            CreateTable(
                "dbo.RequiredInventories",
                c => new
                    {
                        required_inventory_id = c.Int(nullable: false, identity: true),
                        required_inventory_name = c.String(nullable: false),
                        OfficeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.required_inventory_id)
                .ForeignKey("dbo.Offices", t => t.OfficeId, cascadeDelete: true)
                .Index(t => t.OfficeId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.employee_records", "OfficeId", "dbo.Offices");
            DropForeignKey("dbo.RequiredInventories", "OfficeId", "dbo.Offices");
            DropIndex("dbo.RequiredInventories", new[] { "OfficeId" });
            DropIndex("dbo.employee_records", new[] { "OfficeId" });
            DropTable("dbo.RequiredInventories");
            DropTable("dbo.Offices");
            DropTable("dbo.employee_records");
        }
    }
}
