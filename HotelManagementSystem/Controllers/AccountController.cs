using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserRepository _userRepository;

        public AccountController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public async Task<IActionResult> Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int userId = await _userRepository.CreateUserAsync(customer);
                    return RedirectToAction("ThankYou");
                }
                catch
                {
                    ModelState.AddModelError("", "An error occurred while saving your data. Please try again.");
                }
            }

            return View(customer);
        }

        // GET: /Account/ThankYou
        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
