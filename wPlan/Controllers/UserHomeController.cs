using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdrorirBoard.Models;

namespace OdrorirBoard.Controllers
{
    public class UserHomeController : Controller
    {
        // GET: UserHome
        public ActionResult Index()
        {
            var person = new ApplicationUser
            {

                Email = "John@Doe.com",

            };
            return View(person);
        }
    }
}