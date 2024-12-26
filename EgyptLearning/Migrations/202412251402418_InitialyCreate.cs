namespace EgyptLearning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialyCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseCode = c.String(nullable: false, maxLength: 128),
                        CourseName = c.String(nullable: false),
                        Duration = c.Int(nullable: false),
                        CoursePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CourseCode);
            
            CreateTable(
                "dbo.Teaches",
                c => new
                    {
                        TeachesID = c.Int(nullable: false, identity: true),
                        TeacherID = c.Int(nullable: false),
                        CourseCode = c.String(nullable: false, maxLength: 128),
                        StudentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeachesID)
                .ForeignKey("dbo.Courses", t => t.CourseCode, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID)
                .Index(t => t.CourseCode)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Email = c.String(),
                        SocialStatus = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.Guardians",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        City = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Students", t => t.StudentID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Method = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherID = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(nullable: false, maxLength: 100),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TeacherID);
            
            CreateTable(
                "dbo.TeacherPhoneNumbers",
                c => new
                    {
                        PhoneNumberID = c.Int(nullable: false, identity: true),
                        TeacherID = c.Int(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PhoneNumberID)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID);
            
            CreateTable(
                "dbo.WorkTrainings",
                c => new
                    {
                        WorkTrainingID = c.Int(nullable: false, identity: true),
                        TrainerID = c.Int(nullable: false),
                        TraineeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WorkTrainingID)
                .ForeignKey("dbo.Teachers", t => t.TraineeID)
                .ForeignKey("dbo.Teachers", t => t.TrainerID)
                .Index(t => t.TrainerID)
                .Index(t => t.TraineeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkTrainings", "TrainerID", "dbo.Teachers");
            DropForeignKey("dbo.WorkTrainings", "TraineeID", "dbo.Teachers");
            DropForeignKey("dbo.Teaches", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.TeacherPhoneNumbers", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.Teaches", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Payments", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Guardians", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Teaches", "CourseCode", "dbo.Courses");
            DropIndex("dbo.WorkTrainings", new[] { "TraineeID" });
            DropIndex("dbo.WorkTrainings", new[] { "TrainerID" });
            DropIndex("dbo.TeacherPhoneNumbers", new[] { "TeacherID" });
            DropIndex("dbo.Payments", new[] { "StudentID" });
            DropIndex("dbo.Guardians", new[] { "StudentID" });
            DropIndex("dbo.Teaches", new[] { "StudentID" });
            DropIndex("dbo.Teaches", new[] { "CourseCode" });
            DropIndex("dbo.Teaches", new[] { "TeacherID" });
            DropTable("dbo.WorkTrainings");
            DropTable("dbo.TeacherPhoneNumbers");
            DropTable("dbo.Teachers");
            DropTable("dbo.Payments");
            DropTable("dbo.Guardians");
            DropTable("dbo.Students");
            DropTable("dbo.Teaches");
            DropTable("dbo.Courses");
        }
    }
}
