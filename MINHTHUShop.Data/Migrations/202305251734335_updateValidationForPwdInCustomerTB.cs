namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateValidationForPwdInCustomerTB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tb_Customer", "Password", c => c.String(nullable: false, maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tb_Customer", "Password", c => c.String(nullable: false, maxLength: 250, unicode: false));
        }
    }
}
