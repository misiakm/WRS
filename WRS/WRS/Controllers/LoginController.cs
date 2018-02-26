using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WRS.Logic;
using WRS.ModelsViews;
using System.ComponentModel.DataAnnotations;

namespace WRS.Controllers
{
    public class LoginController : Controller
    {
        Logs _objectLogs = new Logs();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "Login,Password")] LoginPage LP)
        {
            var err = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
            if (ModelState.IsValid)
            {
                if (_objectLogs.CurrectlyLoggedIn(LP.Login, LP.Password))
                {
                    return RedirectToAction("", "");
                }
                else
                {
                    ViewBag.Info = "Nieprawidłowe dane logowania<br>";
                }
            }                
            return View();
        }

        public void AddTestUser()
        {
            Logs.AddTestEmployee();
        }
    }
}