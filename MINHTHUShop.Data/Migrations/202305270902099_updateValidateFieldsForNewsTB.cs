namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateValidateFieldsForNewsTB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tb_News", "Image", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tb_News", "Image", c => c.String(maxLength: 250));
        }
    }
}
