namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tb_Order", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Tb_Order", "CustomerEmail");
            DropColumn("dbo.Tb_Order", "Total");
            DropColumn("dbo.Tb_Order", "IsCancel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tb_Order", "IsCancel", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tb_Order", "Total", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Tb_Order", "CustomerEmail", c => c.String(nullable: false));
            DropColumn("dbo.Tb_Order", "TotalPrice");
        }
    }
}
