using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RDV_Backend.Model
{
	public class Appointment
	{
       
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Appointment_Id { get; set; }

            [Required]
            public int User_Id { get; set; }

            [Required]
            [MaxLength(50)]
            public string? Client_Name { get; set; }

            [Required]
            public DateTime Appointment_Date { get; set; }

            [Required]
            [MaxLength(100)]
            public string? Appointment_Subject { get; set; }
       
    }

}

