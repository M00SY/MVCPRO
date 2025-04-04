using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Dal.Entities
{
    public class Department : Base
    {
       
        [Required]
        [MaxLength(6)]
        [DisplayName("Department Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Department Code")]

        public string Code { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public ICollection<Employee>? Employees { get; set; }
    }
}
