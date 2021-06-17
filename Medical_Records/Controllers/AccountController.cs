using Medical_Records.Models;
using Medical_Records.MedicalRecordsRoles;
using Medical_Records.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Medical_Records.MedicalRecordsRoles { 
namespace Medical_Records.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;
        public AccountController(ApplicationDbContext db, UserManager<ApplicationUser> userManager,
           RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Login(LoginViewModel model)
        {
                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe,false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "Invalid login attempt");
                }
            return View(model);
        }
       

        public async Task<IActionResult> Register()
        {

                if (!_roleManager.RoleExistsAsync(MedicalRecordsRoles.Admin).GetAwaiter().GetResult())
                {
                    await _roleManager.CreateAsync(new IdentityRole(MedicalRecordsRoles.Admin));
                    await _roleManager.CreateAsync(new IdentityRole(MedicalRecordsRoles.Patient));
                    //await _roleManager.CreateAsync(new IdentityRole(MedicalRecordsRoles.Doctor));

                }
                return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    CongenitalDesease = model.CongenitalDesease,
                    CurrentMedication = model.CurrentMedication,
                    DrugAllergy = model.DrugAllergy

                };

                var result = await _userManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.RoleName);
                    // if registration is succeeded the user account is created b4 redict.
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    // Change Redirect to user profile later! 
                    return RedirectToAction("Index", "Home");
                }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
            }
            return View(model);
        }
            [HttpPost]
            public async Task<IActionResult>Logout()
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Login", "Account");
            }
    }
}
}
