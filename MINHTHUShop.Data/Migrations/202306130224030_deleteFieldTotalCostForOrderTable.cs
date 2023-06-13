namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteFieldTotalCostForOrderTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tb_Order", "TotalPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tb_Order", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
