namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.IdentityRoles", newName: "ApplicationRoles");
            RenameTable(name: "dbo.IdentityUserClaims", newName: "ApplicationCustomerClaims");
            DropPrimaryKey("dbo.ApplicationCustomerClaims");
            AlterColumn("dbo.ApplicationCustomerClaims", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ApplicationCustomerClaims", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.ApplicationCustomerClaims", "UserId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ApplicationCustomerClaims");
            AlterColumn("dbo.ApplicationCustomerClaims", "UserId", c => c.String());
            AlterColumn("dbo.ApplicationCustomerClaims", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ApplicationCustomerClaims", "Id");
            RenameTable(name: "dbo.ApplicationCustomerClaims", newName: "IdentityUserClaims");
            RenameTable(name: "dbo.ApplicationRoles", newName: "IdentityRoles");
        }
    }
}
