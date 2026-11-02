
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Schoolwebsite.Data;
using Schoolwebsite.Models;
using Schoolwebsite.Services;
using Schoolwebsite.ViewModels.Admin;
using System.Security.Claims;

namespace Schoolwebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        //private readonly IAdminAuthService _authService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController( SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
           // _authService = authService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {

            if(User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            ViewBag.ReturnUrl = returnUrl;

            return View(new LoginViewModel());
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        //{

        //    if (!ModelState.IsValid) 
        //    { 
        //    ViewBag.ReturnUrl= returnUrl;
        //        return View(model);
        //    }

        //    var user = await _userManager.FindByNameAsync(model.Username)
        //        ?? await _userManager.FindByEmailAsync(model.Username);
        //    //Console.WriteLine($"[DEBUG] Typed username='{model.Username}' Typed password='{model.Password}' UserFound={user != null}");

        //    if (user != null)
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(
        //           user, model.Password, isPersistent: true, lockoutOnFailure: false
        //            );
        //        Console.WriteLine($"[DEBUG] Succeeded={result.Succeeded} IsLockedOut={result.IsLockedOut} IsNotAllowed={result.IsNotAllowed} RequiresTwoFactor={result.RequiresTwoFactor}");
        //        if (result.Succeeded) { 

        //        if(!string.IsNullOrEmpty(returnUrl)&& Url.IsLocalUrl(returnUrl))
        //            {
        //                return RedirectToAction(returnUrl);
        //            }
        //            return RedirectToAction("Index", "Dashboard");
        //        }
        //    }

        //    ModelState.AddModelError(string.Empty, "Invalid username or password");

        //    ViewBag.ReturnUrl = returnUrl;
        //    return View(model) ;

        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
          .Where(kvp => kvp.Value.Errors.Count > 0)
          .Select(kvp => $"{kvp.Key}: {string.Join("; ", kvp.Value.Errors.Select(e => e.ErrorMessage))}");

                return Content("DEBUG: ModelState invalid. Errors -> " + string.Join(" | ", errors) +
                                $" | Received Username='{model.Username}' Password='{model.Password}'");
                //ViewBag.ReturnUrl = returnUrl;
                //return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.Username)
                       ?? await _userManager.FindByEmailAsync(model.Username);

            if (user == null)
            {
                return Content($"DEBUG: No user found for username '{model.Username}'. " +
                                $"Total users in DB: {_userManager.Users.Count()}. " +
                                $"Usernames in DB: {string.Join(", ", _userManager.Users.Select(u => u.UserName))}");
            }

            var result = await _signInManager.PasswordSignInAsync(
                user, model.Password, isPersistent: true, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return Content($"DEBUG: User '{user.UserName}' found. " +
                                $"Succeeded={result.Succeeded} IsLockedOut={result.IsLockedOut} " +
                                $"IsNotAllowed={result.IsNotAllowed} RequiresTwoFactor={result.RequiresTwoFactor} " +
                                $"LockoutEnabled={user.LockoutEnabled} LockoutEnd={user.LockoutEnd}");
            }

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Dashboard");
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
