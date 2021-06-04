using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CalorieTrackerV2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CalorieTrackerV2.Controllers
{
    public class FoodsController : Controller
    {
        //Olly Swan 18/05/21
        private ApplicationDbContext context = new ApplicationDbContext();


        public ActionResult AddToDailyCalories(int calorie)
        {
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser> (context));

            //Get current user's ID
            string userId = userManager.FindByEmail(User.Identity.GetUserName()).Id;
            //Get User
            ApplicationUser user = context.Users.Find(userId);
            //get the daily calorie intake of current date
            DailyCalorieIntake dailyIntake = context.DailyCalorieIntakes.Where(d => DbFunctions.TruncateTime(d.IntakeDate) == DateTime.Today).SingleOrDefault(d => d.UserId.Equals(userId));

            //If this is the first entry of the day then create dailycalorieintake and add calorie to totalcalories
            if (dailyIntake == null)
            {
                DailyCalorieIntake dci = new DailyCalorieIntake
                {
                    IntakeDate = DateTime.Now.Date,
                    User = user
                };

                dci.CalculateTotalDailyCalories(calorie);
                context.DailyCalorieIntakes.Add(dci);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            //if there is already an entry for the current date then just update the total daily calories
            dailyIntake.CalculateTotalDailyCalories(calorie);
            context.Entry(dailyIntake).State = EntityState.Modified;
            context.SaveChanges();

           

            return RedirectToAction("Index");
        }

        public ActionResult ResetTotalDailyIntake()
        {
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //Get current user's ID
            string userId = userManager.FindByEmail(User.Identity.GetUserName()).Id;
            //Get User
            ApplicationUser user = context.Users.Find(userId);
            //get the daily calorie intake of current date
            DailyCalorieIntake dailyIntake = context.DailyCalorieIntakes.Where(d => DbFunctions.TruncateTime(d.IntakeDate) == DateTime.Today).SingleOrDefault(d => d.UserId.Equals(userId));

            dailyIntake.ResetTotal();
            context.Entry(dailyIntake).State = EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("Index");
        }



        // GET: Foods
        public ActionResult Index()
        {
            //Getting all foods 
            var foods = context.Foods.ToList();

            foreach (var item in foods)
            {
                context.Entry(item).Reload(); //refresh entities
            }

            //Send alll food categories into viewbag
            ViewBag.Categories = context.FoodCategories.ToList();

            //Send users updated Daily calorie intake to display on page
            //get user id
            string id = User.Identity.GetUserId();
            //If user is logged in (id is not null)
            if (id!=null)
            {
                //Get current user's daily calorie intake for current date
                DailyCalorieIntake dailyIntake = context.DailyCalorieIntakes.Where(d => DbFunctions.TruncateTime(d.IntakeDate) == DateTime.Today).SingleOrDefault(d => d.UserId.Equals(id));

                //If there is a current daily calorie intake record then send the total calories to the view using viewbag
                if (dailyIntake != null)
                {
                    ViewBag.TotalCalories = dailyIntake.TotalDailyCalories;
                }
            }

            //Send foods to food view
            return View("FoodsView", foods);
        }

        public ActionResult Foods(int? id)
        {
            //Getting all foods that are in a specific category
            var foods = context.Foods.Where(p => p.CategoryId == id).ToList();

            //Sending all foods to view bag
            ViewBag.Categories = context.FoodCategories.ToList();

            //Send users updated Daily calorie intake to display on page
            //get user id
            string userId = User.Identity.GetUserId();
            //If user is logged in (id is not null)
            if (userId != null)
            {
                //Get current user's daily calorie intake for current date
                DailyCalorieIntake dailyIntake = context.DailyCalorieIntakes.Where(d => DbFunctions.TruncateTime(d.IntakeDate) == DateTime.Today).SingleOrDefault(d => d.UserId.Equals(userId));

                //If there is a current daily calorie intake record then send the total calories to the view using viewbag
                if (dailyIntake != null)
                {
                    ViewBag.TotalCalories = dailyIntake.TotalDailyCalories;
                }
            }

           

            return View("FoodsView", foods);
        }

        
    }
}