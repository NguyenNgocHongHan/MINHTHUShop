namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeTbCustomerToIdentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tb_Feedback", "CustomerID", "dbo.Tb_Customer");
            DropForeignKey("dbo.Tb_Order", "CustomerID", "dbo.Tb_Customer");
            DropForeignKey("dbo.Tb_ProductComment", "CustomerID", "dbo.Tb_Customer");
            DropIndex("dbo.Tb_Feedback", new[] { "CustomerID" });
            DropIndex("dbo.Tb_Order", new[] { "CustomerID" });
            DropIndex("dbo.Tb_ProductComment", new[] { "CustomerID" });
            DropPrimaryKey("dbo.Tb_Customer");
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        Tb_Customer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.Tb_Customer", t => t.Tb_Customer_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.Tb_Customer_Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        Tb_Customer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tb_Customer", t => t.Tb_Customer_Id)
                .Index(t => t.Tb_Customer_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        Tb_Customer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Tb_Customer", t => t.Tb_Customer_Id)
                .Index(t => t.Tb_Customer_Id);
            
            AddColumn("dbo.Tb_Customer", "Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Tb_Customer", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tb_Customer", "PasswordHash", c => c.String());
            AddColumn("dbo.Tb_Customer", "SecurityStamp", c => c.String());
            AddColumn("dbo.Tb_Customer", "PhoneNumber", c => c.String());
            AddColumn("dbo.Tb_Customer", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tb_Customer", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tb_Customer", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.Tb_Customer", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tb_Customer", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.Tb_Customer", "UserName", c => c.String());
            AlterColumn("dbo.Tb_Customer", "Email", c => c.String());
            AlterColumn("dbo.Tb_Feedback", "CustomerID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Tb_Order", "CustomerID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Tb_ProductComment", "CustomerID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Tb_Customer", "Id");
            CreateIndex("dbo.Tb_Feedback", "CustomerID");
            CreateIndex("dbo.Tb_Order", "CustomerID");
            CreateIndex("dbo.Tb_ProductComment", "CustomerID");
            AddForeignKey("dbo.Tb_Feedback", "CustomerID", "dbo.Tb_Customer", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tb_Order", "CustomerID", "dbo.Tb_Customer", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tb_ProductComment", "CustomerID", "dbo.Tb_Customer", "Id", cascadeDelete: true);
            DropColumn("dbo.Tb_Customer", "CustomerID");
            DropColumn("dbo.Tb_Customer", "Password");
            DropColumn("dbo.Tb_Customer", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tb_Customer", "Phone", c => c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false));
            AddColumn("dbo.Tb_Customer", "Password", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AddColumn("dbo.Tb_Customer", "CustomerID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Tb_ProductComment", "CustomerID", "dbo.Tb_Customer");
            DropForeignKey("dbo.Tb_Order", "CustomerID", "dbo.Tb_Customer");
            DropForeignKey("dbo.Tb_Feedback", "CustomerID", "dbo.Tb_Customer");
            DropForeignKey("dbo.IdentityUserRoles", "Tb_Customer_Id", "dbo.Tb_Customer");
            DropForeignKey("dbo.IdentityUserLogins", "Tb_Customer_Id", "dbo.Tb_Customer");
            DropForeignKey("dbo.IdentityUserClaims", "Tb_Customer_Id", "dbo.Tb_Customer");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropIndex("dbo.Tb_ProductComment", new[] { "CustomerID" });
            DropIndex("dbo.Tb_Order", new[] { "CustomerID" });
            DropIndex("dbo.IdentityUserLogins", new[] { "Tb_Customer_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "Tb_Customer_Id" });
            DropIndex("dbo.Tb_Feedback", new[] { "CustomerID" });
            DropIndex("dbo.IdentityUserRoles", new[] { "Tb_Customer_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropPrimaryKey("dbo.Tb_Customer");
            AlterColumn("dbo.Tb_ProductComment", "CustomerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Tb_Order", "CustomerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Tb_Feedback", "CustomerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Tb_Customer", "Email", c => c.String(nullable: false, maxLength: 250, unicode: false));
            DropColumn("dbo.Tb_Customer", "UserName");
            DropColumn("dbo.Tb_Customer", "AccessFailedCount");
            DropColumn("dbo.Tb_Customer", "LockoutEnabled");
            DropColumn("dbo.Tb_Customer", "LockoutEndDateUtc");
            DropColumn("dbo.Tb_Customer", "TwoFactorEnabled");
            DropColumn("dbo.Tb_Customer", "PhoneNumberConfirmed");
            DropColumn("dbo.Tb_Customer", "PhoneNumber");
            DropColumn("dbo.Tb_Customer", "SecurityStamp");
            DropColumn("dbo.Tb_Customer", "PasswordHash");
            DropColumn("dbo.Tb_Customer", "EmailConfirmed");
            DropColumn("dbo.Tb_Customer", "Id");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityRoles");
            AddPrimaryKey("dbo.Tb_Customer", "CustomerID");
            CreateIndex("dbo.Tb_ProductComment", "CustomerID");
            CreateIndex("dbo.Tb_Order", "CustomerID");
            CreateIndex("dbo.Tb_Feedback", "CustomerID");
            AddForeignKey("dbo.Tb_ProductComment", "CustomerID", "dbo.Tb_Customer", "CustomerID", cascadeDelete: true);
            AddForeignKey("dbo.Tb_Order", "CustomerID", "dbo.Tb_Customer", "CustomerID", cascadeDelete: true);
            AddForeignKey("dbo.Tb_Feedback", "CustomerID", "dbo.Tb_Customer", "CustomerID", cascadeDelete: true);
        }
    }
}
