namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletePositionFieldForBannerTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tb_Banner", "Position");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tb_Banner", "Position", c => c.Int());
        }
    }
}
