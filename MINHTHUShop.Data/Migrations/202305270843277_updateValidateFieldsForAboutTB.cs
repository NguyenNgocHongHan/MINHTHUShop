namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateValidateFieldsForAboutTB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tb_About", "Name", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tb_About", "Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
