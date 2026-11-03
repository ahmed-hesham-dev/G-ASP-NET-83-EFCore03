using G_ASP_NET_83_EFCore3.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_ASP_NET_83_EFCore3.Entities
{
     public class Course
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public CourseLevel Level { get; set; }

        public bool IsPublished { get; set; }

        public DateTime? PublishedDate { get; set; }

        #region FK

        public int InstructorId { get; set; }
        public int CategoryId { get; set; }

        #endregion

        #region Navigation Properties
        public Instructor Instructor { get; set; }
        public Category Category { get; set; }
        public List<Enrollment> Enrollments { get; set; }


        #endregion

    }
}
