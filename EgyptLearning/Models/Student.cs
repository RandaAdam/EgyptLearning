using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EgyptLearning.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string SocialStatus { get; set; } // "Exempt" or "Not Exempt"

        public ICollection<Payment> Payments { get; set; }
        public ICollection<Teaches> Teaches { get; set; }
        public Guardian Guardian { get; set; }
    }

}