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
          
            ViewBag.time = hour < 12 ? "Good Morning" : "Good Afternoon";
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
            Repository.AddResponse(guestResponse);
            
            return View("Thanks", guestResponse);
        }

        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(guest => guest.WillAttend == true)) ;
        }


    }
}
