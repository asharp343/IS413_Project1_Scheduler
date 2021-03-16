using System;
using Microsoft.EntityFrameworkCore;

namespace IS413_Project1_Scheduler.Models
{
    public class AppointmentListContext : DbContext
    {
        public AppointmentListContext (DbContextOptions<AppointmentListContext> options) : base(options)
        { }

        public DbSet<Appointment> Appointments { get; set; }
    }
}
