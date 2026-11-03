using G_ASP_NET_83_EFCore3.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_ASP_NET_83_EFCore3.Entities
{
    public class Enrollment
    {

        // FK
        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public decimal Progress { get; set; }

        public EnrollmentStatus Status { get; set; }

        public decimal? FinalGrade { get; set; }


        #region Navigation Properties
        public Student Student { get; set; }
        public Course Course { get; set; }
        #endregion
    }
}
