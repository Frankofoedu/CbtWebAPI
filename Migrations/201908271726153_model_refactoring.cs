namespace CBTWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model_refactoring : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuestionAndAnswers", "UserAnswersId", "dbo.UserAnswers");
            DropForeignKey("dbo.UserAnswers", "UserId", "dbo.Users");
            DropIndex("dbo.UserAnswers", new[] { "UserId" });
            DropIndex("dbo.QuestionAndAnswers", new[] { "UserAnswersId" });
            AddColumn("dbo.QuestionAndAnswers", "User_Id", c => c.Int());
            CreateIndex("dbo.QuestionAndAnswers", "User_Id");
            AddForeignKey("dbo.QuestionAndAnswers", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.QuestionAndAnswers", "UserAnswersId");
            DropTable("dbo.UserAnswers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TimeLeft = c.String(),
                        isDone = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.QuestionAndAnswers", "UserAnswersId", c => c.Int(nullable: false));
            DropForeignKey("dbo.QuestionAndAnswers", "User_Id", "dbo.Users");
            DropIndex("dbo.QuestionAndAnswers", new[] { "User_Id" });
            DropColumn("dbo.QuestionAndAnswers", "User_Id");
            CreateIndex("dbo.QuestionAndAnswers", "UserAnswersId");
            CreateIndex("dbo.UserAnswers", "UserId");
            AddForeignKey("dbo.UserAnswers", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.QuestionAndAnswers", "UserAnswersId", "dbo.UserAnswers", "Id", cascadeDelete: true);
        }
    }
}
