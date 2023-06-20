namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateIdentityTable : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Tb_User", t => t.Tb_User_Id)
                .Index(t => t.Tb_User_Id);
            
            CreateTable(
                "dbo.Tb_UserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        Tb_User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Tb_User", t => t.Tb_User_Id)
                .Index(t => t.Tb_User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tb_UserLogin", "Tb_User_Id", "dbo.Tb_User");
            DropForeignKey("dbo.Tb_UserClaim", "Tb_User_Id", "dbo.Tb_User");
            DropIndex("dbo.Tb_UserLogin", new[] { "Tb_User_Id" });
            DropIndex("dbo.Tb_UserClaim", new[] { "Tb_User_Id" });
            DropTable("dbo.Tb_UserLogin");
            DropTable("dbo.Tb_UserClaim");
        }
    }
}
