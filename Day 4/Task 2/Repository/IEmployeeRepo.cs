using WebApplication5.Models;
namespace WebApplication5.Repository
{

    public interface IEmployeeRepo
    {
        List<Employee> GetEmployees();
        Employee GetEmployeeById(int id);
        
        void AddEmployee(Employee obj);
        void UpdateEmployee(Employee obj);
        void DeleteEmployee(int id);
        IEnumerable<Employee> GetEmployeesByDeptno(int deptno);
        IEnumerable<Employee> GetEmployeesByJob(string job);
    }
}
