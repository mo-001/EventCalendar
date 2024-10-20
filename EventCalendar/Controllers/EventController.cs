using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EventCalendar.Models;

namespace EventCalendar.Controllers
{
    public class EventController : Controller
    {
        /**
         * 
         */
        public IActionResult Index(int month, int year=2024)
        {
            if (month > 12)
            {
                month = 1;
                year += 1;
            }
            else if (month < 1)
            {
                month = 12;
                year -= 1;
            }

            ViewBag.month = month;
            ViewBag.year = year;
            return View();
        }

        /**
         */
        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        
    }
}
