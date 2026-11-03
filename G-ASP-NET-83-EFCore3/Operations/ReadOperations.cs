
using G_ASP_NET_83_EFCore3.Context;

namespace G_ASP_NET_83_EFCore3.Operations
{
    public static class ReadOperations
    {
        // Find Course By ID
        public static void FindCourseById(
            AppDbContext context,
            int courseId)
        {
            var course = context.Courses.Find(courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            Console.WriteLine(
                $"Course: {course.Title} | Level: {course.Level} | Price: {course.Price}");
        }

        // Find Course By Title
        public static void FindCourseByTitle(
            AppDbContext context,
            string title)
        {
            var course = context.Courses
                .FirstOrDefault(c => c.Title == title);

            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            Console.WriteLine(
                $"Course: {course.Title} | Level: {course.Level} | Price: {course.Price}");
        }

        // Filter Courses By Price
        public static void FilterCoursesByPrice(
            AppDbContext context,
            decimal minPrice,
            decimal maxPrice)
        {
            if (minPrice > maxPrice)
            {
                Console.WriteLine("Invalid price range.");
                return;
            }

            var courses = context.Courses
                .Where(c => c.Price >= minPrice &&
                            c.Price <= maxPrice)
                .OrderByDescending(c => c.Price)
                .Select(c => new
                {
                    c.Title,
                    c.Level,
                    c.Price
                })
                .ToList();

            if (courses.Count == 0)
            {
                Console.WriteLine("No courses found in this price range.");
                return;
            }

            foreach (var course in courses)
            {
                Console.WriteLine(
                    $"Title: {course.Title} | Level: {course.Level} | Price: {course.Price}");
            }
        }

        // Print Direct Sub-Categories
        public static void GetSubCategories(
            AppDbContext context,
            int categoryId)
        {
            var category = context.Categories
                .FirstOrDefault(c => c.Id == categoryId);

            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }

            var subCategories = context.Categories
                .Where(c => c.ParentCategoryId == categoryId)
                .ToList();

            Console.WriteLine($"Sub-categories of {category.Name}:");

            if (subCategories.Count == 0)
            {
                Console.WriteLine("No sub-categories found.");
                return;
            }

            foreach (var subCategory in subCategories)
            {
                Console.WriteLine(
                    $"ID: {subCategory.Id} | Name: {subCategory.Name}");
            }
        }

        // Print Top-Level Categories
        public static void GetTopLevelCategories(AppDbContext context)
        {
            var categories = context.Categories
                .Where(c => c.ParentCategoryId == null)
                .ToList();

            Console.WriteLine("Top-level Categories:");

            foreach (var category in categories)
            {
                Console.WriteLine(
                    $"ID: {category.Id} | Name: {category.Name}");
            }
        }

        // Print Course Roster
        public static void GetCourseRoster(
            AppDbContext context,
            int courseId)
        {
            bool courseExists = context.Courses
                .Any(c => c.Id == courseId);

            if (!courseExists)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            var studentIds = context.Enrollments
                .Where(e => e.CourseId == courseId)
                .Select(e => e.StudentId)
                .ToList();

            Console.WriteLine($"Number of enrolled students: {studentIds.Count}");

            if (studentIds.Count == 0)
            {
                Console.WriteLine("No students enrolled in this course.");
                return;
            }

            var students = context.Students
                .Where(s => studentIds.Contains(s.Id))
                .ToList();

            Console.WriteLine("Course Roster:");

            foreach (var student in students)
            {
                Console.WriteLine(student.FullName);
            }
        }
    }
}
