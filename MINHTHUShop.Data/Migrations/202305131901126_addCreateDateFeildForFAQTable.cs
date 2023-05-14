namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCreateDateFeildForFAQTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tb_FAQ", "CreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tb_FAQ", "CreateDate");
        }
    }
}
