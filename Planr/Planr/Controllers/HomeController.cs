﻿using System;
using System.Web.Mvc;
using Planr.Models.PlanrModels;

// HomeController Class
// This class is responsible for dealing with connections to the Dashboard and Admin pages, as well as their associated AJAX calls

//TODO: restrict admin page to admins, and dashboard to students

namespace Planr.Controllers
{
    public class HomeController : Controller
    {
        // This method simply allows a user to view the Dashboard page

        public ActionResult Dashboard()
        {
            return View();
        }

        // This method simply allows a user to view the Admin page

        public ActionResult Admin()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        // This method returns the saved sequence of the currently logged in user, retrieved from the Database

        [HttpPost]
        public JsonResult GetSequence() //receives AJAX call from front-end and returns a JSON array
        {
            return Json(DBHelper.GetSequence(Session["username"].ToString()));
        }

        // This method returns the saved schedule of the currently logged in user, retrieved from the Database

        [HttpPost]
        public JsonResult ViewSavedSchedule()
        {
            return Json(DBHelper.GetSchedule(Session["username"].ToString()));
        }

        // This method accepts a sequence object from the front-end, and writes it to the database for the currently logged in user
        // 0 = SUCCESS, 1 = ERROR

        [HttpPost]
        public JsonResult SaveSequence(Sequence sequence)
        {
            return Json(DBHelper.SaveSequence(Session["username"].ToString(), sequence));
        }

        // This method returns the saved record of the currently logged in user, retrieved from the Database

        [HttpPost]
        public JsonResult ViewRecord()
        {
            return Json(DBHelper.GetRecord(Session["username"].ToString()));
        }

        // This method accepts a new password string from the front-end, and writes it to the database for the currently logged in user
        // 0 = SUCCESS, 1 = ERROR

        [HttpPost]
        public JsonResult ChangePassword(String newPassword)
        {
            return Json(DBHelper.SetPassword(Session["username"].ToString(), newPassword));
        }

        // This method returns a collection of schedules for the currently logged in user

        [HttpPost]
        public JsonResult GenerateSchedules(Student.Preference prefs)
        {
            return Json(DBHelper.GenerateSchedules(Session["username"].ToString(), prefs));
        }

        // This method accepts a Schedule object from the front-end, and writes it to the database for the currently logged in user
        // 0 = SUCCESS, 1 = ERROR

        [HttpPost]
        public JsonResult SaveSchedule(Schedule schedule)
        {
            return Json(DBHelper.SaveSchedule(Session["username"].ToString(), schedule));
        }

        // This method accepts a Student.Preferences object from the front-end, and writes it to the database for the currently logged in user
        // 0 = SUCCESS, 1 = ERROR

        [HttpPost]
        public JsonResult SavePreferences(Student.Preference prefs)
        {
            return Json(DBHelper.SavePreferences(Session["username"].ToString(), prefs));
        }
    }
}