namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeNameWebpageTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tb_Page", newName: "Tb_Webpage");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Tb_Webpage", newName: "Tb_Page");
        }
    }
}
