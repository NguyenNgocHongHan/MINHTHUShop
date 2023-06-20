namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateValidatePhoneFieldForAboutTB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tb_About", "Phone", c => c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tb_About", "Phone", c => c.String(maxLength: 10, fixedLength: true, unicode: false));
        }
    }
}
