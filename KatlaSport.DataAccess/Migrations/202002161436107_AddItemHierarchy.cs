using System.Data.Entity.Migrations;

namespace KatlaSport.DataAccess.Migrations
{
    public partial class AddItemHierarchy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RequiredInventories", "required_inventory_chapter_nember", c => c.Int(nullable: false));
            AddColumn("dbo.RequiredInventories", "required_inventory_path", c => c.String(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.RequiredInventories", "required_inventory_path");
            DropColumn("dbo.RequiredInventories", "required_inventory_chapter_nember");
        }
    }
}
