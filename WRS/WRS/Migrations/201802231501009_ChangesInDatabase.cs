namespace WRS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Login", c => c.String());
            AddColumn("dbo.Employees", "Password", c => c.String());
            AddColumn("dbo.Employees", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Discriminator");
            DropColumn("dbo.Employees", "Password");
            DropColumn("dbo.Employees", "Login");
        }
    }
}
