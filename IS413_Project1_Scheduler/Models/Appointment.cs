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
        public DateTime DateAndTime { get; set; }

        [Required]
        public Group Group { get; set; }

        [Required]
        public int GroupSize { get; set; }

        
    }
}
