using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_ASP_NET_83_EFCore3.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }
        // FK Self Referencing 
        public int? ParentCategoryId { get; set; }


        #region Navigation Properties  
        public Category? ParentCategory { get; set; }

        public ICollection<Category> SubCategories { get; set; } = new List<Category>();

        public List<Course> Courses { get; set; } = new List<Course>();
        #endregion

    }
}
