using System;
using System.Collections.Generic;
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

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(Account Acc)
        {
            User userId = await _userManager.GetUserAsync(HttpContext.User);
            if(userId != null)
            {
                if(ModelState.IsValid)
                {
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

        [Route("Id")]
        public IActionResult AccountDetails()
        {
            return View();
        }
    }
}