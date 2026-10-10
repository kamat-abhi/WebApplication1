using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Student student = new Student()
            {
                Id = 1,
                Name = "abhishek",
                Age = 25,
                Birthday = 1998
            };
            return View(student);
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ContactUs()
        {
            return View(new ContactModel());
        }

        [HttpPost]
        public IActionResult ShowData(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("ContactUs", model);
            }

            ViewBag.Success = "Your message has been submitted!";

            ModelState.Clear();

            return View("ContactUs", new ContactModel());
        }
        public IActionResult Default()
        {
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
