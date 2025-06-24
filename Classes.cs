namespace DantoBrick;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class User
{
    [Key]
    [Column("user_id")]
    public int Id { get; set; }
    [Column("username")]
    public string UserName {get; set;}
    [Column("password")]
    public string Password {get; set;}
    public bool Role {get; set;}
}

public class Doctor
{
    [Key]
    [Column("doctor_id")]
    public int Id { get; set; }
    [Column("first_name")]
    public string FirstName { get; set; }
    [Column("last_name")]
    public string LastName { get; set; }
    public string Specialization {get; set;}
    public string Schedule {get; set;}
}

public class Service
{
    [Key]
    [Column("service_id")]
    public int Id { get; set; }
    [Column("service_name")]
    public string ServiceName { get; set; }
    public double Price {get; set;}
    public string Description { get; set; }
}

public class Appointment
{
    [Key]
    [Column("appointment_id")]
    public int Id { get; set; }
    [Column("user_id")]
    public int UserId { get; set; }
    [Column("doctor_id")]
    public int DoctorId { get; set; } 
    [Column("service_id")]
    public int ServiceId { get; set; }
    [Column("appointment_date")]
    public DateTime AppointmentDate { get; set; }
    public string Status { get; set; }
    public User User { get; set; }
    public Doctor Doctor { get; set; }
    public Service Service { get; set; }
}

public class Review
{
    [Key]
    [Column("review_id")]
    public int Id { get; set; }
    [Column("user_id")]
    public int UserId { get; set; }
    [Column("doctor_id")]
    public int DoctorId { get; set; } // Corrected from DcotorId to DoctorId
    public int Rating { get; set; }
    public string Comment { get; set; }
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    public User User { get; set; }
    public Doctor Doctor { get; set; }
}
