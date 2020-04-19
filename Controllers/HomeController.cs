using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {

        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            if(hour < 12)
            {
                ViewBag.time = "Good Morning";
            }
            else if(hour > 12 && hour < 16)
            {
                ViewBag.time = "Good Afternoon";
            }
            else
            {
                ViewBag.time = "Good Evening";
            }
            //ViewBag.time = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View();
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
            
            
        }

        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(guest => guest.WillAttend == true)) ;
        }


    }
}
