using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeDContext _context;

        public EmployeeController(EmployeeDContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var empList = await _context.employees.ToListAsync();
            return Ok(empList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var empObj = await _context.employees.FindAsync(id);

            if (empObj != null)
                return Ok(empObj);
            else
                return NotFound("Employee Id does not exists.");
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee obj)
        {
            await _context.employees.AddAsync(obj);
            await _context.SaveChangesAsync();
            return Ok("New Employee details are saved.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(Employee obj)
        {
            _context.employees.Update(obj);
            await _context.SaveChangesAsync();
            return Ok("Employee details updated.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var empObj = await _context.employees.FindAsync(id);
            _context.employees.Remove(empObj);
            await _context.SaveChangesAsync();
            return Ok("Employee deleted.");
        }
    }
}
