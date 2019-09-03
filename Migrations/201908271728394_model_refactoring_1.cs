namespace CBTWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model_refactoring_1 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Results");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        FullName = c.String(),
                        Centre = c.String(),
                        CorrectANswers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
