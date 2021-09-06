using DatabaseAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication4.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;

        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = _userManager.Users.ToArray();
            return View(users.Select(x => new UserViewModel {
                Email = x.Email,
                Id = x.Id}).ToArray());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = new User { Email = model.Email, UserName = model.Email };
            var result = await _userManager.CreateAsync(user,model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, $"(${error.Code}) ${error.Description})");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return BadRequest();
            }

            return View(new UserViewModel
            {
                Email = user.Email,
                Id = user.Id,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userToUpdate = await _userManager.FindByIdAsync(model.Id);
            if (userToUpdate == null)
            {
                return BadRequest();
            }
 
            userToUpdate.Email = model.Email;
            userToUpdate.UserName = model.Email;
            await _userManager.UpdateAsync(userToUpdate);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return BadRequest();
            }

            return View("UserDetails", new UserViewModel
            {
                Email = user.Email,
                Id = user.Id,
            });
        }
    }
}
