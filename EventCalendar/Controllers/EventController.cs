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

        /**
         * @method - Create
         * @return - View
         * A method that is designed to return the create view
         */
        public IActionResult Create()
        {
            return View("Create");
        }
        /**
         * @method - Update
         * @param - id - the id of the event to get
         * @return - View
         * A method that is designed to return the update view with the retrieved event
         */
        public IActionResult Update(int id)
        {
            Event e = _db.RetrieveEvent(id);
            return View("Update", e);
        }
        /**
         * @method - Delete
         * @return - View
         * A method that is designed to return the delete view
         */
        public IActionResult Delete()
        {
            return View();
        }


        /**
         * @method - Create (post)
         * @return - current page
         * @params - id, title, description, start_date, end_date (event details)
         * A method that is designed to create a new event so that it can be stored in the SQLite database.
         */
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
        /**
         * @method - Update (post)
         * @return - current page
         * @params - id, title, description, start_date, end_date (event details)
         * A method that is designed to update an event determined by id so that it can be stored in the SQLite database.
         */
        [HttpPost]
        public IActionResult Update(int id, string title, string description, DateTime start_date, DateTime end_date)
        {
            Console.WriteLine(start_date);
            Console.WriteLine(end_date);
            Event e = new Event();
            e.Id = id;
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
        /**
         * @method - Delete (post)
         * @return - current page
         * @params - id, title, description, start_date, end_date (event details)
         * A method that is designed to delete an event so that it is removed from the database.
         */
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
