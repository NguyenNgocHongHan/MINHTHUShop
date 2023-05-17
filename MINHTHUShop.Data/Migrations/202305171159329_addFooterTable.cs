namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFooterTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tb_Footer",
                c => new
                    {
                        FooterID = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FooterID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tb_Footer");
        }
    }
}
