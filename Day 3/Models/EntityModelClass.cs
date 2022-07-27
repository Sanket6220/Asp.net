using Microsoft.EntityFrameworkCore;
namespace WebApplication5.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Job { get; set; }
        public int Salary { get; set; }
        public int Deptno { get; set; }
    }

    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> employees { get; set; }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
         : base(options)
        {

        }
    }
}