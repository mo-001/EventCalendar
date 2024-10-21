using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EventCalendar.Models;
using EventCalendar.Utiltiies;

namespace EventCalendar.Controllers
{
    public class EventController : Controller
    {

        public DatabaseConnector _db = new DatabaseConnector();
        /**
         * 
         */
        // GET /
        public IActionResult Index(int month, int year = 2024)
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
            var events = _db.RetrieveEvents();
            return View(events);
        }

        /**
         */
        // GET /Details/{id}
        public IActionResult Details(int id)
        {
            Event e = _db.RetrieveEvent(id);
            return View(e);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        public IActionResult Update(int id)
        {
            Event e = _db.RetrieveEvent(id);
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

      

        [HttpPost]
        public IActionResult Create(int id, string title, string description, DateTime start_date, DateTime end_date, DatabaseConnector _db)
        {
            Event e = new Event();
            e.Title = title;
            e.Description = description;
            e.StartDate = start_date;
            e.EndDate = end_date;
            if (Validator.validateTitle(e.Title)
                && Validator.validateDescription(e.Description))
            {
                _db.StoreEvent(e);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Error");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Update(int id, string title, string description, DateTime start_date, DateTime end_date)
        {
            Event e = new Event();
            e.Title = title;
            e.Description = description;
            e.StartDate = start_date;
            e.EndDate = end_date;
            if (Validator.validateTitle(e.Title)
                && Validator.validateDescription(e.Description))
            {
                _db.UpdateEvent(e);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Error");
            }
            return View();

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Event e = new Event();
            e.Id = id;
            if(_db.RetrieveEvent(id) != null)
            {
                _db.DeleteEvent(e);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Error");
            }
            return View();
        }
    }
}
