namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeValidateListImg : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tb_Product", "ListImg", c => c.String(storeType: "xml"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tb_Product", "ListImg", c => c.String());
        }
    }
}
