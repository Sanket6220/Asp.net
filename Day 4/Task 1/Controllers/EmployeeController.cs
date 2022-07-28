using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using WebApplication5.Repository;
using WebApplication5.Filters;

namespace WebApplication5.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        IEmployeeRepo _employeeRepo;

        public EmployeeController(IEmployeeRepo Employee, ILogger<HomeController> logger)
        {
            _employeeRepo = Employee;
            _logger = logger;
        }

        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Index()
        {
            _logger.LogInformation("All Employee Action is Processed");
            List<Employee> empList = _employeeRepo.GetEmployees();

          
            return View(empList);
        }

       


        [HttpGet]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Create()
        {
            _logger.LogInformation("Create get Action is Processed.");
            return View();
        }

        [HttpPost]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Create(Employee obj)
        {
            _logger.LogInformation("Create Post Action is Processed.");
            _employeeRepo.AddEmployee(obj);
          
            return RedirectToAction("Index");
        }

        [HttpGet]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Delete get Action is Processed.");
            Employee obj = _employeeRepo.GetEmployeeById(id);
            return View(obj);
        }

        [HttpPost]
        [ActionName("Delete")]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult DeleteConfirm(int id)
        {
            _logger.LogInformation("Delete Post Action is Processed.");
            _employeeRepo.DeleteEmployee(id);
         
            return RedirectToAction("Index");
        }
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Details(int id)
        {
            _logger.LogInformation("Details Action is Processed.");
            Employee obj = _employeeRepo.GetEmployeeById(id);
            return View(obj);
        }

        [HttpGet]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Edit(int id)
        {
            _logger.LogInformation("Edit get Action is Processed.");
            Employee obj = _employeeRepo.GetEmployeeById(id);
            return View(obj);
        }

        [HttpPost]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Edit(Employee obj)
        {
            _logger.LogInformation("Edit post Action is Processed.");
            _employeeRepo.UpdateEmployee(obj);
         
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult EmployeeByDeptno(int deptno)
        {
            return View();
        }

        [HttpPost]
        [ActionName("EmployeeByDeptno")]
        public IActionResult EmployeeByDeptnoConf(int deptno)
        {
            IEnumerable<Employee> employees = _employeeRepo.GetEmployeesByDeptno(deptno);
            ViewBag.RequestType = Request.Method;
            return View(employees);
        }

        [HttpGet]
        public IActionResult EmployeeByJob(string Job)
        {
            return View();
        }

        [HttpPost]
        [ActionName("EmployeeByJob")]
        public IActionResult EmployeeByJobConf(string Job)
        {
            IEnumerable<Employee> employees = _employeeRepo.GetEmployeesByJob(Job);
            ViewBag.RequestType = Request.Method;
            return View(employees);
        }
    }
}
