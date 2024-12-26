using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EgyptLearning.Models
{
    public class Guardian
    {
        [Key, ForeignKey("Student")]
        public int StudentID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        public Student Student { get; set; }
    }

}