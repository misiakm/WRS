using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WRS.ModelsViews
{
    public class WorkTimesTable : Models.WorkTime
    {

        public string NameOfOrder { get; set; }
        public string NameOfDepartment { get; set; }
        public string EmployeeFullName { get; set; }
        
    }
}