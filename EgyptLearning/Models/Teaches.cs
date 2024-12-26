using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EgyptLearning.Models
{
    public class Teaches
    {
        [Key]
        public int TeachesID { get; set; }

        [Required]
        public int TeacherID { get; set; }

        [Required]
        public string CourseCode { get; set; }

        [Required]
        public int StudentID { get; set; }

        [ForeignKey("TeacherID")]
        public Teacher Teacher { get; set; }

        [ForeignKey("CourseCode")]
        public Course Course { get; set; }

        [ForeignKey("StudentID")]
        public Student Student { get; set; }
    }

}