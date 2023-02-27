using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BulkyBookWeb.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UsersController(ApplicationDbContext context, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(RegistorDto obj)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    Email = obj.Email,
                    UserName = obj.UserName,
                    Password = obj.Password,
                };

             

                var newUserResponse = await this.userManager.CreateAsync(user, obj.Password);

                if (newUserResponse.Succeeded)
                {
                    if (await this.roleManager.RoleExistsAsync(obj.IsAdmin) == false)
                    {
                        var role = new IdentityRole(obj.IsAdmin);

                        await this.roleManager.CreateAsync(role);
                    }

                    await this.userManager.AddToRoleAsync(user, obj.IsAdmin);
                    await this.signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Product", "Index");
                }

                _context.Users.Add(user);
                _context.SaveChanges();
            }

            return RedirectToAction("Product","Index");
        }

        public IActionResult Login()
        {
            return View();  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginDto obj)
        {
            if (!ModelState.IsValid) { 

            return View();
            }
            var user = _context.Users.FirstOrDefault(u=>u.UserName== obj.UserName);


            if(user == null)
            {
                return RedirectToAction("Users", "SignUp");
            }
            return View(obj);
        }


    }
}
