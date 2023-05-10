namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_SEO_Atrribute_In_Tables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tb_NewsCategory", "MetaTitle", c => c.String(maxLength: 250));
            AddColumn("dbo.Tb_NewsCategory", "MetaKeywords", c => c.String(maxLength: 250));
            AddColumn("dbo.Tb_NewsCategory", "MetaDescriptions", c => c.String(maxLength: 500));
            AddColumn("dbo.Tb_ProductCategory", "MetaTitle", c => c.String(maxLength: 250));
            AddColumn("dbo.Tb_ProductCategory", "MetaKeywords", c => c.String(maxLength: 250));
            AddColumn("dbo.Tb_ProductCategory", "MetaDescriptions", c => c.String(maxLength: 500));
            DropColumn("dbo.Tb_FAQ", "MetaTitle");
            DropColumn("dbo.Tb_FAQ", "MetaKeywords");
            DropColumn("dbo.Tb_FAQ", "MetaDescriptions");
            DropColumn("dbo.Tb_Page", "MetaTitle");
            DropColumn("dbo.Tb_Page", "MetaKeywords");
            DropColumn("dbo.Tb_Page", "MetaDescriptions");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tb_Page", "MetaDescriptions", c => c.String(maxLength: 500));
            AddColumn("dbo.Tb_Page", "MetaKeywords", c => c.String(maxLength: 250));
            AddColumn("dbo.Tb_Page", "MetaTitle", c => c.String(maxLength: 250));
            AddColumn("dbo.Tb_FAQ", "MetaDescriptions", c => c.String(maxLength: 500));
            AddColumn("dbo.Tb_FAQ", "MetaKeywords", c => c.String(maxLength: 250));
            AddColumn("dbo.Tb_FAQ", "MetaTitle", c => c.String(maxLength: 250));
            DropColumn("dbo.Tb_ProductCategory", "MetaDescriptions");
            DropColumn("dbo.Tb_ProductCategory", "MetaKeywords");
            DropColumn("dbo.Tb_ProductCategory", "MetaTitle");
            DropColumn("dbo.Tb_NewsCategory", "MetaDescriptions");
            DropColumn("dbo.Tb_NewsCategory", "MetaKeywords");
            DropColumn("dbo.Tb_NewsCategory", "MetaTitle");
        }
    }
}
