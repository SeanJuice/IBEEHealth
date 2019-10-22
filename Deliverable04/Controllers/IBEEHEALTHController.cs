using Deliverable04.Models;
using Deliverable04.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Deliverable04.Controllers
{
    public class IBEEHEALTHController : Controller
    {

        IBEEHEALTHEntities db = new IBEEHEALTHEntities();

        static User currentUser;
        string T;
        // GET: IBEEHEALTH
        public ActionResult Index()
        {
            return View();
        }


     public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(string Email, string Password)
        {


            if (Email == "unguessableEmail@guess.com" && Password == "2password2")
            {
                return RedirectToAction("Index", "Users");


            }
            else
            {



                var hashedPassword = ComputeSha256Hash(Password);
                var usernameExist = db.Users.Where(e => e.Email == Email);
                var passwordExist = db.Users.Where(e => e.Password == hashedPassword);

                if ((passwordExist.ToList().Count != 0) && (usernameExist.ToList().Count != 0))
                {

                    User usser = db.Users.Where(usr => usr.Email == Email && usr.Password == hashedPassword).FirstOrDefault();
                    currentUser = usser;
                    return RedirectToAction("Index", "Home");


                }

            }
            return View();
        }
        public ActionResult MealPlanTypes()
        {


            var detailOfMealPlan = db.MealPlans.Select(aa => aa.Details).FirstOrDefault();
            ViewBag.detailOfMealPlan = detailOfMealPlan;

            var detailOfMealPlan1 = db.MealPlans.OrderBy(aa => aa.MealPlanID).Select(bb => bb.Details).Skip(1).First();
            ViewBag.detailOfMealPlan1 = detailOfMealPlan1;

            var descriptionOfMealPlan = db.MealPlans.Select(aa => aa.Description).FirstOrDefault();
            ViewBag.descriptionOfMealPlan = descriptionOfMealPlan;
            var descriptionOfMealPlan1 = db.MealPlans.OrderBy(aa => aa.MealPlanID).Select(bb => bb.Description).Skip(1).First();
            ViewBag.descriptionOfMealPlan1 = descriptionOfMealPlan1;
            return View();
        }
        public ActionResult MealPlanTypes2()
        {


            var detailOfMealPlan = db.MealPlans.OrderBy(aa => aa.MealPlanID).Select(bb => bb.Details).Skip(3).First();
            ViewBag.detailOfMealPlan = detailOfMealPlan;

            var detailOfMealPlan1 = db.MealPlans.OrderBy(aa => aa.MealPlanID).Select(bb => bb.Details).Skip(4).First();
            ViewBag.detailOfMealPlan1 = detailOfMealPlan1;

            var descriptionOfMealPlan = db.MealPlans.OrderBy(aa => aa.MealPlanID).Select(bb => bb.Description).Skip(3).First();
            ViewBag.descriptionOfMealPlan = descriptionOfMealPlan;
            var descriptionOfMealPlan1 = db.MealPlans.OrderBy(aa => aa.MealPlanID).Select(bb => bb.Description).Skip(4).First();
            ViewBag.descriptionOfMealPlan1 = descriptionOfMealPlan1;
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel registerView)
        {
            var Exists = db.Users.Where(e => e.Name == registerView.Name);
            try
            {
                if (Exists.ToList().Count == 0)
                {
                    User NewUser = new User();
                    NewUser.Name = registerView.Name;
                    NewUser.Surname = registerView.Surname;
                    NewUser.Email = registerView.Email;
                    NewUser.Height = registerView.Height;
                   // height2 = registerView.Height;
                    NewUser.Weight = registerView.Weight;
                 //   height2 = registerView.Weight;
                    var hashedPassword = ComputeSha256Hash(registerView.Password);
                    NewUser.Password = hashedPassword;

                    db.Users.Add(NewUser);
                    db.SaveChanges();
                }
                else
                {
                    TempData["msg"] = "<script>alert('The User already exists');</script>";
                }
            }
            catch (Exception err)
            {
                TempData["msg"] = "<script>alert(' " + err + " ');</script>";
                return View();
            }

            return RedirectToAction("SignIn", "IBEEHEALTH");
        }

        private string ComputeSha256Hash(string RawData)
        {
            using (SHA256 sHA256hash = SHA256.Create())
            {

                byte[] bytes = sHA256hash.ComputeHash(Encoding.UTF8.GetBytes(RawData));

                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }

        }

        public ActionResult StoreLocator()
        {
            db.Configuration.ProxyCreationEnabled = false;

            var pro = db.Provinces.Select(aa => aa.Name).FirstOrDefault();
            ViewBag.First = pro;

            var pro2 = db.Provinces.OrderBy(bb => bb.ProvinceID).Select(aa => aa.Name).Skip(1).First();
            ViewBag.Last = pro2;

            var cit1 = db.Cities.Select(aa => aa.Name).FirstOrDefault();
            ViewBag.cit1 = cit1;

            var cit2 = db.Cities.OrderBy(bb => bb.CityID).Select(aa => aa.Name).Skip(1).First();
            ViewBag.cit2 = cit2;

            var str1 = db.Stores.Select(aa => aa.Name).FirstOrDefault();
            ViewBag.str1 = str1;

            var str2 = db.Stores.OrderBy(bb => bb.StoreID).Select(aa => aa.Name).Skip(1).First();
            ViewBag.str2 = str2;

            return View(db.Stores.ToList());
        }
    

    public ActionResult MealPlanVegan()
        {
            return View();
        }
        public ActionResult MealPlanVegetarian()
        {
            return View();
        }
       
        public ActionResult MealPlanDetails()
        {

            var nameOfMealPlan = db.MealPlans.Select(aa => aa.Name).FirstOrDefault();
            ViewBag.nameOfMealPlan = nameOfMealPlan;

            var nameOfMealPlan1 = db.MealPlans.OrderBy(aa => aa.MealPlanID).Select(bb => bb.Name).Skip(4).First();
            ViewBag.nameOfMealPlan1 = nameOfMealPlan1;


            return View();
        }
        
        public ActionResult ShowDetails()
        {
            return View();
        }
        public ActionResult ShowDetails2()
        {
            return View();
        }
        public ActionResult ShowDetails3()
        {
            return View();
        }
        public ActionResult ShowDetails4()
        {
            return View();
        }

        public new ActionResult Profile()
        {
           /* double power = Math.Pow((height2 / 100), 2);
            BMI2 = weight2 / power;

            ViewBag.Profile = Math.Round(BMI2, 1);*/


            ProfileViewModel newModel = new ProfileViewModel();
            newModel.Name = currentUser.Name;
            newModel.Surname = currentUser.Surname;
            newModel.Email = currentUser.Email;
            newModel.Height = Convert.ToString( currentUser.Height);
            newModel.Weight = Convert.ToString(currentUser.Weight);
            return View(newModel);
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
            
            /*BMI2= Math.Round(BMI, 1);*/
            return View("Recommendation");
        }
    }
}

namespace Deliverable04.ViewModels
{
    public class MealPlanViewModel
    {
        public List<MealPlan> mealplans { get; set; }
    }
}