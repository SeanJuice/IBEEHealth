using Deliverable04.Models;
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

        public ActionResult Recommendation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Recommendation(double Height, double Weight)
        {
            double BMI;
            double power;

            IBEEHEALTHEntities db = new IBEEHEALTHEntities();
            User newUser = new User();

            newUser.Height = Height;
            newUser.Weight = Weight;

            db.Users.Add(newUser);
            db.SaveChanges();

            power = Math.Pow((Height/100), 2);
            BMI = Weight / power;

            ViewBag.Result = Math.Round(BMI,1);


            return View("Recommendation");
        }
    }
}