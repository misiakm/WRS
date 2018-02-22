namespace WRS.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WRSDbContext : DbContext
    {
        public WRSDbContext()
            : base("name=WRSDbContext")
        {
        }

        public DbSet<StatusOfOrder> StatusOfOrders { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<TypeOfEmployee> TypeOfEmployees { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<EmployeeRenumeration> EmployeeRenumerations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<WorkTime> WorkTimes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
