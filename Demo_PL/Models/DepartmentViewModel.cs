using Demo_Dal.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Demo_PL.Models
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(6)]
        [DisplayName("Department Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Department Code")]

        public string Code { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        
    }
}
