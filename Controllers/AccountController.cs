using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ELNETBAI.Models; // Ensure this is included
using System.Security.Cryptography;
using System.Text;

namespace ELNETBAI.Controllers
{
    public class AccountController : Controller
    {
        // Show Login Page
        public IActionResult Login()
        {
            return View();
        }

        // Handle Login Request
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Dummy authentication (Replace with actual database authentication)
            if (username == "admin" && VerifyPassword(password, "123"))
            {
                // Store user session
                HttpContext.Session.SetString("User", username);

                return RedirectToAction("Index", "Home"); // Redirect after successful login
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Username or Password";
                return View();
            }
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("Login");
        }

        // Show Register Page
        public IActionResult Register()
        {
            return View();
        }

        // Handle Registration
        [HttpPost]
        public IActionResult Register(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            // TODO: Save user to database with hashed password
            string hashedPassword = HashPassword(user.Password);
            user.Password = hashedPassword;

            // Redirect to login after successful registration
            return RedirectToAction("Login");
        }

        // Hashing Password (Replace with a better hashing algorithm)
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Dummy password verification (Replace with database check)
        private bool VerifyPassword(string inputPassword, string storedPassword)
        {
            string hashedInput = HashPassword(inputPassword);
            return hashedInput == storedPassword;
        }
    }
}
