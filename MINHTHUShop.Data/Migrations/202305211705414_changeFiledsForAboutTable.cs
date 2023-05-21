namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeFiledsForAboutTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tb_About", "Website", c => c.String(maxLength: 250));
            AddColumn("dbo.Tb_About", "MapLat", c => c.Double());
            AddColumn("dbo.Tb_About", "MapLong", c => c.Double());
            AlterColumn("dbo.Tb_About", "Phone", c => c.String(maxLength: 10, fixedLength: true, unicode: false));
            DropColumn("dbo.Tb_About", "Fanpage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tb_About", "Fanpage", c => c.String(maxLength: 250));
            AlterColumn("dbo.Tb_About", "Phone", c => c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false));
            DropColumn("dbo.Tb_About", "MapLong");
            DropColumn("dbo.Tb_About", "MapLat");
            DropColumn("dbo.Tb_About", "Website");
        }
    }
}
