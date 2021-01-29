using System;
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

        public async Task<IActionResult> Dashboard()
        {
            User currUser = await _userManager.GetUserAsync(HttpContext.User);
            var allUsers = _userManager.Users.Where(user => user.Email != currUser.Email);
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
                // *** Creates new user to DB ***
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
                    // *** Currently creates user with role of Customer
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
            // *** Find User in DB ***
            User editingUser = await _userManager.FindByIdAsync(Id);
            if(editingUser != null && ModelState.IsValid)
            {
                editingUser.FirstName = edit.FirstName;
                editingUser.LastName = edit.LastName;
                editingUser.Email = edit.Email;
                editingUser.DateOfBirth = edit.DateOfBirth;
                // *** Saves edited user to DB ***
                IdentityResult result = await _userManager.UpdateAsync(editingUser);
                if (result.Succeeded)
                    return RedirectToAction("Dashboard", "Admin");
            }
            // ? Currently redirects to Admin Dashboard
            return RedirectToAction("EditUser", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string Id)
        {
            // *** Finds user to delete ***
            User user = await _userManager.FindByIdAsync(Id);
            if (user != null)
            {
                // *** Validates if user has accounts and removes them***
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