namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteUnnecessaryTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tb_Shipping", "OrderID", "dbo.Tb_Order");
            DropIndex("dbo.Tb_Shipping", new[] { "OrderID" });
            DropTable("dbo.Tb_About");
            DropTable("dbo.Tb_Config");
            DropTable("dbo.Tb_Footer");
            DropTable("dbo.Tb_Shipping");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tb_Shipping",
                c => new
                    {
                        ShippingID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ShippingDate = c.DateTime(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        IsShipping = c.Boolean(),
                    })
                .PrimaryKey(t => t.ShippingID);
            
            CreateTable(
                "dbo.Tb_Footer",
                c => new
                    {
                        FooterID = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FooterID);
            
            CreateTable(
                "dbo.Tb_Config",
                c => new
                    {
                        ConfigID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ValueNum = c.Int(),
                        ValueString = c.String(maxLength: 50),
                        Description = c.String(maxLength: 500),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ConfigID);
            
            CreateTable(
                "dbo.Tb_About",
                c => new
                    {
                        AboutID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Phone = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        Email = c.String(maxLength: 250, unicode: false),
                        Website = c.String(maxLength: 250),
                        Address = c.String(nullable: false, maxLength: 250),
                        Description = c.String(),
                        MapLat = c.Double(),
                        MapLong = c.Double(),
                        CreateDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AboutID);
            
            CreateIndex("dbo.Tb_Shipping", "OrderID");
            AddForeignKey("dbo.Tb_Shipping", "OrderID", "dbo.Tb_Order", "OrderID", cascadeDelete: true);
        }
    }
}
