namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNoteFieldsForFeedbackTB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tb_Feedback", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tb_Feedback", "Note");
        }
    }
}
