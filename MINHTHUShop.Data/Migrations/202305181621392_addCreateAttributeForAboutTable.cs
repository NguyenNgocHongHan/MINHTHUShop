namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCreateAttributeForAboutTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tb_About", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tb_About", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tb_About", "Status", c => c.Boolean());
            DropColumn("dbo.Tb_About", "CreateDate");
        }
    }
}
