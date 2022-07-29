using Microsoft.EntityFrameworkCore;
namespace WebApplication7.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Job { get; set; }
        public int Salary { get; set; }
        public int Deptno { get; set; }
    }

    public class EmployeeDContext : DbContext
    {
        public DbSet<Employee> employees { get; set; }

        public EmployeeDContext(DbContextOptions<EmployeeDContext> options) : base(options)
        {

        }
    }
}
