namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeRequiredValidationInTables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tb_About", "MetaTitle", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Tb_Customer", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tb_Customer", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tb_News", "MetaTitle", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Tb_NewsCategory", "MetaTitle", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Tb_Order", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tb_Order", "Note", c => c.String(maxLength: 500));
            AlterColumn("dbo.Tb_Order", "IsCancel", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tb_PaymentMethod", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tb_ShippingMethod", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tb_Staff", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tb_Staff", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tb_Product", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tb_Product", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tb_Product", "MetaTitle", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Tb_ProductCategory", "MetaTitle", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Tb_ProductComment", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tb_ProductComment", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tb_ProductComment", "Status", c => c.Boolean());
            AlterColumn("dbo.Tb_ProductComment", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.Tb_ProductCategory", "MetaTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.Tb_Product", "MetaTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.Tb_Product", "Status", c => c.Boolean());
            AlterColumn("dbo.Tb_Product", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.Tb_Staff", "Status", c => c.Boolean());
            AlterColumn("dbo.Tb_Staff", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.Tb_ShippingMethod", "Status", c => c.Boolean());
            AlterColumn("dbo.Tb_PaymentMethod", "Status", c => c.Boolean());
            AlterColumn("dbo.Tb_Order", "IsCancel", c => c.Boolean());
            AlterColumn("dbo.Tb_Order", "Note", c => c.String());
            AlterColumn("dbo.Tb_Order", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.Tb_NewsCategory", "MetaTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.Tb_News", "MetaTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.Tb_Customer", "Status", c => c.Boolean());
            AlterColumn("dbo.Tb_Customer", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.Tb_About", "MetaTitle", c => c.String(maxLength: 250));
        }
    }
}
