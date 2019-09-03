namespace CBTWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelchange : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserAnswers", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.UserAnswers", name: "IX_User_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UserAnswers", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.UserAnswers", name: "UserId", newName: "User_Id");
        }
    }
}
