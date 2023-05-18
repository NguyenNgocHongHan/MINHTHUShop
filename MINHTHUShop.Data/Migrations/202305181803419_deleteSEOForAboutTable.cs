namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteSEOForAboutTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tb_About", "MetaTitle");
            DropColumn("dbo.Tb_About", "MetaKeywords");
            DropColumn("dbo.Tb_About", "MetaDescriptions");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tb_About", "MetaDescriptions", c => c.String(maxLength: 500));
            AddColumn("dbo.Tb_About", "MetaKeywords", c => c.String(maxLength: 250));
            AddColumn("dbo.Tb_About", "MetaTitle", c => c.String(nullable: false, maxLength: 250));
        }
    }
}
