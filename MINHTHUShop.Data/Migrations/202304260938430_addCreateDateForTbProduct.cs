namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCreateDateForTbProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tb_Product", "CreateDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tb_Product", "CreateDate");
        }
    }
}
