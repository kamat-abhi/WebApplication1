using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("Employe")]
    public class EmployeController : Controller
    {
        private readonly string filePath;

        public EmployeController(IWebHostEnvironment environment)
        {
            filePath = Path.Combine(
                environment.ContentRootPath,
                "Data",
                "employes.json"
            );
        }

        private List<Employe> GetEmployees()
        {
            if (!System.IO.File.Exists(filePath))
            {
                return new List<Employe>();
            }

            string json = System.IO.File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<List<Employe>>(json)
                   ?? new List<Employe>();
        }

        private void SaveEmployees(List<Employe> employees)
        {
            string json = JsonSerializer.Serialize(
                employees,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                }
            );

            System.IO.File.WriteAllText(filePath, json);
        }

        // GET: /Employe
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Employe> employees = GetEmployees();

            return View(employees);
        }

        // GET: /Employe/Details/5
        [HttpGet("Details/{id?}")]
        public IActionResult Details(int id)
        {
            List<Employe> employees = GetEmployees();

            Employe? employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: /Employe/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Employe/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employe employe)
        {
            if (!ModelState.IsValid)
            {
                return View(employe);
            }

            List<Employe> employes = GetEmployees();

            employe.Id = employes.Count > 0
                ? employes.Max(e => e.Id) + 1
                : 1;

            employes.Add(employe);

            SaveEmployees(employes);

            return RedirectToAction(nameof(Index));
        }

        // GET: /Employe/Edit/5
        [HttpGet("Edit/{id?}")]
        public IActionResult Edit(int id)
        {
            List<Employe> employees = GetEmployees();

            Employe? employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: /Employe/Edit/5
        [HttpPost("Edit/{id?}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employe employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            List<Employe> employees = GetEmployees();

            Employe? existingEmployee =
                employees.FirstOrDefault(e => e.Id == id);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            existingEmployee.Name = employee.Name;
            existingEmployee.Email = employee.Email;
            existingEmployee.Department = employee.Department;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.Designation = employee.Designation;

            SaveEmployees(employees);

            return RedirectToAction(nameof(Index));
        }

        // GET: /Employe/Delete/5
        [HttpGet("Delete/{id?}")]
        public IActionResult Delete(int id)
        {
            List<Employe> employees = GetEmployees();

            Employe? employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: /Employe/Delete/5
        [HttpPost("Delete/{id?}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            List<Employe> employees = GetEmployees();

            Employe? employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            employees.Remove(employee);

            SaveEmployees(employees);

            return RedirectToAction(nameof(Index));
        }
    }
}