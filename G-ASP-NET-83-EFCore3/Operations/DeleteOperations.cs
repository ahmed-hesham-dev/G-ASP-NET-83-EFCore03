
using Microsoft.EntityFrameworkCore;
using G_ASP_NET_83_EFCore3.Context;

namespace G_ASP_NET_83_EFCore3.Operations
{
    public static class DeleteOperations
    {
        // Unenroll Student
        public static void UnenrollStudent(
            AppDbContext context,
            int studentId,
            int courseId)
        {
            var enrollment = context.Enrollments
                .Find(studentId, courseId);

            if (enrollment == null)
            {
                Console.WriteLine("Enrollment not found.");
                return;
            }

            context.Enrollments.Remove(enrollment);
            context.SaveChanges();

            Console.WriteLine("Student unenrolled successfully.");
        }

        public static void TryDeleteCategory(
            AppDbContext context,
            int categoryId)
        {
            var category = context.Categories.Find(categoryId);

            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }

            try
            {
                context.Categories.Remove(category);
                context.SaveChanges();

                Console.WriteLine("Category deleted successfully.");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(
                    $"Cannot delete category: {ex.InnerException?.Message ?? ex.Message}");

                context.Entry(category).State = EntityState.Unchanged;
            }
        }

        // Safe Delete Category
        public static void SafeDeleteCategory(
            AppDbContext context,
            int categoryId)
        {
            var category = context.Categories.Find(categoryId);

            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }

            bool hasSubCategories = context.Categories
                .Any(c => c.ParentCategoryId == categoryId);

            if (hasSubCategories)
            {
                Console.WriteLine(
                    "Cannot delete category because it has sub-categories.");
                return;
            }

            context.Categories.Remove(category);
            context.SaveChanges();

            Console.WriteLine("Category deleted successfully.");
        }

        // Delete Course With Enrollments
        public static void DeleteCourse(
            AppDbContext context,
            int courseId)
        {
            var course = context.Courses.Find(courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            int enrollmentsBefore = context.Enrollments
                .Count(e => e.CourseId == courseId);

            Console.WriteLine(
                $"Enrollments before deleting course: {enrollmentsBefore}");

            context.Courses.Remove(course);
            context.SaveChanges();

            int enrollmentsAfter = context.Enrollments
                .Count(e => e.CourseId == courseId);

            Console.WriteLine(
                $"Enrollments after deleting course: {enrollmentsAfter}");

            Console.WriteLine("Course deleted successfully.");

           
        }
    }
}
