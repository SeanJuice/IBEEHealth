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
        IBEEHEALTHEntities2 db = new IBEEHEALTHEntities2();
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
           
            var hashedPassword = ComputeSha256Hash(Password);
            var usernameExist = db.User.Where(e => e.Email == Email);
            var passwordExist = db.User.Where(e => e.Password == hashedPassword);

            if ((passwordExist.ToList().Count != 0) && (usernameExist.ToList().Count != 0))
            {
                var usser = db.User.Where(usr => usr.Email == Email && usr.Password == hashedPassword);

                if (usser.Select(m => m.UserType).ToString() == "Admin")
                {

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string Email, string Name, string Surname, string Password)
        {
            var Exists = db.User.Where(e => e.Name == Name);
            try
            {
                if (Exists.ToList().Count == 0)
                {
                    User NewUser = new User();
                    NewUser.Name = Name;
                    NewUser.Surname = Surname;
                    NewUser.Email = Email;
                    var hashedPassword = ComputeSha256Hash(Password);
                    NewUser.Password = hashedPassword;

                    db.User.Add(NewUser);
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

            return View();
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
            return View();
        }
    

    public ActionResult MealPlanVegan()
        {
            return View();
        }
        public ActionResult MealPlanVegetarian()
        {
            return View();
        }
        public List<MealPlan> rcs = new List<MealPlan>{
                new MealPlan{
                    MealPlanID = 3,
                    Name = "Gluten-Free Pumpkin Waffles",
                    Description = "These gluten-free spiced pumpkin waffles with your choice of toppings will soon" +
                    " be a new family favorite."+
                    "These gluten-free spiced pumpkin waffles with your choice of toppings will soon" +
                    " be a new family favorite.",
                    cover = "http://images.media-allrecipes.com/userphotos/960x960/4552475.jpg"
                },
                new MealPlan{
                    MealPlanID = 2,
                    Name = "Chocolate-Peanut Butter Protein Shake",
                    Description = "This creamy high-protein shake will keep you satisfied for hours and tastes " +
                    "like a chocolate-peanut butter banana milkshake. You don't even need to add protein " +
                    "powder, thanks to the naturally occurring protein in the soymilk, Greek yogurt and " +
                    "peanut butter.",
                    cover = "https://images.media-allrecipes.com/userphotos/300x300/4578872.jpg"
                },
                new MealPlan{
                    MealPlanID = 1,
                    Name = "Waffle with Nut Butter, Banana & Chocolate Chips",
                    Description = "Top a whole-grain freezer waffle with nut butter, banana slices and" +
                    " chocolate chips for a decadent-tasting and healthy breakfast or snack you can whip" +
                    " up when you're short on time. This high-protein, high-fiber breakfast may be ready" +
                    " before your coffee is finished brewing.",
                    cover = "http://images.media-allrecipes.com/userphotos/960x960/7062357.jpg"
                },
            };
        public ActionResult MealPlanDetails()
        {
            var vm = new MealPlanViewModel
            {
                mealplans = rcs
            };


            return View(vm);
        }
        
        public ActionResult ShowDetails()
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

            IBEEHEALTHEntities2 db = new IBEEHEALTHEntities2();
            User newUser = new User();

            newUser.Height = Height;
            newUser.Weight = Weight;

            db.User.Add(newUser);
            db.SaveChanges();

            power = Math.Pow((Height/100), 2);
            BMI = Weight / power;

            ViewBag.Result = Math.Round(BMI,1);


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