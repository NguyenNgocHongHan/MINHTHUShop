namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeRequiredAttributeForFAQTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tb_FAQ", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tb_FAQ", "Status", c => c.Boolean());
        }
    }
}
