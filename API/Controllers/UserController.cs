using API.TokenHandler;
using Core.AbstractManager;
using Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Identity;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
      
      
        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
           
           
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserCreateDTO createDTO)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new()
                {
                    Email = createDTO.Email,
                    UserName = createDTO.Username,

                };
            var result=   await _userManager.CreateAsync(user,createDTO.Password);
                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            
            return BadRequest();
        }
        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> Login(UserLoginDTO loginDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDTO.Username, loginDTO.Password, false, true);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(loginDTO.Email);
               var token= Token.GenerateToken(user);
                return Ok(token);
            }

            return BadRequest();
        }

       
    }
}
