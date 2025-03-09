using Microsoft.AspNetCore.Mvc;
using ELNET01.Models;

namespace ELNET01.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Submit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return View("ThankYou");  // ✅ Change RedirectToAction -> View
            }
            return View("Contact");
        }

        public IActionResult ThankYou()
        {
            return View();  // ✅ This is fine, but must have a ThankYou.cshtml file
        }
    }
}
