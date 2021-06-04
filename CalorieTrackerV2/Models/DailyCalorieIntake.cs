using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CalorieTrackerV2.Models
{
    public class DailyCalorieIntake
    {
        //Olly Swan 18/05/21

        //getters and setters for daily calorie intake
        [Key]
        public int DailyCalorieIntakeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime IntakeDate { get; set; }

        public int TotalDailyCalories { get; set; }

        //Calculates the total daily calories
        public void CalculateTotalDailyCalories(int amountOfCalories)
        {
            TotalDailyCalories = TotalDailyCalories + amountOfCalories;
        }

        //Resets total daily calories to zero
        public void ResetTotal()
        {           
            TotalDailyCalories = 0;
        }

        //Navigational property
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}