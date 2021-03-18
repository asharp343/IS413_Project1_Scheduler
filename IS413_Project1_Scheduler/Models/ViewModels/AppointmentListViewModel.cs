using System;
using System.Collections.Generic;
using System.Linq;

namespace IS413_Project1_Scheduler.Models.ViewModels
{
    public class AppointmentListViewModel
    {
        public AppointmentListViewModel()
        {
        }

        

        public IEnumerable<Appointment> Appointments { get; set; }

        public List<List<DateTime>> AvailableTimes { get; set; } = GenerateDates();

        public List<DateTime> AvailableDays { get; set; } = GenerateDays();


        // Generates available time slots for the next 7 days
        public static List<List<DateTime>> GenerateDates()
        {
            DateTime CurrentTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 8, 0, 0);
            List<List<DateTime>> AvailableTimeSlots = new List<List<DateTime>>();

            foreach (int i in Enumerable.Range(1, 8))
            {
                List<DateTime> AvailableTimesInDay = new List<DateTime>();

                foreach (int j in Enumerable.Range(0, 13))
                {

                    AvailableTimesInDay.Add(CurrentTime);
                    CurrentTime = CurrentTime.AddHours(1);
                }
                AvailableTimeSlots.Add(AvailableTimesInDay);
                CurrentTime = CurrentTime.Subtract(new TimeSpan(13, 0, 0));
                CurrentTime = CurrentTime.AddDays(1);
            }
            return AvailableTimeSlots;
        }

        public static List<DateTime> GenerateDays()
        {
            DateTime CurrentTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            List<DateTime> AvailableDays = new List<DateTime>();

            foreach (int i in Enumerable.Range(1, 8))
            {
                AvailableDays.Add(CurrentTime);
                CurrentTime = CurrentTime.AddDays(1);
            }
            return AvailableDays;
        }

    }
}
