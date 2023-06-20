namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameIdentityTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ApplicationRoles", newName: "Tb_Role");
            RenameTable(name: "dbo.ApplicationUserRoles", newName: "Tb_UserRole");
            RenameTable(name: "dbo.ApplicationUserClaims", newName: "Tb_UserClaim");
            RenameTable(name: "dbo.ApplicationUserLogins", newName: "Tb_UserLogin");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Tb_UserLogin", newName: "ApplicationUserLogins");
            RenameTable(name: "dbo.Tb_UserClaim", newName: "ApplicationUserClaims");
            RenameTable(name: "dbo.Tb_UserRole", newName: "ApplicationUserRoles");
            RenameTable(name: "dbo.Tb_Role", newName: "ApplicationRoles");
        }
    }
}
