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

        [Required(ErrorMessage = "Input a valid number")]
        [Range(1, 50, ErrorMessage = "Enter number between 1 and 50")]
        public int GroupSize { get; set; }

        [Required]
        public string GroupName { get; set; }

        [Required]
        public string Email { get; set; }

        [RegularExpression("^\\D?(\\d{3})\\D?\\D?(\\d{3})\\D?(\\d{4})$", ErrorMessage = "Input Phone number like 555-555-5555")]
        public string? PhoneNumber { get; set; }


    }
}
