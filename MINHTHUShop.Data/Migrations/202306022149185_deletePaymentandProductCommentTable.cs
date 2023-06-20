namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletePaymentandProductCommentTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tb_Payment", "OrderID", "dbo.Tb_Order");
            DropIndex("dbo.Tb_Payment", new[] { "OrderID" });
            DropTable("dbo.Tb_Payment");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tb_Payment",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        PaymentDate = c.DateTime(),
                        PaymentAmount = c.Decimal(precision: 18, scale: 2),
                        IsPaid = c.Boolean(),
                    })
                .PrimaryKey(t => t.PaymentID);
            
            CreateIndex("dbo.Tb_Payment", "OrderID");
            AddForeignKey("dbo.Tb_Payment", "OrderID", "dbo.Tb_Order", "OrderID", cascadeDelete: true);
        }
    }
}
