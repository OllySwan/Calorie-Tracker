using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CalorieTrackerV2.Models
{
    //Olly Swan 18/05/21
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //Navigational Property
        public List<DailyCalorieIntake> DailyCalorieIntakes { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Message> Messages { get; set; }

        public DbSet<FoodCategory> FoodCategories { get; set; }

        public DbSet<Food> Foods { get; set; }
        
        public DbSet<DailyCalorieIntake> DailyCalorieIntakes { get; set; }

        public ApplicationDbContext()
            : base("CalorieTrackerV2DbConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new DatabaseInitialiser());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}