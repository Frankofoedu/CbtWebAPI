namespace CBTWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelchangeUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuestionAndAnswers", "UserAnswers_Id", "dbo.UserAnswers");
            DropIndex("dbo.QuestionAndAnswers", new[] { "UserAnswers_Id" });
            RenameColumn(table: "dbo.QuestionAndAnswers", name: "UserAnswers_Id", newName: "UserAnswersId");
            AlterColumn("dbo.QuestionAndAnswers", "UserAnswersId", c => c.Int(nullable: false));
            CreateIndex("dbo.QuestionAndAnswers", "UserAnswersId");
            AddForeignKey("dbo.QuestionAndAnswers", "UserAnswersId", "dbo.UserAnswers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionAndAnswers", "UserAnswersId", "dbo.UserAnswers");
            DropIndex("dbo.QuestionAndAnswers", new[] { "UserAnswersId" });
            AlterColumn("dbo.QuestionAndAnswers", "UserAnswersId", c => c.Int());
            RenameColumn(table: "dbo.QuestionAndAnswers", name: "UserAnswersId", newName: "UserAnswers_Id");
            CreateIndex("dbo.QuestionAndAnswers", "UserAnswers_Id");
            AddForeignKey("dbo.QuestionAndAnswers", "UserAnswers_Id", "dbo.UserAnswers", "Id");
        }
    }
}
