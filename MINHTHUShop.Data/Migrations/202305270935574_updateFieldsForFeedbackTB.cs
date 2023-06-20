namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateFieldsForFeedbackTB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tb_Feedback", "CustomerID", "dbo.Tb_User");
            DropIndex("dbo.Tb_Feedback", new[] { "CustomerID" });
            AddColumn("dbo.Tb_Feedback", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Tb_Feedback", "Email", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Tb_Feedback", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tb_Feedback", "IsRead", c => c.Boolean(nullable: false));
            DropColumn("dbo.Tb_Feedback", "CustomerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tb_Feedback", "CustomerID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Tb_Feedback", "IsRead", c => c.Boolean());
            AlterColumn("dbo.Tb_Feedback", "CreateDate", c => c.DateTime());
            DropColumn("dbo.Tb_Feedback", "Email");
            DropColumn("dbo.Tb_Feedback", "Name");
            CreateIndex("dbo.Tb_Feedback", "CustomerID");
            AddForeignKey("dbo.Tb_Feedback", "CustomerID", "dbo.Tb_User", "Id", cascadeDelete: true);
        }
    }
}
