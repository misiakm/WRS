using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WRS.Models;

namespace WRS.Logic
{
    public class DatabaseConnect
    {
        public DatabaseConnect()
        {
            db = new WRSDbContext();
        }

        /// <summary>
        /// Connect to the database
        /// </summary>
        public WRSDbContext db;
    }
}