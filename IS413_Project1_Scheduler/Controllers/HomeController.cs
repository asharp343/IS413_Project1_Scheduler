﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IS413_Project1_Scheduler.Models;
using IS413_Project1_Scheduler.Models.ViewModels;

namespace IS413_Project1_Scheduler.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private AppointmentListContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, AppointmentListContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ScheduleAppointment() 
        {
            return View(new AppointmentListViewModel
            {
                Appointments = context.Appointments,

                Groups = context.Groups,

            }) ;
        }

        [HttpPost]
        public IActionResult ScheduleAppointment(DateTime ScheduledTime)
        {
            return View("AddAppointmentInfo", ScheduledTime);
        }

        [HttpGet]
        public IActionResult AddAppointmentInfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAppointmentInfo(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                context.Groups.Add(appointment.Group);
                context.Appointments.Add(appointment);
                context.SaveChanges();
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ViewAppointments()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
