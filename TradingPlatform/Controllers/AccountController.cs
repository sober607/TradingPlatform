using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TradingPlatform.Infrastructure.Services.Interfaces;
using TradingPlatform.Models;
using TradingPlatform.Repositories;
using TradingPlatform.ViewModels;

namespace TradingPlatform.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;

        private readonly UserManager<User> _userManager;

        public IMessageService _messageService { get; set; }

        public ICountriesRepository _countriesRepository { get; set; }

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ICountriesRepository countriesRepository, IMessageService messageService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _countriesRepository = countriesRepository;
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterViewModel();
            var countries = _countriesRepository.GetAllCountries();
            int i = 0;
            model.Countires = new List<SelectListItem>();

            foreach (var t in countries)
            {
                model.Countires.Add(new SelectListItem() { Text = t.Name, Value = t.Name });
                i++;
            }

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new User() { UserName = model.Email, Email = model.Email, Name = model.Name, Country = _countriesRepository.FindCountryByName(model.CountryName) };
                var createTask = await _userManager.CreateAsync(user, model.Password);

                if (createTask.Succeeded)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action(
                        "ConfirmEmail",
                        "Account",
                        new { userId = user.Id, code = code },
                        protocol: HttpContext.Request.Scheme);

                    await _messageService.SendMessageAsync("email", $"Please confirm your registration and follow by link <a href='{callbackUrl}'>link</a>", "Registration confirmation", model.Email);
                    await _signInManager.SignInAsync(user, false);

                    return Content("For completing of registration please click link in email, which send to your email");
                }
                else
                {
                    foreach (var t in createTask.Errors)
                    {
                        ModelState.AddModelError("", t.Description);
                    }
                }
                return View(model);
            }
            else
            {
                var model1 = new RegisterViewModel();
                var countries = _countriesRepository.GetAllCountries();
                int i = 0;
                model1.Countires = new List<SelectListItem>();

                foreach (var t in countries)
                {
                    model1.Countires.Add(new SelectListItem() { Text = t.Name, Value = t.Name });
                    i++;
                }

                return View(model1);
            }


        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return View("No user found");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Error. Email not confirmed");
            }

        }


        [HttpGet]
        public IActionResult Login(string ReturnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = ReturnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email);

                if (user != null)
                {

                    if (!await _userManager.IsEmailConfirmedAsync(user))
                    {
                        ModelState.AddModelError(string.Empty, "Email is not confirmed. Please confirm email from your mail");
                        return View(model);
                    }
                }

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Sign in failed. Wrong login or password");
                }
            }

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
