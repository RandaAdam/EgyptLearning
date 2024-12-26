using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EgyptLearning.Models
{
    public class TeacherPhoneNumber
    {
        [Key]
        public int PhoneNumberID { get; set; }

        [Required]
        public int TeacherID { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [ForeignKey("TeacherID")]
        public Teacher Teacher { get; set; }
    }

}