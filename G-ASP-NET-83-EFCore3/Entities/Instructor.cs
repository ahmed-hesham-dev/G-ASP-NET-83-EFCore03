using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_ASP_NET_83_EFCore3.Entities
{
    public class Instructor
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string? Bio { get; set; }

        public DateTime JoinedDate { get; set; }

        #region FK


        #endregion


        #region Navigation Properties
        public List<Course> Courses { get; set; }  = new List<Course>();

        #endregion
    }
}
