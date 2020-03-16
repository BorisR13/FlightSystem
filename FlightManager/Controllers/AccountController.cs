using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FlightManager.Methods;
using FlightManager.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightManager.Controllers
{
    public class AccountController : Controller
    {
        private FlightManagerContext context;

        public AccountController(FlightManagerContext contx)
        {
            this.context = contx;
        }

        [HttpGet("/register")]
        public IActionResult Registration()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost("/register")]
        [AutoValidateAntiforgeryToken]
        public IActionResult Registration(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (user.Id == 0)
                    {
                        context.Entry(user).State = EntityState.Added;
                        context.SaveChanges();
                    }

                    return Redirect("/");
                }
                else
                {
                    return View(user);
                }
            }
            catch (Exception e)
            {
                var error = e.Message;
                return View(user);
            }
        }


        [HttpGet("/login")]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost("/login")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> LogIn
            (string username, string password, string remmeberMe)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user =
                        context.Users.FirstOrDefault
                        (m => m.Username == username && m.Password == password);

                    if (user != null)
                    {
                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(AuthMethod.get_claimsIdentityAsync
                            (username, user.Id.ToString(), user.Role)),
                            AuthMethod.get_authProperties(remmeberMe == "on"));

                        return Redirect("/");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            {
                var error = e.Message;
                return View();
            }
        }

        [HttpGet("/logout")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/home");
        }
    }
}