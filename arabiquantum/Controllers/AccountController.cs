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

            if (user != null)
            {

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
                TempData["Error"] = "Wrong credentials. please, try again";
                return View(loginViewModel);

            }
            //user not found
            TempData["Error"] = "Wrong credentials. please, try again";
            return View(loginViewModel);

        }

        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) { return View(registerViewModel); }

            var user = await _userManager.FindByEmailAsync(registerViewModel.Email);

            if (user != null)
            {
                TempData["Error"] = "this email address is already in use";
                return View(registerViewModel);
            }
            var UsernameValidation = await _userManager.FindByNameAsync(registerViewModel.Username);
            if (UsernameValidation != null)
            {
                TempData["Error"] = "this username is already taken";
               
            }

            var NewUser = new User()
            {
                UserName = registerViewModel.Username,
                Email = registerViewModel.Email
            };

            var NewUserResponse = await _userManager.CreateAsync(NewUser, registerViewModel.Password);

            if (NewUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(NewUser, UserRoles.User);
                return RedirectToAction("index", "Home");
            }
             return View(registerViewModel);
        } 

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }

}
