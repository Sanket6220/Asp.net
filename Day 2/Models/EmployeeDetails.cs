namespace WebApplication4.Models
{
    public class EmployeeDetails
    {
        public static List<Employee> Employees = new List<Employee>();
        public EmployeeDetails()
        {
            Employees = new List<Employee>() {
                new Employee(){ EmployeeId = 10, EmployeeName = "scott", Job = "Manager", Salary = 55000 ,Deptno = 5 },
                new Employee(){ EmployeeId = 20, EmployeeName = "Mark", Job = "Tester", Salary = 30000 ,Deptno = 4 },
                new Employee(){ EmployeeId = 30, EmployeeName = "Bob", Job = "Developer", Salary = 40000 ,Deptno = 3 },
                new Employee(){ EmployeeId = 40, EmployeeName = "Harry", Job = "Trainer", Salary = 32000 ,Deptno = 2 },
                new Employee(){ EmployeeId = 50, EmployeeName = "John", Job = "Manager", Salary = 60000 ,Deptno = 5 }
            };
        }
        public List<Employee> GetAllDets()
        {
            return Employees;
        }
        public Employee GetEmployeeById(int id)
        {
            return Employees.Find(item => item.EmployeeId == id);
        }
        public void AddEmployee(Employee obj)
        {
            Employees.Add(obj);
        }
        public void DeleteEmployee(int id)
        {
            Employee obj = Employees.Find(item => item.EmployeeId == id);
            Employees.Remove(obj);
        }
        public void UpdateEmployee(Employee updateObj)
        {
            Employee obj = Employees.Find(item => item.EmployeeId == updateObj.EmployeeId);
            Employees.Remove(obj);
            Employees.Add(updateObj);
        }

    }
}