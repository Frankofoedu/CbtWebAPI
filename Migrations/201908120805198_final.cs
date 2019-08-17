namespace CBTWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAnswers", "TimeLeft", c => c.String());
            AddColumn("dbo.UserAnswers", "isDone", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "isDone", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "TimeLeft", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "TimeLeft");
            DropColumn("dbo.Users", "isDone");
            DropColumn("dbo.UserAnswers", "isDone");
            DropColumn("dbo.UserAnswers", "TimeLeft");
        }
    }
}
