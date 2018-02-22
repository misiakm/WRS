namespace WRS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NextTable_Orders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkTimes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Employee = c.Int(nullable: false),
                        Department = c.Int(),
                        Time = c.Time(nullable: false, precision: 7),
                        Order = c.Int(nullable: false),
                        WorkDate = c.DateTime(nullable: false),
                        DateOfAdd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.Department)
                .ForeignKey("dbo.Employees", t => t.Employee, cascadeDelete: true)
                .Index(t => t.Employee)
                .Index(t => t.Department);
            
            CreateTable(
                "dbo.EmployeeRenumerations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Employee = c.Int(nullable: false),
                        RenumStandard = c.Double(nullable: false),
                        RenumOvertime = c.Double(nullable: false),
                        RenumTripStandard = c.Double(nullable: false),
                        RenumTripOvertime = c.Double(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        DateOfAdd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.Employee, cascadeDelete: true)
                .Index(t => t.Employee);
            
            AddColumn("dbo.Departments", "Comment", c => c.String());
            AddColumn("dbo.EmployeeDepartments", "Comment", c => c.String());
            AddColumn("dbo.Employees", "Comment", c => c.String());
            AddColumn("dbo.StatusOfOrders", "Comment", c => c.String());
            AddColumn("dbo.TypeOfEmployees", "Comment", c => c.String());
            CreateIndex("dbo.EmployeeDepartments", "Employee");
            CreateIndex("dbo.EmployeeDepartments", "Department");
            AddForeignKey("dbo.EmployeeDepartments", "Department", "dbo.Departments", "ID", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeDepartments", "Employee", "dbo.Employees", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkTimes", "Employee", "dbo.Employees");
            DropForeignKey("dbo.EmployeeRenumerations", "Employee", "dbo.Employees");
            DropForeignKey("dbo.EmployeeDepartments", "Employee", "dbo.Employees");
            DropForeignKey("dbo.WorkTimes", "Department", "dbo.Departments");
            DropForeignKey("dbo.EmployeeDepartments", "Department", "dbo.Departments");
            DropIndex("dbo.EmployeeRenumerations", new[] { "Employee" });
            DropIndex("dbo.WorkTimes", new[] { "Department" });
            DropIndex("dbo.WorkTimes", new[] { "Employee" });
            DropIndex("dbo.EmployeeDepartments", new[] { "Department" });
            DropIndex("dbo.EmployeeDepartments", new[] { "Employee" });
            DropColumn("dbo.TypeOfEmployees", "Comment");
            DropColumn("dbo.StatusOfOrders", "Comment");
            DropColumn("dbo.Employees", "Comment");
            DropColumn("dbo.EmployeeDepartments", "Comment");
            DropColumn("dbo.Departments", "Comment");
            DropTable("dbo.EmployeeRenumerations");
            DropTable("dbo.WorkTimes");
        }
    }
}
