namespace WRS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stworzenieSlownikowIPracownikow : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NameOfDepartment = c.String(nullable: false),
                        DateOfAdd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EmployeeDepartments",
                c => new
                    {
                        Employee = c.Int(nullable: false),
                        Department = c.Int(nullable: false),
                        DateOfAdd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee, t.Department });
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        TypeOfEmployee = c.Int(nullable: false),
                        DateOFAdd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TypeOfEmployees", t => t.TypeOfEmployee, cascadeDelete: true)
                .Index(t => t.TypeOfEmployee);
            
            CreateTable(
                "dbo.StatusOfOrders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NameOfStatus = c.String(nullable: false),
                        DateOfAdd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TypeOfEmployees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NameOfType = c.String(nullable: false),
                        DateOfAdd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "TypeOfEmployee", "dbo.TypeOfEmployees");
            DropIndex("dbo.Employees", new[] { "TypeOfEmployee" });
            DropTable("dbo.TypeOfEmployees");
            DropTable("dbo.StatusOfOrders");
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeeDepartments");
            DropTable("dbo.Departments");
        }
    }
}
