using API_AuthTest.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API_AuthTest.Controllers
{
    [Route("")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public LoginController()
        {
            
        }

        [HttpPost("login")]
        public async Task<IActionResult> OnPostAsync([FromBody] Credential credential)
        {
            if (credential.UserName == "u" && credential.Password == "1")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "u"),
                    new Claim("Member", "true")
                };
                var identity = new ClaimsIdentity(claims, "myauth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = credential.RememberMe
                };
                await HttpContext.SignInAsync("myauth", claimsPrincipal, authProperties);
                return Ok(credential);
            }
            if (credential.UserName == "admin" && credential.Password == "1")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim("Member", "true"),
                    new Claim("Admin", "true")
                };
                var identity = new ClaimsIdentity(claims, "myauth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = credential.RememberMe
                };
                await HttpContext.SignInAsync("myauth", claimsPrincipal, authProperties);
                return Ok(credential);
            }
            return NotFound();
        }
    }
}
