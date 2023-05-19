namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateRequiredPromotionPrice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tb_Product", "PromotionPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tb_Product", "PromotionPrice", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
