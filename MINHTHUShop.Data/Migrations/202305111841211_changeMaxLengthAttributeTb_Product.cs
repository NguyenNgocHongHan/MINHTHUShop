namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeMaxLengthAttributeTb_Product : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tb_Product", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tb_Product", "Description", c => c.String(maxLength: 500));
        }
    }
}
