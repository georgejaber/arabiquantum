using arabiquantum.InterfacesRepository;
using arabiquantum.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace arabiquantum.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        
        public async Task<ActionResult> Index()
        {
            var users = await _userRepository.GetAllUsers();

            List<UsersViewModel> UsersViewModel = new List<UsersViewModel>();

            foreach (var user in users) 
            {
                UsersViewModel usersViews = new UsersViewModel() 
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    UserEmail = user.Email
                };
                UsersViewModel.Add(usersViews);
            }
            return View(UsersViewModel);
        }

       
    }
}
