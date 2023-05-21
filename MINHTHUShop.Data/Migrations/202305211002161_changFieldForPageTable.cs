namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changFieldForPageTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tb_Page", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tb_Page", "MetaTitle", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.Tb_Page", "MetaKeywords", c => c.String(maxLength: 250));
            AddColumn("dbo.Tb_Page", "MetaDescriptions", c => c.String(maxLength: 500));
            DropColumn("dbo.Tb_Page", "URL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tb_Page", "URL", c => c.String(nullable: false, maxLength: 250));
            DropColumn("dbo.Tb_Page", "MetaDescriptions");
            DropColumn("dbo.Tb_Page", "MetaKeywords");
            DropColumn("dbo.Tb_Page", "MetaTitle");
            DropColumn("dbo.Tb_Page", "Status");
        }
    }
}
