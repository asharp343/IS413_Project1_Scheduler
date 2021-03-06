using System;
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

        // Create database context
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


        // Displays available times
        [HttpGet]
        public IActionResult ScheduleAppointment() 
        {
            return View(new AppointmentListViewModel
            {
                Appointments = context.Appointments,


            }) ;
        }

        [HttpPost]
        public IActionResult ScheduleAppointment(DateTime ScheduledTime)
        {
            return RedirectToAction("AddAppointmentInfo", ScheduledTime);
        }

        // Displays form to add appointment info
        [HttpGet]
        public IActionResult AddAppointmentInfo(DateTime ScheduledTime)
        {
            if (ScheduledTime == DateTime.MinValue)            {                ViewBag.Time = "";            }
            else            {                ViewBag.Time = ScheduledTime.ToString("s");            }
            return View();
        }
        
        [HttpPost]
        public IActionResult AddAppointmentInfo(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                context.Appointments.Add(appointment);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Time = appointment.DateAndTime.ToString("s");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ViewAppointments()
        {


            return View(new AppointmentListViewModel {


                //Appointments = context.Appointments.Where(p => p.DateAndTime > DateTime.Now), // Displays only future dates
                Appointments = context.Appointments.OrderBy(p => p.DateAndTime)

            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
