using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.Xml.Linq;

namespace EgyptLearning.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=DefaultConnection") // Specify your connection string
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<Teaches> Teaches { get; set; }
        public DbSet<WorkTraining> WorkTrainings { get; set; }
        public DbSet<TeacherPhoneNumber> TeacherPhoneNumbers { get; set; }
        //public DbSet<TeacherQualification> TeacherQualifications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure WorkTraining relationships
            modelBuilder.Entity<WorkTraining>()
                .HasRequired(wt => wt.Trainer)
                .WithMany(t => t.TrainerWorkTrainings)
                .HasForeignKey(wt => wt.TrainerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkTraining>()
                .HasRequired(wt => wt.Trainee)
                .WithMany(t => t.TraineeWorkTrainings)
                .HasForeignKey(wt => wt.TraineeID)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

    }

}