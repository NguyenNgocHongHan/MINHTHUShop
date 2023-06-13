namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFieldsForOrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tb_Order", "CustomerName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Tb_Order", "CustomerAddress", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.Tb_Order", "CustomerEmail", c => c.String(nullable: false));
            AddColumn("dbo.Tb_Order", "CustomerMobile", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tb_Order", "CustomerMobile");
            DropColumn("dbo.Tb_Order", "CustomerEmail");
            DropColumn("dbo.Tb_Order", "CustomerAddress");
            DropColumn("dbo.Tb_Order", "CustomerName");
        }
    }
}
