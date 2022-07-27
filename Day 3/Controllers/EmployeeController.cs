using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
namespace WebApplication5.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDbContext _context;
        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Employee> stList = _context.employees.ToList();
            return View(stList);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            _context.employees.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee obj = _context.employees.Find(id);
            return View(obj);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            Employee obj = _context.employees.Find(id);
            _context.employees.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            Employee obj = _context.employees.Find(id);
            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee obj = _context.employees.Find(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            _context.employees.Update(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
