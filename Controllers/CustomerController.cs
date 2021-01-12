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
    public class CustomerController : Controller
    {
        private AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public CustomerController(AppDbContext context,UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> UserDashboard()
        {
            User currUser = await _userManager.GetUserAsync(HttpContext.User);
            List<Account> accounts = currUser.Account;
            ViewBag.accounts = accounts;
            return View(currUser);
        }

        public IActionResult CreateAccount()
        {
            return View();
        }

        public async Task<IActionResult> EditSelf()
        {
            User editing = await _userManager.GetUserAsync(HttpContext.User);
            if(editing != null)
            {
                return View(editing);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSelf(string Id, EditUser edit)
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
                    return RedirectToAction("UserDashboard", "Customer");
            }
            // ? Currently redirects to Admin Dashboard
            return RedirectToAction("EditSelf", "Customer");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(Account Acc)
        {
            User userId = await _userManager.GetUserAsync(HttpContext.User);
            if(userId != null)
            {
                if(ModelState.IsValid)
                {
                    // Todo: Validate that TypeOfAccount is Checkings or Savings
                    // if(Acc.TypeOfAccount != "Checkings" || Acc.TypeOfAccount != "Savings")
                    // {
                    //     return View(Acc);
                    // }
                    Account newAcc = new Account
                    {
                        TypeOfAccount = Acc.TypeOfAccount,
                        Amount = Acc.Amount,
                        user = userId
                    };
                    await _context.Account.AddAsync(newAcc);
                    await _context.SaveChangesAsync();
                    
                    return RedirectToAction("Userdashboard", "Customer");
                }
            }
            return View();
        }

        public async Task<IActionResult> AccountDetails(string Id)
        {
            // *** Finds current user and the Account expected on click ***
            User currUser = await _userManager.GetUserAsync(HttpContext.User);
            var account = _context.Account.Where(userId => userId.user.Id == currUser.Id).SingleOrDefault(i => i.Id.ToString() == Id);
            return View(account);
        }

        public async Task<IActionResult> EditAccount(string Id)
        {
            User currUser = await _userManager.GetUserAsync(HttpContext.User);
            var account = _context.Account.Where(userId => userId.user.Id == currUser.Id).SingleOrDefault(i => i.Id.ToString() == Id);
            return View(account);
        }

        public async Task<IActionResult> Addfunds(string Id)
        {
            User currUser = await _userManager.GetUserAsync(HttpContext.User);
            var account = _context.Account.Where(userId => userId.user.Id == currUser.Id).SingleOrDefault(i => i.Id.ToString() == Id);
            return View(account);
        }

        [HttpPost]
        public async Task<IActionResult> AddFunds(string Id, double Amount)
        {
            // *** Gets current user and account associated with current user ***
            User currUser = await _userManager.GetUserAsync(HttpContext.User);
            var account = _context.Account.Where(userId => userId.user.Id == currUser.Id).SingleOrDefault(i => i.Id.ToString() == Id);
            // *** We will add total amount with new funding ***
            var total = account.Amount;
            if(currUser != null)
            {
                // *** Adds total ***
                total = total + Amount;
                account.Amount = total;
                // *** Updates total amount ***
                // Todo: Needs to update with new amount of funding. Still reflecting old amount
                _context.Account.Update(account);
                return RedirectToAction("Userdashboard", "Customer");
            }
            return RedirectToAction("Userdashboard", "Customer");
        }
    }
}