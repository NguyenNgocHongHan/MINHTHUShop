namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyAttributeIdentityAndChangeNameTbRole : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.IdentityUserRoles", newName: "ApplicationCustomerRoles");
            RenameTable(name: "dbo.IdentityUserLogins", newName: "ApplicationCustomerLogins");
            RenameTable(name: "dbo.Tb_Role", newName: "Tb_RoleStaff");
            DropPrimaryKey("dbo.ApplicationCustomerRoles");
            AlterColumn("dbo.ApplicationCustomerRoles", "RoleId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.ApplicationCustomerRoles", new[] { "UserId", "RoleId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ApplicationCustomerRoles");
            AlterColumn("dbo.ApplicationCustomerRoles", "RoleId", c => c.String());
            AddPrimaryKey("dbo.ApplicationCustomerRoles", "UserId");
            RenameTable(name: "dbo.Tb_RoleStaff", newName: "Tb_Role");
            RenameTable(name: "dbo.ApplicationCustomerLogins", newName: "IdentityUserLogins");
            RenameTable(name: "dbo.ApplicationCustomerRoles", newName: "IdentityUserRoles");
        }
    }
}
