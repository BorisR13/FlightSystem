using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FlightManager.Methods
{
    public class AuthMethod
    {
        public static CookieAuthenticationOptions get_CookieAuthenticationOptions()
        {
            var options = new CookieAuthenticationOptions
            {
                LoginPath = "/login",
                AccessDeniedPath = "/forbidden"
            };
            return options;
        }


        public static ClaimsIdentity get_claimsIdentityAsync(string UserName, string UserId, params string[] RolesName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, UserName),
                new Claim(ClaimTypes.NameIdentifier, UserId)
            };

            foreach (string RoleName in RolesName)
            {
                claims.Add(new Claim(ClaimTypes.Role, RoleName.ToString()));
            }

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            return claimsIdentity;
        }

        public static AuthenticationProperties get_authProperties(Boolean ispersist)
        {
            return new AuthenticationProperties
            {
                AllowRefresh = true,
                IsPersistent = ispersist,

            };
        }
    }
}
