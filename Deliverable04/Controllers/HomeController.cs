using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Deliverable04.Models;
using Deliverable04.ViewModels;

namespace Deliverable04.Controllers
{
    public class HomeController : Controller
    {

        IBEEHEALTHEntities db = new IBEEHEALTHEntities();


        public List<Diet> diets = new List<Diet> {

            new Diet
            {
                DietID = 1,
                Name = "Vegan Diet",
                Description = "Goddess dressing typically gets its umami-ness from anchovies, but we use miso in this super green salad recipe to keep it vegetarian. Substitute 2 chopped anchovies for the miso if you like. Or add baked tofu, poached salmon or grilled chicken for a boost of protein.",
                cover = "http://images.media-allrecipes.com/userphotos/960x960/4473418.jpg"

            },

            new Diet
            {
                DietID=3,
                Name = "Vegiterian Diet",
                Description = "The vegetarian diet involves abstaining from eating meat, fish and poultry.People often adopt a vegetarian diet for religious or personal reasons, as well as ethical issues, such as animal rights.",
                cover = "http://images.media-allrecipes.com/userphotos/960x960/6807932.jpg"
            },
             new Diet
            {
                DietID=2,
                Name = "Vegiterian Diet",
                Description = "The vegetarian diet involves abstaining from eating meat, fish and poultry.People often adopt a vegetarian diet for religious or personal reasons, as well as ethical issues, such as animal rights.",
                cover = "http://images.media-allrecipes.com/userphotos/960x960/6807932.jpg"
            }
        };
        public List<Recipe> rcs = new List<Recipe>{
                new Recipe{
                    RecipeID = 3,
                    Name = "Gluten-Free Pumpkin Waffles",
                    Description = "These gluten-free spiced pumpkin waffles with your choice of toppings will soon" +
                    " be a new family favorite.",
                    cover = "http://images.media-allrecipes.com/userphotos/960x960/4552475.jpg"
                },
                new Recipe{
                    RecipeID = 2,
                    Name = "Chocolate-Peanut Butter Protein Shake",
                    Description = "This creamy high-protein shake will keep you satisfied for hours and tastes like a chocolate-peanut butter banana milkshake. You don't even need to add protein powder, thanks to the naturally occurring protein in the soymilk, Greek yogurt and peanut butter.",
                    cover = "https://images.media-allrecipes.com/userphotos/300x300/4578872.jpg"
                },
                new Recipe{
                    RecipeID = 1,
                    Name = "Waffle with Nut Butter, Banana & Chocolate Chips",
                    Description = "Top a whole-grain freezer waffle with nut butter, banana slices and chocolate chips for a decadent-tasting and healthy breakfast or snack you can whip up when you're short on time. This high-protein, high-fiber breakfast may be ready before your coffee is finished brewing.",
                    cover = "http://images.media-allrecipes.com/userphotos/960x960/7062357.jpg"
                },
                new Recipe{
                    RecipeID = 4,
                    Name = "",
                    Description = "",
                    cover = ""
                }
            };

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [Route("{id:int}")]
        public ActionResult Recipe(int id)
        {
            Recipe recipe = db.Recipes.Where(re => re.RecipeID == id).FirstOrDefault();
            return View(recipe);
        }


        public ActionResult Recipes()
        {

            List<Recipe> recipes = db.Recipes.ToList();
            var vm = new RecipesViewModel
            {
                recipes = recipes
            };


            return View(vm);
        }

        [Route("{id:int}")]
        public ActionResult Diet(int id)
        {
            //var diet = diets.Find(element => element.DietID == id);
            Diet diet = db.Diets.Where(d => d.DietID == id).FirstOrDefault();
            List<Recipe> recipes = db.Recipes.Where(rec => rec.dietID == id).ToList();
            DietViewModel vm = new DietViewModel {
                diet = diet,
                recipes = recipes
            };
            return View(vm);
        }


        public ActionResult Diets()
        {

            List<Diet> dts = db.Diets.ToList();
            var vm2 = new DietsViewModel
            {
                diets = dts
            };


            return View(vm2);
        }
    }

}


namespace Deliverable04.ViewModels
{
    public class RecipesViewModel
    {
        public List<Recipe> recipes { get; set; }
    }

    public class RecipeViewModel
    {
        public Recipe recipe { get; set; }
    }
    public class DietViewModel
    {
        public Diet diet { get; set; }
        public List<Recipe> recipes { get; set; }
    }
    public class DietsViewModel
    {
        public List<Diet> diets { get; set; }
    }
}