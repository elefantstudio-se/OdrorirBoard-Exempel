using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdrorirBoard.Areas.BackEnd.Controllers
{
    public class AdminController : Controller
    {
        // GET: BackEnd/Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}