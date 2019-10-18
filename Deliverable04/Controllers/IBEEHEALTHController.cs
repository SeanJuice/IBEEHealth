using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Deliverable04.Controllers
{
    public class IBEEHEALTHController : Controller
    {
        // GET: IBEEHEALTH
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
    }
}