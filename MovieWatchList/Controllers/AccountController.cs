using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieWatchList.Core.Domain.Entities.Identity;
using MovieWatchList.Core.DTO;

namespace MovieWatchList.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register (RegisterDTO input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new ApplicationUser()
            {
                Email = input.Email,
                UserName = input.Email,
                PhoneNumber = input.PhoneNumber,
                PersonName = input.PersonName
            };

            var result = await _userManager.CreateAsync(user, input.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(error.Code, error.Description);

                return BadRequest(ModelState);
            }

            await _signInManager.SignInAsync(user, isPersistent: false);

            return Ok("user created successfully");
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _signInManager.PasswordSignInAsync(input.Email, input.Password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
                return BadRequest("Invalid email or password");

            var user = await _userManager.FindByEmailAsync(input.Email);

            return Ok(new
            {
                personName = user!.PersonName,
                email = user.Email
            });
        }


        [HttpGet("logout")]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return NoContent();
        }
    }
}
