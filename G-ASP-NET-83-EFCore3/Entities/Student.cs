using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_ASP_NET_83_EFCore3.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }


        //FK 

        #region Navigation Properties
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        #endregion
    }
}
