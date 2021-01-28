using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using banking.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace banking.Controllers
{
    public class ManagerController : Controller
    {
        private AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public ManagerController(AppDbContext context,UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult ManagerDashboard()
        {
            return View();
        }

        public IActionResult UserList()
        {
            var allUsers = _userManager.Users;
            return View(allUsers);
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

        public async Task<IActionResult> EditUser(string Id)
        {
            User editingUser = await _userManager.FindByIdAsync(Id);
            if (editingUser != null)
                return View(editingUser);
            else
                return RedirectToAction("ManagerDashboard", "Manager");
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
                    return RedirectToAction("ManagerDashboard", "Manager");
            }
            // ? Currently redirects to Admin Dashboard
            return RedirectToAction("EditUser", "Manager");
        }
    }
}