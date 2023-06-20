using DoggyRestApi.DTOs;
using DoggyRestApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DoggyRestApi.Controllers
{

    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {

        private readonly IConfiguration configuration;
        private readonly UserManager<ProjectIdentityUser> userManager;
        private readonly SignInManager<ProjectIdentityUser> signInManager;
        public AuthenticationController(
            IConfiguration configuration,
            UserManager<ProjectIdentityUser> userManager,
            SignInManager<ProjectIdentityUser> signInManager)
        {
            this.configuration = configuration;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //step 1. verify user email and password
            var result = await signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, false, false);
            if (!result.Succeeded)
                return BadRequest(new { err = "user name or password is incorrect!" });


            //step 2. create jwt
            //step 2.1 hearder
            ProjectIdentityUser user = await userManager.FindByNameAsync(loginDto.Email);
            List<Claim> claims = new List<Claim> { new Claim(JwtRegisteredClaimNames.Sub, user.Id) };
            foreach (string role in await userManager.GetRolesAsync(user))
                claims.Add(new Claim(ClaimTypes.Role, role));

            //step 2.3 signature
            byte[] secreteKeyBytes = Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"]);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: configuration["Authentication:Issuer"],
                audience: configuration["Authentication:Audience"],
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(1),//expire in 1 day
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secreteKeyBytes), SecurityAlgorithms.HmacSha256));

            // step 3. return response with jwt
            string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return Ok(token);
        }


        [HttpPost("Register")]
        public async Task<IActionResult> RegisterNewUser([FromBody] RegisterNewUserDTO registerNewUserDTO)
        {
            if (registerNewUserDTO == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            //Step 1. Create User with personal information
            ProjectIdentityUser identityUser = new ProjectIdentityUser()
            {
                UserName = registerNewUserDTO.Email,
                Email = registerNewUserDTO.Email
            };

            //Step2. Insert new record for the new user
            var result = await userManager.CreateAsync(identityUser, registerNewUserDTO.Password);

            if (result.Succeeded)
                return Ok();

            return BadRequest(result.Errors);
        }
    }



}
