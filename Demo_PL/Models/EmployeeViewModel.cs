using Demo_Dal.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace Demo_PL.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 10)]
        [DisplayName("Full Name")]
        public string Name { get; set; }

        public string Address { get; set; }

        [Column(TypeName = "money")]
        public decimal Salary { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DateTime HireDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
        public int DepartmentId { get; set; }
        public string? ImageUrl { get; set; }
        
        public IFormFile? Image { get; set; }
    }
}
