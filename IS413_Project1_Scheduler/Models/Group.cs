using System;
using System.ComponentModel.DataAnnotations;

namespace IS413_Project1_Scheduler.Models
{
    public class Group
    {
        public Group()
        {
        }

        [Key]
        [Required]
        public int GroupId { get; set; }

        [Required]
        public string GroupName { get; set; }

        [Required]
        public string Email { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
