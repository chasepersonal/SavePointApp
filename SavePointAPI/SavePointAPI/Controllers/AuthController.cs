using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SavePointApp.Data;
using SavePointApp.Dtos;
using SavePointApp.Models;

namespace SavePointApp.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        // Initialize auth repository context
        private readonly IAuthRepository _repo;

        // Initialize configuration for app settings
        private readonly IConfiguration _config;

        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }

        [HttpPost("register")]
        // Tell API to look into the body to get the information it needs
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto)
        {
            // Convert username to lowercase string as long as their was a username passed
            // Eilminates case sensitivity
            if (!string.IsNullOrEmpty(userForRegisterDto.Username))
                userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _repo.UserExists(userForRegisterDto.Username))
                ModelState.AddModelError("Username", "Username is already taken");

            // Validate Request
            // Will send error messages to the client if request isn't validated
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };

            var createUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }

        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto userForLoginDto)
        {

            var userFromRepo = await _repo.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);

            // Return unauthorized if no user is returned from the repository
            // Just return unauthorized to prevent brute force attacks
            if (userFromRepo == null)
                return Unauthorized();

            // Generate JWT
            var tokenHandler = new JwtSecurityTokenHandler();

            // Generate security key
            var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);

            // Create payload for token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                    new Claim(ClaimTypes.Name, userFromRepo.Username)
                }),

                // Set expirary date for JWT Token
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };

            // Complete generation of token and send
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // Return token as an object
            return Ok(new { tokenString });
        }

    }
}
