using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CalorieTrackerV2.Models
{
    public class Food
    {
        //Olly Swan 18/05/21
        //Getters and setters for Food
        [Key]
        public int FoodId { get; set; }

        [Required]
        public string FoodName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Calories")]
        public int AmountOfCalories { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        //Navigation property
        [ForeignKey("FoodCategory")]
        public int CategoryId { get; set; }
        public FoodCategory FoodCategory { get; set; }
    }
}