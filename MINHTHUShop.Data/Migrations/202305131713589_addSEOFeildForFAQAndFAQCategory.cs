namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSEOFeildForFAQAndFAQCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tb_FAQCategory", "MetaTitle", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.Tb_FAQCategory", "MetaKeywords", c => c.String(maxLength: 250));
            AddColumn("dbo.Tb_FAQCategory", "MetaDescriptions", c => c.String(maxLength: 500));
            AddColumn("dbo.Tb_FAQ", "MetaTitle", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.Tb_FAQ", "MetaKeywords", c => c.String(maxLength: 250));
            AddColumn("dbo.Tb_FAQ", "MetaDescriptions", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tb_FAQ", "MetaDescriptions");
            DropColumn("dbo.Tb_FAQ", "MetaKeywords");
            DropColumn("dbo.Tb_FAQ", "MetaTitle");
            DropColumn("dbo.Tb_FAQCategory", "MetaDescriptions");
            DropColumn("dbo.Tb_FAQCategory", "MetaKeywords");
            DropColumn("dbo.Tb_FAQCategory", "MetaTitle");
        }
    }
}
