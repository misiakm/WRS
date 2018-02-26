using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WRS.Models;
using WRS.ModelsViews;

namespace WRS.Logic
{
    public class WorkTimes : DatabaseConnect
    {

        /// <summary>
        /// Get list: ID, EmployeeID, EmployeeName, DepartmentID, WorkTime, WorkDate, OrderID, OrderName, comment
        /// </summary>
        /// <returns></returns>
        public IList<WorkTimesTable> GetAllDetails()
        {
            var q = (from wt in db.WorkTimes
                     join e in db.Employees on wt.Employee equals e.ID
                     join d in db.Departments on wt.Department equals d.ID
                     join o in db.Orders on wt.Order equals o.ID
                     select new WorkTimesTable
                     {
                         ID = wt.ID,
                         Order = wt.Order,
                         Comment = wt.Comment,
                         DateOfAdd = wt.DateOfAdd,
                         Department = wt.Department,
                         Employee = wt.Employee,
                         EmployeeFullName = $"{e.FirstName} {e.LastName}",
                         NameOfDepartment = d.NameOfDepartment,
                         NameOfOrder = o.NameOfOrder,
                         Time = wt.Time,
                         WorkDate = wt.WorkDate,
                         Amount = wt.Amount
                     }
                     ).ToList();

            return q;
        }

        /// <summary>
        /// Get list: ID, EmployeeID, EmployeeName, DepartmentID, WorkTime, WorkDate, OrderID, OrderName, comment. Only one order
        /// </summary>
        /// <param name="Order">Order ID you are looking for</param>
        /// <returns></returns>
        public IList<WorkTimesTable> GetAllDetailsOrder(int Order)
        {
            return GetAllDetails().Where(x => x.Order == Order).ToList();
        }

        /// <summary>
        /// Get list: ID, EmployeeID, EmployeeName, DepartmentID, WorkTime, WorkDate, OrderID, OrderName, comment. Only one employee
        /// </summary>
        /// <param name="Employee">Employee ID you are looking for</param>
        /// <returns></returns>
        public IList<WorkTimesTable> GetAllDetailsEmployee(int Employee)
        {
            return GetAllDetails().Where(x => x.Employee == Employee).ToList();
        }

        /// <summary>
        /// Get list: ID, EmployeeID, EmployeeName, DepartmentID, WorkTime, WorkDate, OrderID, OrderName, comment. Only one day
        /// </summary>
        /// <param name="WorkDate"Date you are looking forr</param>
        /// <returns></returns>
        public IList<WorkTimesTable> GetAllDetailsWorkDate(DateTime WorkDate)
        {
            return GetAllDetails().Where(x => x.WorkDate == WorkDate).ToList();
        }

        /// <summary>
        /// Get list: ID, EmployeeID, EmployeeName, DepartmentID, WorkTime, WorkDate, OrderID, OrderName, comment. Only one department
        /// </summary>
        /// <param name="Department"Department ID you are looking forr</param>
        /// <returns></returns>
        public IList<WorkTimesTable> GetAllDetailsWorkDate(int Department)
        {
            return GetAllDetails().Where(x => x.Department == Department).ToList();
        }

        /// <summary>
        /// Add new Work Time
        /// </summary>
        /// <param name="Date"></param>
        /// <param name="Employee"></param>
        /// <param name="Order"></param>
        /// <param name="Time"></param>
        /// <param name="Ammont"></param>
        /// <param name="Department"></param>
        /// <param name="Comment"></param>
        public void AddWorkTime(DateTime Date, int Employee, int Order, TimeSpan Time, double Ammont, int? Department, string Comment)
        {
            WorkTime WT = new WorkTime()
            {
                WorkDate = Date,
                Employee = Employee,
                Order = Order,
                Time = Time,
                Amount = Ammont,
                Comment = Comment
            };

            db.WorkTimes.Add(WT);
            db.SaveChanges();
        }
    }
}