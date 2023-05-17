namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBannerTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tb_Banner", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tb_Banner", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tb_Banner", "Status", c => c.Boolean());
            AlterColumn("dbo.Tb_Banner", "CreateDate", c => c.DateTime());
        }
    }
}
