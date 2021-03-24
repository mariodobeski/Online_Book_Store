using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineBookstore.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private IPasswordHasher<IdentityUser> _passwordHasher;
        private RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<IdentityUser> userManager, IPasswordHasher<IdentityUser> passwordHasher, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users;
            return View(users);
        }

        public IActionResult Create()
        {
            var roles
        }
    }
}