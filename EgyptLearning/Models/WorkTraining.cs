using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EgyptLearning.Models
{

    public class WorkTraining
    {
        [Key]
        public int WorkTrainingID { get; set; }

        [Required]
        public int TrainerID { get; set; }

        [Required]
        public int TraineeID { get; set; }

        [ForeignKey("TrainerID")]
        [InverseProperty("TrainerWorkTrainings")]
        public virtual Teacher Trainer { get; set; }

        [ForeignKey("TraineeID")]
        [InverseProperty("TraineeWorkTrainings")]
        public virtual Teacher Trainee { get; set; }
    }


}