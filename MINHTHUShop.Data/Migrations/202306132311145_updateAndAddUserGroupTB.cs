namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAndAddUserGroupTB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tb_UserClaim", "Tb_User_Id", "dbo.Tb_User");
            DropForeignKey("dbo.Tb_UserLogin", "Tb_User_Id", "dbo.Tb_User");
            DropIndex("dbo.Tb_UserClaim", new[] { "Tb_User_Id" });
            DropIndex("dbo.Tb_UserLogin", new[] { "Tb_User_Id" });
            CreateTable(
                "dbo.Tb_Group",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.GroupID);
            
            CreateTable(
                "dbo.Tb_RoleGroup",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 128),
                        GroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleID, t.GroupID })
                .ForeignKey("dbo.Tb_Group", t => t.GroupID, cascadeDelete: true)
                .ForeignKey("dbo.Tb_Role", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.Tb_UserGroup",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        GroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.GroupID })
                .ForeignKey("dbo.Tb_Group", t => t.GroupID, cascadeDelete: true)
                .ForeignKey("dbo.Tb_User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.GroupID);
            
            AddColumn("dbo.Tb_Role", "Description", c => c.String(maxLength: 250));
            AddColumn("dbo.Tb_Role", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Tb_OrderStatus", "Status", c => c.Boolean(nullable: false));
            DropTable("dbo.Tb_UserClaim");
            DropTable("dbo.Tb_UserLogin");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tb_UserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        Tb_User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Tb_UserClaim",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        Tb_User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId);
            
            DropForeignKey("dbo.Tb_UserGroup", "UserID", "dbo.Tb_User");
            DropForeignKey("dbo.Tb_UserGroup", "GroupID", "dbo.Tb_Group");
            DropForeignKey("dbo.Tb_RoleGroup", "RoleID", "dbo.Tb_Role");
            DropForeignKey("dbo.Tb_RoleGroup", "GroupID", "dbo.Tb_Group");
            DropIndex("dbo.Tb_UserGroup", new[] { "GroupID" });
            DropIndex("dbo.Tb_UserGroup", new[] { "UserID" });
            DropIndex("dbo.Tb_RoleGroup", new[] { "GroupID" });
            DropIndex("dbo.Tb_RoleGroup", new[] { "RoleID" });
            DropColumn("dbo.Tb_OrderStatus", "Status");
            DropColumn("dbo.Tb_Role", "Discriminator");
            DropColumn("dbo.Tb_Role", "Description");
            DropTable("dbo.Tb_UserGroup");
            DropTable("dbo.Tb_RoleGroup");
            DropTable("dbo.Tb_Group");
            CreateIndex("dbo.Tb_UserLogin", "Tb_User_Id");
            CreateIndex("dbo.Tb_UserClaim", "Tb_User_Id");
            AddForeignKey("dbo.Tb_UserLogin", "Tb_User_Id", "dbo.Tb_User", "Id");
            AddForeignKey("dbo.Tb_UserClaim", "Tb_User_Id", "dbo.Tb_User", "Id");
        }
    }
}
