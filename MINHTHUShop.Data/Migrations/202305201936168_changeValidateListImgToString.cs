namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeValidateListImgToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tb_Product", "ListImg", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tb_Product", "ListImg", c => c.String(storeType: "xml"));
        }
    }
}
