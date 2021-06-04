using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using CalorieTrackerV2.Models;

namespace CalorieTrackerV2.Controllers
{
    public class HomeController : Controller
    {
        //Olly Swan 18/05/21
        private ApplicationDbContext context = new ApplicationDbContext();


        [HttpGet]
        public ActionResult Contact()
        {
            //returns contact page view
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Message message)
        {
            //checking if model is valid and passes message
            if (ModelState.IsValid)
            {
                message.DateOfMessage = DateTime.Now.Date;
                context.Messages.Add(message);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(message);
        }

        public ActionResult SplashScreen()
        {
            //returns splash screen view
            return View();
        }

        public ActionResult Index()
        {
            //returns home page view
            return View();
        }

        public ActionResult About()
        {
            //returns calorie info page view
            return View();
        }

        public ActionResult Podcasts()
        {
            //Storing podcasts in list
            List<Podcast> podcasts = new List<Podcast>();

            podcasts.Add(new Podcast { Name = "HLP Episode One", FilePath = "~/Podcasts/HLP_Episode1.mp3" });
            podcasts.Add(new Podcast { Name = "HLP Episode Two", FilePath = "~/Podcasts/HLP_Episode2.mp3" });
            podcasts.Add(new Podcast { Name = "HLP Episode Three", FilePath = "~/Podcasts/HLP_Episode3.mp3" });
            podcasts.Add(new Podcast { Name = "HLP Episode Four", FilePath = "~/Podcasts/HLP_Episode4.mp3" });
            podcasts.Add(new Podcast { Name = "HLP Episode Five", FilePath = "~/Podcasts/HLP_Episode5.mp3" });
            podcasts.Add(new Podcast { Name = "HLP Episode Six", FilePath = "~/Podcasts/HLP_Episode6.mp3" });
            podcasts.Add(new Podcast { Name = "HLP Episode Seven", FilePath = "~/Podcasts/HLP_Episode7.mp3" });
            podcasts.Add(new Podcast { Name = "HLP Episode Eight", FilePath = "~/Podcasts/HLP_Episode8.mp3" });
            podcasts.Add(new Podcast { Name = "HLP Episode Nine", FilePath = "~/Podcasts/HLP_Episode9.mp3" });
            podcasts.Add(new Podcast { Name = "HLP Episode Ten", FilePath = "~/Podcasts/HLP_Episode10.mp3" });
            podcasts.Add(new Podcast { Name = "HLP Episode Eleven", FilePath = "~/Podcasts/HLP_Episode11.mp3" });
            podcasts.Add(new Podcast { Name = "HLP Episode Twelve", FilePath = "~/Podcasts/HLP_Episode12.mp3" });
            podcasts.Add(new Podcast { Name = "HLP Episode Q&A", FilePath = "~/Podcasts/HLP_Q&A.mp3" });
            return View(podcasts);
        }

       
    }
}