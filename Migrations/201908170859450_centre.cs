namespace CBTWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class centre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Centre", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Centre");
        }
    }
}
