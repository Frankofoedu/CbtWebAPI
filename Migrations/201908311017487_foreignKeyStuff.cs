namespace CBTWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignKeyStuff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuestionAndAnswers", "User_Id", "dbo.Users");
            DropIndex("dbo.QuestionAndAnswers", new[] { "User_Id" });
            AlterColumn("dbo.QuestionAndAnswers", "User_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.QuestionAndAnswers", "User_Id");
            AddForeignKey("dbo.QuestionAndAnswers", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionAndAnswers", "User_Id", "dbo.Users");
            DropIndex("dbo.QuestionAndAnswers", new[] { "User_Id" });
            AlterColumn("dbo.QuestionAndAnswers", "User_Id", c => c.Int());
            CreateIndex("dbo.QuestionAndAnswers", "User_Id");
            AddForeignKey("dbo.QuestionAndAnswers", "User_Id", "dbo.Users", "Id");
        }
    }
}
