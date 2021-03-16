using System;
using System.ComponentModel.DataAnnotations;

namespace IS413_Project1_Scheduler.Models
{
    public class Appointment
    {
        public Appointment()
        {
        }

        [Key]
        [Required]
        public int AppointmentId { get; set; }

        [Required]
        public string GroupName { get; set; }

        [Required]
        public int GroupSize { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
