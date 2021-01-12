using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using banking.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace banking.Controllers
{
    public class AdminController : Controller
    {
        private AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AdminController(AppDbContext context,UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Dashboard()
        {
            var allUsers = _userManager.Users;
            return View(allUsers);
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        public async Task<IActionResult> EditUser(string Id)
        {
            User editingUser = await _userManager.FindByIdAsync(Id);
            if (editingUser != null)
                return View(editingUser);
            else
                return RedirectToAction("Dashboard", "Admin");
        }

        public async Task<IActionResult> ViewUserDetails(string Id)
        {
            // *** Finds user in DB ***
            User user = await _userManager.FindByIdAsync(Id);
            if(user != null)
            {
                // *** Finds accounts associated with the user ***
                List <Account> accounts = _context.Account.Where(id => id.user.Id == user.Id).ToList();
                ViewBag.accounts = accounts;
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(NewUser newUser)
        {
            if(ModelState.IsValid)
            {
                User create = new User
                {
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    DateOfBirth = newUser.DateOfBirth,
                    Email = newUser.Email,
                    UserName = newUser.Email
                };
                var result = await _userManager.CreateAsync(create, newUser.Password);
                if(result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(create, "Customer");
                    return RedirectToAction("Dashboard", "Admin");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(newUser);
        }

        [HttpPost]
        public async Task<IActionResult> Update(string Id, EditUser edit)
        {
            User editingUser = await _userManager.FindByIdAsync(Id);
            if(editingUser != null && ModelState.IsValid)
            {
                editingUser.FirstName = edit.FirstName;
                editingUser.LastName = edit.LastName;
                editingUser.Email = edit.Email;
                editingUser.DateOfBirth = edit.DateOfBirth;
                
                IdentityResult result = await _userManager.UpdateAsync(editingUser);
                if (result.Succeeded)
                    return RedirectToAction("Dashboard", "Admin");
            }
            return RedirectToAction("EditUser", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string Id)
        {
            // *** Finds user to delete ***
            User user = await _userManager.FindByIdAsync(Id);
            if (user != null)
            {
                // *** Validates if user has accounts  and removes them***
                var removeAccounts = _context.Account;
                if(removeAccounts != null)
                {
                    foreach(var del in removeAccounts)
                    {
                        _context.Remove(del);
                    }
                }

                // *** Deletes user from DB ***
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
                // else
                //     Errors(result);
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View();
        }
    }
}