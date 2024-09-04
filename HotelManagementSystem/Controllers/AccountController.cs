using HotelManagementSystem.Data;
using HotelManagementSystem.Models;

using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserRepository _userRepository;

        // Constructor injection for UserRepository
        public AccountController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public IActionResult Register(Customer model)
        {
            if (ModelState.IsValid)
            {
                _userRepository.CreateCustomer(model);
                return RedirectToAction("ThankYou");
            }
            return View(model);
        }

        // GET: /Account/ThankYou
        public IActionResult ThankYou()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = _userRepository.GetCustomerByEmail(model.EmailId);

                if (customer != null && customer.Password == model.Password)
                {
                    // Authentication successful, set session or cookie if needed
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }

            return View(model);
        }

    }
}
