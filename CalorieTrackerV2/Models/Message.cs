using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CalorieTrackerV2.Models
{
    public class Message
    {
        //Olly Swan 18/05/21
        //getters and setters for leaving a message
        [Key]
        public int MessageId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfMessage { get; set; }

        [Display(Name = "Opt in our monthly newsletter")]
        public bool SubscribtionBox { get; set; }

    }
}