using WebApplication5.Models;
namespace WebApplication5.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        EmployeeDbContext _context;

        public EmployeeRepo(EmployeeDbContext context)
        {
            _context = context;
        }


        void IEmployeeRepo.AddEmployee(Employee obj)
        {
            _context.employees.Add(obj);
            _context.SaveChanges();
        }

        void IEmployeeRepo.DeleteEmployee(int id)
        {
            Employee obj = _context.employees.Find(id);
            _context.employees.Remove(obj);
            _context.SaveChanges();
        }

        List<Employee> IEmployeeRepo.GetEmployees()
        {
            List<Employee> stList = _context.employees.ToList();
            return stList;
        }

        Employee IEmployeeRepo.GetEmployeeById(int id)
        {
            Employee obj = _context.employees.Find(id);
            return obj;
        }

       

        void IEmployeeRepo.UpdateEmployee(Employee obj)
        {
            _context.employees.Update(obj);
            _context.SaveChanges();
        }

      

        public IEnumerable<Employee> GetEmployeesByDeptno(int deptno)
        {
            IEnumerable<Employee> employees = _context.employees.Where(item => item.Deptno ==deptno);
            return employees;
        }
        public IEnumerable<Employee> GetEmployeesByJob(string Job)
        {
            IEnumerable<Employee> employees = _context.employees.Where(item => item.Job == Job);
            return employees;
        }



    }
}