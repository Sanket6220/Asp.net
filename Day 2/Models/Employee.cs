using System.ComponentModel.DataAnnotations;
namespace WebApplication4.Models
  
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        public string Job { get; set; }
        public int Salary { get; set; }
        public int Deptno { get; set; }

    }
}
