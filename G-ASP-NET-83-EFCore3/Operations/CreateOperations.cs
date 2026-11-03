
using G_ASP_NET_83_EFCore3.Context;
using G_ASP_NET_83_EFCore3.Entities;
using G_ASP_NET_83_EFCore3.Entities.Enums;

namespace G_ASP_NET_83_EFCore3.Operations
{
    public static class CreateOperations
    {
        // Add Instructor
        public static void AddInstructor(AppDbContext context)
        {
            var instructor = new Instructor
            {
                FullName = "New Instructor",
                Email = "newinstructor@example.com",
                Bio = "Backend Development Instructor",
                JoinedDate = DateTime.Now
            };

            context.Instructors.Add(instructor);
            context.SaveChanges();

            Console.WriteLine($"Instructor added successfully. ID: {instructor.Id}");
        }

        // Add Course
        public static void AddCourse(
            AppDbContext context,
            int instructorId,
            int categoryId)
        {
            bool instructorExists = context.Instructors
                .Any(i => i.Id == instructorId);

            bool categoryExists = context.Categories
                .Any(c => c.Id == categoryId);

            if (!instructorExists)
            {
                Console.WriteLine("Instructor not found. Course was not added.");
                return;
            }

            if (!categoryExists)
            {
                Console.WriteLine("Category not found. Course was not added.");
                return;
            }

            var course = new Course
            {
                Title = "New Course",
                Description = "Course Description",
                Price = 500,
                Level = CourseLevel.Beginner,
                IsPublished = false,
                PublishedDate = null,
                InstructorId = instructorId,
                CategoryId = categoryId
            };

            context.Courses.Add(course);
            context.SaveChanges();

            Console.WriteLine($"Course added successfully. ID: {course.Id}");
        }

        // Add Several Students
        public static void AddStudents(AppDbContext context)
        {
            var students = new List<Student>
            {
                new Student
                {
                    FullName = "Khaled Mohamed",
                    Email = "khaled@example.com",
                    DateOfBirth = new DateTime(2002, 6, 10)
                },
                new Student
                {
                    FullName = "Nour Ahmed",
                    Email = "nour@example.com",
                    DateOfBirth = new DateTime(2003, 4, 15)
                },
                new Student
                {
                    FullName = "Mariam Ali",
                    Email = "mariam@example.com",
                    DateOfBirth = new DateTime(2001, 9, 20)
                }
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            foreach (var student in students)
            {
                Console.WriteLine(
                    $"Student added: {student.FullName} | ID: {student.Id}");
            }
        }

        // Enroll Student
        public static void EnrollStudent(
            AppDbContext context,
            int studentId,
            int courseId)
        {
            bool studentExists = context.Students
                .Any(s => s.Id == studentId);

            if (!studentExists)
            {
                Console.WriteLine("Student not found. Enrollment refused.");
                return;
            }

            var course = context.Courses
                .FirstOrDefault(c => c.Id == courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found. Enrollment refused.");
                return;
            }

            if (!course.IsPublished)
            {
                Console.WriteLine("Course is not published. Enrollment refused.");
                return;
            }

            bool alreadyEnrolled = context.Enrollments
                .Any(e => e.StudentId == studentId &&
                          e.CourseId == courseId);

            if (alreadyEnrolled)
            {
                Console.WriteLine("Student is already enrolled in this course.");
                return;
            }

            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrollmentDate = DateTime.Now,
                Progress = 0,
                Status = EnrollmentStatus.Active,
                FinalGrade = null
            };

            context.Enrollments.Add(enrollment);
            context.SaveChanges();

            Console.WriteLine("Student enrolled successfully.");
        }
    }
}
