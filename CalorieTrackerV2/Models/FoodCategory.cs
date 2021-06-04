using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CalorieTrackerV2.Models
{
    public class FoodCategory
    {
        //Olly Swan 18/05/21
        //getters and setters for food category
        [Key]
        public int CategoryId { get; set; }

        
        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        //Navigational property
        public List<Food> Foods { get; set; }
    }
}