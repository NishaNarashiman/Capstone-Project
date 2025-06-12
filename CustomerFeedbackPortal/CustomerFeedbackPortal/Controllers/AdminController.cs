using Microsoft.AspNetCore.Mvc;
using CustomerFeedbackPortal.Models;
using Microsoft.AspNetCore.Http;

namespace CustomerFeedbackPortal.Controllers
{
    public class AdminController : Controller
    {
        
        private readonly string adminUsername = "admin";
        private readonly string adminPassword = "admin123";

        // GET: Admin/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Admin/Login
        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            if (admin.UserName == adminUsername && admin.Password == adminPassword)
            {
               
                HttpContext.Session.SetString("Admin", "true");

               
                return RedirectToAction("Index", "Feedbacks");
            }

            
            ViewBag.Message = "Invalid username or password";
            return View();
        }

        // GET: Admin/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Admin");
            return RedirectToAction("Login");
        }
    }
}
