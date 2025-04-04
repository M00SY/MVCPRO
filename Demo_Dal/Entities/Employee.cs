using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Dal.Entities
{
    public class Employee :Base
    {
        
        [Required]
        [StringLength(50,MinimumLength = 10)]
        [DisplayName("Full Name")]
        public string Name { get; set; }

        public string Address { get; set; }

        [Column(TypeName = "money")]
        public decimal Salary { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DateTime HireDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
