
using G_ASP_NET_83_EFCore3.Context;
using G_ASP_NET_83_EFCore3.Entities.Enums;

namespace G_ASP_NET_83_EFCore3.Operations
{
    public static class UpdateOperations
    {
        // Change Course Price
        public static void ChangeCoursePrice(
            AppDbContext context,
            int courseId,
            decimal newPrice)
        {
            if (newPrice < 0)
            {
                Console.WriteLine("Price cannot be negative.");
                return;
            }

            var course = context.Courses.Find(courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            course.Price = newPrice;

            context.SaveChanges();

            Console.WriteLine("Course price updated successfully.");
        }

        // Update Enrollment Progress
        public static void UpdateProgress(
            AppDbContext context,
            int studentId,
            int courseId,
            int newProgress)
        {
            if (newProgress < 0 || newProgress > 100)
            {
                Console.WriteLine("Progress must be between 0 and 100.");
                return;
            }

            var enrollment = context.Enrollments
                .Find(studentId, courseId);

            if (enrollment == null)
            {
                Console.WriteLine("Enrollment not found.");
                return;
            }

            enrollment.Progress = newProgress;

            if (newProgress == 100)
            {
                enrollment.Status = EnrollmentStatus.Completed;
            }

            context.SaveChanges();

            Console.WriteLine("Enrollment progress updated successfully.");
        }

        // Publish Course
        public static void PublishCourse(
            AppDbContext context,
            int courseId)
        {
            var course = context.Courses.Find(courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            if (course.IsPublished)
            {
                Console.WriteLine("Course is already published.");
                return;
            }

            course.IsPublished = true;
            course.PublishedDate = DateTime.Now;

            context.SaveChanges();

            Console.WriteLine("Course published successfully.");
        }
    }
}
