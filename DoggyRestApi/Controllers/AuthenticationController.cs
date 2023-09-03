using DoggyRestApi.DTOs;
using DoggyRestApi.Models;
using DoggyRestApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DoggyRestApi.Controllers
{

    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IConfiguration configuration;
        private readonly UserManager<ProjectIdentityUser> userManager;
        private readonly SignInManager<ProjectIdentityUser> signInManager;
        private readonly ITouristRouteRepository touristRouteRepository;
        public AuthenticationController(
            IConfiguration configuration,
            UserManager<ProjectIdentityUser> userManager,
            SignInManager<ProjectIdentityUser> signInManager,
            ITouristRouteRepository touristRouteRepository)
        {
            this.configuration = configuration;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.touristRouteRepository = touristRouteRepository;
        }


        [HttpPost("Login", Name = "Login")]
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
            List<Claim> claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Name, user.Email)
            };
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


        [HttpPost("Register", Name = "RegisterNewUser")]
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
            if (!result.Succeeded)
                return BadRequest(result.Errors);


            //step3. Create a shopping cart for the new user
            ShoppingCart shoppingCart = new ShoppingCart()
            {
                Id = Guid.NewGuid(),
                OwnerId = identityUser.Id
            };

            touristRouteRepository.CreateShoppingCart(shoppingCart);
            if (!await touristRouteRepository.SaveAsync())
            {
                //if saving the changes fails, delete the user so that new user can create account again using the same account name
                await userManager.DeleteAsync(identityUser);
                return StatusCode(StatusCodes.Status500InternalServerError, new { err = "error occurred while create shopping cart" });
            }

            if (result.Succeeded)
                return Ok(new { message = "The account has been successfully created" });

            return BadRequest(result.Errors);
        }
    }



}
