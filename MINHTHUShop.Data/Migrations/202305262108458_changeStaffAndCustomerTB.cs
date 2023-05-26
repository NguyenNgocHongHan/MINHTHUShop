namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeStaffAndCustomerTB : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ApplicationStaffRoles", newName: "ApplicationUserRoles");
            RenameTable(name: "dbo.Tb_Staff", newName: "Tb_User");
            RenameTable(name: "dbo.ApplicationStaffClaims", newName: "ApplicationUserClaims");
            RenameTable(name: "dbo.ApplicationStaffLogins", newName: "ApplicationUserLogins");
            DropForeignKey("dbo.Tb_Feedback", "CustomerID", "dbo.Tb_Customer");
            DropForeignKey("dbo.Tb_Order", "CustomerID", "dbo.Tb_Customer");
            DropForeignKey("dbo.Tb_ProductComment", "CustomerID", "dbo.Tb_Customer");
            DropIndex("dbo.Tb_Feedback", new[] { "CustomerID" });
            DropIndex("dbo.Tb_Order", new[] { "CustomerID" });
            DropIndex("dbo.Tb_Order", new[] { "StaffID" });
            DropIndex("dbo.Tb_ProductComment", new[] { "CustomerID" });
            DropColumn("dbo.Tb_Order", "CustomerID");
            RenameColumn(table: "dbo.ApplicationUserClaims", name: "Tb_Staff_Id", newName: "Tb_User_Id");
            RenameColumn(table: "dbo.ApplicationUserLogins", name: "Tb_Staff_Id", newName: "Tb_User_Id");
            RenameColumn(table: "dbo.ApplicationUserRoles", name: "Tb_Staff_Id", newName: "Tb_User_Id");
            RenameColumn(table: "dbo.Tb_Order", name: "StaffID", newName: "CustomerID");
            RenameIndex(table: "dbo.ApplicationUserRoles", name: "IX_Tb_Staff_Id", newName: "IX_Tb_User_Id");
            RenameIndex(table: "dbo.ApplicationUserClaims", name: "IX_Tb_Staff_Id", newName: "IX_Tb_User_Id");
            RenameIndex(table: "dbo.ApplicationUserLogins", name: "IX_Tb_Staff_Id", newName: "IX_Tb_User_Id");
            AlterColumn("dbo.Tb_Feedback", "CustomerID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Tb_Order", "CustomerID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Tb_ProductComment", "CustomerID", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Tb_Feedback", "CustomerID");
            CreateIndex("dbo.Tb_Order", "CustomerID");
            CreateIndex("dbo.Tb_ProductComment", "CustomerID");
            AddForeignKey("dbo.Tb_Feedback", "CustomerID", "dbo.Tb_User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tb_ProductComment", "CustomerID", "dbo.Tb_User", "Id", cascadeDelete: true);
            DropTable("dbo.Tb_Customer");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tb_Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 250, unicode: false),
                        Password = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        Address = c.String(nullable: false, maxLength: 250),
                        Gender = c.Boolean(),
                        DateOfBirth = c.DateTime(),
                        Avatar = c.String(maxLength: 250),
                        CreateDate = c.DateTime(nullable: false),
                        IsLoggedIn = c.Boolean(),
                        LastLogin = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            DropForeignKey("dbo.Tb_ProductComment", "CustomerID", "dbo.Tb_User");
            DropForeignKey("dbo.Tb_Feedback", "CustomerID", "dbo.Tb_User");
            DropIndex("dbo.Tb_ProductComment", new[] { "CustomerID" });
            DropIndex("dbo.Tb_Order", new[] { "CustomerID" });
            DropIndex("dbo.Tb_Feedback", new[] { "CustomerID" });
            AlterColumn("dbo.Tb_ProductComment", "CustomerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Tb_Order", "CustomerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Tb_Feedback", "CustomerID", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.ApplicationUserLogins", name: "IX_Tb_User_Id", newName: "IX_Tb_Staff_Id");
            RenameIndex(table: "dbo.ApplicationUserClaims", name: "IX_Tb_User_Id", newName: "IX_Tb_Staff_Id");
            RenameIndex(table: "dbo.ApplicationUserRoles", name: "IX_Tb_User_Id", newName: "IX_Tb_Staff_Id");
            RenameColumn(table: "dbo.Tb_Order", name: "CustomerID", newName: "StaffID");
            RenameColumn(table: "dbo.ApplicationUserRoles", name: "Tb_User_Id", newName: "Tb_Staff_Id");
            RenameColumn(table: "dbo.ApplicationUserLogins", name: "Tb_User_Id", newName: "Tb_Staff_Id");
            RenameColumn(table: "dbo.ApplicationUserClaims", name: "Tb_User_Id", newName: "Tb_Staff_Id");
            AddColumn("dbo.Tb_Order", "CustomerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Tb_ProductComment", "CustomerID");
            CreateIndex("dbo.Tb_Order", "StaffID");
            CreateIndex("dbo.Tb_Order", "CustomerID");
            CreateIndex("dbo.Tb_Feedback", "CustomerID");
            AddForeignKey("dbo.Tb_ProductComment", "CustomerID", "dbo.Tb_Customer", "CustomerID", cascadeDelete: true);
            AddForeignKey("dbo.Tb_Order", "CustomerID", "dbo.Tb_Customer", "CustomerID", cascadeDelete: true);
            AddForeignKey("dbo.Tb_Feedback", "CustomerID", "dbo.Tb_Customer", "CustomerID", cascadeDelete: true);
            RenameTable(name: "dbo.ApplicationUserLogins", newName: "ApplicationStaffLogins");
            RenameTable(name: "dbo.ApplicationUserClaims", newName: "ApplicationStaffClaims");
            RenameTable(name: "dbo.Tb_User", newName: "Tb_Staff");
            RenameTable(name: "dbo.ApplicationUserRoles", newName: "ApplicationStaffRoles");
        }
    }
}
