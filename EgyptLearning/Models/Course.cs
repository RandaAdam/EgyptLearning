using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EgyptLearning.Models
{
    public class Course
    {
        [Key]
        public string CourseCode { get; set; }

        [Required]
        public string CourseName { get; set; }

        public int Duration { get; set; } // Duration in days or weeks
        public decimal CoursePrice { get; set; }

        public ICollection<Teaches> Teaches { get; set; }
    }

}