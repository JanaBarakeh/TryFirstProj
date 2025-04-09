using System.ComponentModel.DataAnnotations;

namespace TryFirstProj.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string? EmployeeName { get; set; }

        [Required]
        public string? EmployeePhone { get; set; }

        public string? EmployeeEmail { get; set; }

        public int? EmployeeAge { get; set; }

        public decimal? EmployeeSalary { get; set; }


    }
}
