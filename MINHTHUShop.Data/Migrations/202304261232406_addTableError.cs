namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableError : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tb_Error",
                c => new
                    {
                        ErrorID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        CreateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ErrorID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tb_Error");
        }
    }
}
