namespace WRS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SprawdzenieBazyDanych : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
