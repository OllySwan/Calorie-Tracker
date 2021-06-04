using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CalorieTrackerV2.Models
{
    public class DatabaseInitialiser : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        //Olly Swan 18/05/21
        protected override void Seed(ApplicationDbContext context)
        {
            base.Seed(context);

            //If there are no records stored in the users table
            if (!context.Users.Any())
            {
                UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                //Creating a few user accounts
                var olly = new ApplicationUser
                {
                    
                    UserName = "ollyswan88@hotmail.com",
                    Email = "ollyswan88@hotmail.com",
                    EmailConfirmed = true,
                };

                userManager.Create(olly, "member");

                var dana = new ApplicationUser
                {
                    UserName = "dana@hotmail.com",
                    Email = "dana@hotmail.com",
                    EmailConfirmed = true,
                };

                userManager.Create(dana, "member");

                //Saving changes to Database
                context.SaveChanges();

                //Creating a daily calorie intake
                var day1 = new DailyCalorieIntake
                {
                    IntakeDate = DateTime.Now,
                    User = olly,
                    TotalDailyCalories = 250,
                };

                context.DailyCalorieIntakes.Add(day1);
                context.SaveChanges();

                //Create food categories
                var meat = new FoodCategory() { CategoryName = "Meat" };
                var fish = new FoodCategory() { CategoryName = "Fish" };
                var dairy = new FoodCategory() { CategoryName = "Dairy" };
                var cereal = new FoodCategory() { CategoryName = "Cereal" };
                var fruit = new FoodCategory() { CategoryName = "Fruit" };
                var vegetables = new FoodCategory() { CategoryName = "Vegetables" };

                context.SaveChanges();

                //Adding categories to table
                context.FoodCategories.Add(meat);
                context.FoodCategories.Add(fish);
                context.FoodCategories.Add(dairy);
                context.FoodCategories.Add(cereal);
                context.FoodCategories.Add(fruit);
                context.FoodCategories.Add(vegetables);

                //saving changes to database
                context.SaveChanges();

                //Seeding database with a few food items

                //Meat
                context.Foods.Add(new Food()
                {
                    FoodName = "Steak",
                    Description = "Tasty steak of any rarity",
                    AmountOfCalories = 271,
                    ImageUrl = "/Images/Meat/steak.jpg",
                    FoodCategory = meat
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Hotdog",
                    Description = "Hot dog bun included",
                    AmountOfCalories = 350,
                    ImageUrl = "/Images/Meat/hotdog.jpg",
                    FoodCategory = meat
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Chicken",
                    Description = "Single portion of chicken",
                    AmountOfCalories = 300,
                    ImageUrl = "/Images/Meat/chicken.jpg",
                    FoodCategory = meat
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Beef",
                    Description = "A moderate amount of beef",
                    AmountOfCalories = 320,
                    ImageUrl = "/Images/Meat/beef.jpg",
                    FoodCategory = meat
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Turkey",
                    Description = "One serving of turkey",
                    AmountOfCalories = 290,
                    ImageUrl = "/Images/Meat/turkey.jpg",
                    FoodCategory = meat
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Lamb",
                    Description = "Poor lamb",
                    AmountOfCalories = 271,
                    ImageUrl = "/Images/Meat/lamb.jpg",
                    FoodCategory = meat
                });
                //End of meat

                //Adding food to Foods table

                //Fish
                context.Foods.Add(new Food()
                {
                    FoodName = "Salmon",
                    Description = "Yummy Salmon",
                    AmountOfCalories = 250,
                    ImageUrl = "/Images/Fish/Salmon.jpg",
                    FoodCategory = fish
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Prawns",
                    Description = "A plate of prawns",
                    AmountOfCalories = 150,
                    ImageUrl = "/Images/Fish/prawns.jpg",
                    FoodCategory = fish
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Cod",
                    Description = "A single Cod",
                    AmountOfCalories = 285,
                    ImageUrl = "/Images/Fish/cod.jpg",
                    FoodCategory = fish
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "hadock",
                    Description = "A single portion of hadock",
                    AmountOfCalories = 250,
                    ImageUrl = "/Images/Fish/haddock.jpg",
                    FoodCategory = fish
                });


                //End of Fish

                //Dairy
                context.Foods.Add(new Food()
                {
                    FoodName = "Milk",
                    Description = "Yummy Cow milk",
                    AmountOfCalories = 300,
                    ImageUrl = "/Images/Dairy/milk.jpg",
                    FoodCategory = dairy
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Cheese",
                    Description = "Several slices of cheese",
                    AmountOfCalories = 300,
                    ImageUrl = "/Images/Dairy/cheese.jpg",
                    FoodCategory = dairy
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Yoghurt",
                    Description = "A single Yoghurt",
                    AmountOfCalories = 350,
                    ImageUrl = "/Images/Dairy/yoghurt.jpg",
                    FoodCategory = dairy
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Cream",
                    Description = "Cream with desert",
                    AmountOfCalories = 400,
                    ImageUrl = "/Images/Dairy/cream.jpg",
                    FoodCategory = dairy
                });

                //End of diary

              
                //Adding Cereal
                context.Foods.Add(new Food()
                {
                    FoodName = "Coco pops",
                    Description = "One bowl of coco pops",
                    AmountOfCalories = 231,
                    ImageUrl = "/Images/Cereal/cocopops.jpg",
                    FoodCategory = cereal
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Frosted Flakes",
                    Description = "One bowl of frosted flakes",
                    AmountOfCalories = 220,
                    ImageUrl = "/Images/Cereal/frostedflakes.jpg",
                    FoodCategory = cereal
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Lucky Charms",
                    Description = "One bowl of lucky charms",
                    AmountOfCalories = 400,
                    ImageUrl = "/Images/Cereal/luckycharms.jpg",
                    FoodCategory = cereal
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Porridge",
                    Description = "A single bowl of porridge",
                    AmountOfCalories = 200,
                    ImageUrl = "/Images/Cereal/porridge.jpg",
                    FoodCategory = cereal
                });

                //end of adding cereal

                //Adding Fruit
                context.Foods.Add(new Food()
                {
                    FoodName = "Apple",
                    Description = "One apple",
                    AmountOfCalories = 100,
                    ImageUrl = "/Images/Fruit/apple.jpg",
                    FoodCategory = fruit
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Grapes",
                    Description = "A bunch of grapes",
                    AmountOfCalories = 70,
                    ImageUrl = "/Images/Fruit/grapes.jpg",
                    FoodCategory = fruit
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Orange",
                    Description = "One Orange",
                    AmountOfCalories = 100,
                    ImageUrl = "/Images/Fruit/orange.jpg",
                    FoodCategory = fruit
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Mango",
                    Description = "Bowl of mango",
                    AmountOfCalories = 150,
                    ImageUrl = "/Images/Fruit/mango.jpg",
                    FoodCategory = fruit
                });

                //End of adding fruit

                //Adding Veg
                context.Foods.Add(new Food()
                {
                    FoodName = "Brocoli",
                    Description = "Brocoli with dinner",
                    AmountOfCalories = 80,
                    ImageUrl = "/Images/Veg/brocoli.jpg",
                    FoodCategory = vegetables
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Carrots",
                    Description = "Carrots with a meal",
                    AmountOfCalories = 100,
                    ImageUrl = "/Images/Veg/carrots.jpg",
                    FoodCategory = vegetables
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Garlic",
                    Description = "Garlic added to a meal",
                    AmountOfCalories = 50,
                    ImageUrl = "/Images/Veg/garlic.jpg",
                    FoodCategory = vegetables
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Peas",
                    Description = "Bowl of peas",
                    AmountOfCalories = 75,
                    ImageUrl = "/Images/Veg/peas.jpg",
                    FoodCategory = vegetables
                });

                //End of adding veg

                //saving changes to database
                context.SaveChanges();
            }
        }

    }
}