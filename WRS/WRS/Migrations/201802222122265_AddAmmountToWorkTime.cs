namespace WRS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAmmountToWorkTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkTimes", "amount", c => c.Double(nullable: false));
            AddColumn("dbo.WorkTimes", "NameOfOrder", c => c.String());
            AddColumn("dbo.WorkTimes", "NameOfDepartment", c => c.String());
            AddColumn("dbo.WorkTimes", "EmployeeFullName", c => c.String());
            AddColumn("dbo.WorkTimes", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkTimes", "Discriminator");
            DropColumn("dbo.WorkTimes", "EmployeeFullName");
            DropColumn("dbo.WorkTimes", "NameOfDepartment");
            DropColumn("dbo.WorkTimes", "NameOfOrder");
            DropColumn("dbo.WorkTimes", "amount");
        }
    }
}
