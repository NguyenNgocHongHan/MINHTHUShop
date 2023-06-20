namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAuthorizationTableInDatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tb_Group", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Tb_OrderStatus", "Status");
            DropColumn("dbo.Tb_PaymentMethod", "Status");
            DropColumn("dbo.Tb_ShippingMethod", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tb_ShippingMethod", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tb_PaymentMethod", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tb_OrderStatus", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tb_Group", "Name", c => c.String(maxLength: 250));
        }
    }
}
