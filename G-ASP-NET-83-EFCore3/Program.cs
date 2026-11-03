
using G_ASP_NET_83_EFCore3.Context;
using G_ASP_NET_83_EFCore3.Entities;
using G_ASP_NET_83_EFCore3.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace G_ASP_NET_83_EFCore3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDbContext();

            if (!context.Students.Any())
            {
                context.Students.AddRange(
                    new Student
                    {
                        // id identity will be generated automatically by the database
                        FullName = "Ali Mohamed",
                        Email = "ali@example.com",
                        DateOfBirth = new DateTime(2002, 5, 10)
                    },
                    new Student
                    {
                        FullName = "Omar Ahmed",
                        Email = "omar@example.com",
                        DateOfBirth = new DateTime(2001, 8, 15)
                    },
                    new Student
                    {
                        FullName = "Sara Hassan",
                        Email = "sara@example.com",
                        DateOfBirth = new DateTime(2003, 2, 20)
                    },
                    new Student
                    {
                        FullName = "Mona Ali",
                        Email = "mona@example.com",
                        DateOfBirth = new DateTime(2002, 11, 5)
                    },
                    new Student
                    {
                        FullName = "Youssef Mahmoud",
                        Email = "youssef@example.com",
                        DateOfBirth = new DateTime(2001, 4, 25)
                    }
                );

                context.SaveChanges();
            }

            // Get Students IDs
            var aliId = context.Students
                .Where(s => s.Email == "ali@example.com")
                .Select(s => s.Id)
                .First();

            var omarId = context.Students
                .Where(s => s.Email == "omar@example.com")
                .Select(s => s.Id)
                .First();

            var saraId = context.Students
                .Where(s => s.Email == "sara@example.com")
                .Select(s => s.Id)
                .First();

            var monaId = context.Students
                .Where(s => s.Email == "mona@example.com")
                .Select(s => s.Id)
                .First();

            var youssefId = context.Students
                .Where(s => s.Email == "youssef@example.com")
                .Select(s => s.Id)
                .First();

            // Seed Enrollments
            if (!context.Enrollments.Any())
            {
                context.Enrollments.AddRange(
                    new Enrollment
                    {
                        StudentId = aliId,
                        CourseId = 1,
                        EnrollmentDate = new DateTime(2025, 5, 1),
                        Progress = 100,
                        Status = EnrollmentStatus.Completed,
                        FinalGrade = 95
                    },
                    new Enrollment
                    {
                        StudentId = aliId,
                        CourseId = 2,
                        EnrollmentDate = new DateTime(2025, 5, 5),
                        Progress = 35,
                        Status = EnrollmentStatus.Active,
                        FinalGrade = null
                    },
                    new Enrollment
                    {
                        StudentId = omarId,
                        CourseId = 1,
                        EnrollmentDate = new DateTime(2025, 5, 2),
                        Progress = 40,
                        Status = EnrollmentStatus.Dropped,
                        FinalGrade = null
                    },
                    new Enrollment
                    {
                        StudentId = omarId,
                        CourseId = 3,
                        EnrollmentDate = new DateTime(2025, 5, 6),
                        Progress = 100,
                        Status = EnrollmentStatus.Completed,
                        FinalGrade = 88
                    },
                    new Enrollment
                    {
                        StudentId = saraId,
                        CourseId = 2,
                        EnrollmentDate = new DateTime(2025, 5, 7),
                        Progress = 60,
                        Status = EnrollmentStatus.Active,
                        FinalGrade = null
                    },
                    new Enrollment
                    {
                        StudentId = saraId,
                        CourseId = 5,
                        EnrollmentDate = new DateTime(2025, 5, 8),
                        Progress = 100,
                        Status = EnrollmentStatus.Completed,
                        FinalGrade = 92
                    },
                    new Enrollment
                    {
                        StudentId = monaId,
                        CourseId = 3,
                        EnrollmentDate = new DateTime(2025, 5, 9),
                        Progress = 20,
                        Status = EnrollmentStatus.Dropped,
                        FinalGrade = null
                    },
                    new Enrollment
                    {
                        StudentId = youssefId,
                        CourseId = 5,
                        EnrollmentDate = new DateTime(2025, 5, 10),
                        Progress = 70,
                        Status = EnrollmentStatus.Active,
                        FinalGrade = null
                    }
                );

                context.SaveChanges();
            }

            Console.WriteLine("Seeding completed successfully!");
        }
    }
}
