﻿using System;
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

        public IEnumerable<Group> Groups { get; set; }

        public List<DateTime> AvailableTimes { get; set; } = GenerateDates();


        // Generates available time slots for the next 7 days
        public static List<DateTime> GenerateDates()
        {
            DateTime CurrentTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 8, 0, 0);
            List<DateTime> AvailableTimeSlots = new List<DateTime>();

            foreach (int i in Enumerable.Range(1, 8))
            {
                foreach (int j in Enumerable.Range(0, 13))
                {
                    AvailableTimeSlots.Add(CurrentTime);
                    CurrentTime = CurrentTime.AddHours(1);
                }
                CurrentTime = CurrentTime.Subtract(new TimeSpan(12, 0, 0));
                CurrentTime = CurrentTime.AddDays(1);
            }
            return AvailableTimeSlots;
        }

    }
}