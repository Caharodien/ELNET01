using Microsoft.AspNetCore.Mvc;

namespace ELNETBAI.Controllers
{
    public class AccountController : Controller
    {
        // This will show the Login Page
        public IActionResult Login()
        {
            return View();
        }

        // Handle login POST request
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Dummy authentication logic (Replace this with database authentication)
            if (username == "admin" && password == "password")
            {
                return RedirectToAction("Index", "Home"); // Redirect to home page if successful
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Username or Password";
                return View();
            }
        }
    }
}
