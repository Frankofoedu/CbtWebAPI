namespace CBTWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class annotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "FullName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Address", c => c.String());
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Users", "FullName", c => c.String());
        }
    }
}
