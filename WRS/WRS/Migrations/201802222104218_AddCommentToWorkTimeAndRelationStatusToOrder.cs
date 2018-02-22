namespace WRS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentToWorkTimeAndRelationStatusToOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkTimes", "comment", c => c.String());
            CreateIndex("dbo.Orders", "Status");
            AddForeignKey("dbo.Orders", "Status", "dbo.StatusOfOrders", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Status", "dbo.StatusOfOrders");
            DropIndex("dbo.Orders", new[] { "Status" });
            DropColumn("dbo.WorkTimes", "comment");
        }
    }
}
