using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using WRS.Models;


namespace WRS.Logic
{
    public class Logs : DatabaseConnect
    {
        /// <summary>
        /// If Login and password is Currectly then create session and return true
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool CurrectlyLoggedIn(string Login, string Password)
        {
            string pass;
            using (MD5 Md5 = MD5.Create())
            {
                pass = GetMd5Hash(Md5, Password);
            }
            var E = db.Employees.Where(x => x.Login == Login && x.Password == pass).FirstOrDefault();
            if (E == null)
            {
                return false;
            }
            else {
                HttpContext.Current.Session["EmployeeID"] = E.ID;
                return true;
            }
        }

        /// <summary>
        /// Get object Employee from session
        /// </summary>
        /// <returns></returns>
        public Employee GetLoggedEmployee()
        {
            Employee E = db.Employees.Find(GetLoggedEmployeeID());
            return E;
        }

        /// <summary>
        /// Get employee ID from session
        /// </summary>
        /// <returns></returns>
        public int? GetLoggedEmployeeID()
        {
            return Convert.ToInt32(HttpContext.Current.Session["EmployeeID"]);
        }


        public static void AddTestEmployee()
        {
            DatabaseConnect DC = new DatabaseConnect();
            Employee E = new Employee()
            {
                Login = "admin",
                Password = GetMd5Hash(MD5.Create(), "abc"),
                FirstName = "Admin",
                LastName = "Admin",
                TypeOfEmployee = DC.db.TypeOfEmployees.Where(x => x.NameOfType == "Admin").FirstOrDefault().ID
            };
            if (DC.db.Employees.Where(x => x.Login == E.Login && x.Password == E.Password).FirstOrDefault() != null)
            {
                DC.db.Employees.Add(E);
                DC.db.SaveChanges();
            }            
        }


        private static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}