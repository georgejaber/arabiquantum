using arabiquantum.Data;
using arabiquantum.Models;
using arabiquantum.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace arabiquantum.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }

       [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) { return View(loginViewModel); }

            //get user from database
            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

            if (user != null) {

                //check password
                var checkpassword = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if (checkpassword)
                {
                    //sign in
                    var signInResult = await _signInManager.CheckPasswordSignInAsync(user, loginViewModel.Password, true);

                    if (signInResult.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                //password is incorrect
                TempData["Error"] = "Wrong credentials. pleaase, try again";
                return View(loginViewModel);

            }
            //user not found
            TempData["Error"] = "Wrong credentials. pleaase, try again";
            return View(loginViewModel);

        }
    }
}  
