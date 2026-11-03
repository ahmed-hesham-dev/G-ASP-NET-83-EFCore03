
using G_ASP_NET_83_EFCore3.Context;
using G_ASP_NET_83_EFCore3.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace G_ASP_NET_83_EFCore3.Operations
{
    public static class BulkOperations
    {
        // Bulk Price Raise By 10%
        public static void RaiseCoursePrices(
            AppDbContext context,
            CourseLevel level)
        {
            int affectedRows = context.Courses
                .Where(c => c.IsPublished && c.Level == level)
                .ExecuteUpdate(setters => setters
                    .SetProperty(
                        c => c.Price,
                        c => c.Price * 1.10m));

            Console.WriteLine(
                $"{affectedRows} published courses of level {level} had their prices increased by 10%.");
        }

        // Bulk Delete Dropped Enrollments
        public static void DeleteDroppedEnrollments(
            AppDbContext context)
        {
            int affectedRows = context.Enrollments
                .Where(e => e.Status == EnrollmentStatus.Dropped)
                .ExecuteDelete();

            Console.WriteLine(
                $"{affectedRows} dropped enrollments deleted successfully.");
        }
    }
}
