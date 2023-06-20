namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPhoneFieldsForFeedbackTB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tb_Feedback", "Phone", c => c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tb_Feedback", "Phone");
        }
    }
}
