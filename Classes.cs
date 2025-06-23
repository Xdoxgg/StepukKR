using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalClinic
{
    public class User
    {
        [Key]
        public int Id { get; set; } // Изменено на Id

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool Role { get; set; } // true for admin, false for user
    }

    public class Doctor
    {
        [Key]
        public int Id { get; set; } // Изменено на Id

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Required]
        public string Schedule { get; set; }
    }

    public class Service
    {
        [Key]
        public int Id { get; set; } // Изменено на Id

        [Required]
        public string ServiceName { get; set; }

        [Required]
        public float Price { get; set; }

        public string Description { get; set; }
    }

    public class Appointment
    {
        [Key]
        public int Id { get; set; } // Изменено на Id

        public int UserId { get; set; }
        public int DoctorId { get; set; }
        public int ServiceId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public string Status { get; set; } // e.g., "scheduled", "canceled", "rescheduled"

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }

        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; }
    }

    public class Review
    {
        [Key]
        public int Id { get; set; } // Изменено на Id

        public int UserId { get; set; }
        public int DoctorId { get; set; }

        public int Rating { get; set; }
        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }
    }
}
