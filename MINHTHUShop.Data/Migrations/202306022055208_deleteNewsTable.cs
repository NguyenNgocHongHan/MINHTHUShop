namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteNewsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tb_News", "NewsCateID", "dbo.Tb_NewsCategory");
            DropForeignKey("dbo.Tb_TagNews", "NewsID", "dbo.Tb_News");
            DropForeignKey("dbo.Tb_TagNews", "TagID", "dbo.Tb_Tag");
            DropIndex("dbo.Tb_News", new[] { "NewsCateID" });
            DropIndex("dbo.Tb_TagNews", new[] { "NewsID" });
            DropIndex("dbo.Tb_TagNews", new[] { "TagID" });
            DropTable("dbo.Tb_News");
            DropTable("dbo.Tb_NewsCategory");
            DropTable("dbo.Tb_TagNews");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tb_TagNews",
                c => new
                    {
                        NewsID = c.Int(nullable: false),
                        TagID = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.NewsID, t.TagID });
            
            CreateTable(
                "dbo.Tb_NewsCategory",
                c => new
                    {
                        NewsCateID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Sort = c.Int(),
                        ParentID = c.Int(),
                        MetaTitle = c.String(nullable: false, maxLength: 250),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescriptions = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.NewsCateID);
            
            CreateTable(
                "dbo.Tb_News",
                c => new
                    {
                        NewsID = c.Int(nullable: false, identity: true),
                        NewsCateID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                        Image = c.String(nullable: false, maxLength: 250),
                        Description = c.String(nullable: false),
                        Tag = c.String(maxLength: 500),
                        CreateDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        MetaTitle = c.String(nullable: false, maxLength: 250),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescriptions = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.NewsID);
            
            CreateIndex("dbo.Tb_TagNews", "TagID");
            CreateIndex("dbo.Tb_TagNews", "NewsID");
            CreateIndex("dbo.Tb_News", "NewsCateID");
            AddForeignKey("dbo.Tb_TagNews", "TagID", "dbo.Tb_Tag", "TagID", cascadeDelete: true);
            AddForeignKey("dbo.Tb_TagNews", "NewsID", "dbo.Tb_News", "NewsID", cascadeDelete: true);
            AddForeignKey("dbo.Tb_News", "NewsCateID", "dbo.Tb_NewsCategory", "NewsCateID", cascadeDelete: true);
        }
    }
}
