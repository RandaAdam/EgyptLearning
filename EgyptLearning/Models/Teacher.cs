using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EgyptLearning.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }

        [Required]
        [StringLength(100)]
        public string TeacherName { get; set; }

        [Required]
        [Range(1000, 1000000)]
        public decimal Salary { get; set; }

        public virtual ICollection<WorkTraining> TrainerWorkTrainings { get; set; }
        public virtual ICollection<WorkTraining> TraineeWorkTrainings { get; set; }

        public virtual ICollection<Teaches> Teaches { get; set; }

        public virtual ICollection<TeacherPhoneNumber> PhoneNumbers { get; set; }
        //public virtual ICollection<TeacherQualification> Qualifications { get; set; }
    }


}