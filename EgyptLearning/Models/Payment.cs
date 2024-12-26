using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EgyptLearning.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required]
        public int StudentID { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Method { get; set; } // e.g., Cash, Credit Card

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("StudentID")]
        public Student Student { get; set; }
    }

}