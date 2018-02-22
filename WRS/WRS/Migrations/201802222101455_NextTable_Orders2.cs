namespace WRS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NextTable_Orders2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NameOfCustmoer = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                        Street = c.String(),
                        HouseNumber = c.String(),
                        PostalCode = c.String(),
                        City = c.String(),
                        TypeOfCustomer = c.Int(nullable: false),
                        Comment = c.String(),
                        DateOfAdd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NameOfOrder = c.String(nullable: false),
                        Customer = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Number = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        PlanPrace = c.Double(nullable: false),
                        PlanEndDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Comment = c.String(),
                        DateOfAdd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.Customer, cascadeDelete: true)
                .Index(t => t.Customer);
            
            CreateIndex("dbo.WorkTimes", "Order");
            AddForeignKey("dbo.WorkTimes", "Order", "dbo.Orders", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Customer", "dbo.Customers");
            DropForeignKey("dbo.WorkTimes", "Order", "dbo.Orders");
            DropIndex("dbo.WorkTimes", new[] { "Order" });
            DropIndex("dbo.Orders", new[] { "Customer" });
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
