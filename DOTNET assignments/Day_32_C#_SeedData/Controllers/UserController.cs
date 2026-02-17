using Day_32_C__SeedData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day_32_C__SeedData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }

        //Get All users
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            //Return a list of users
            return Ok(_context.Users.ToList());
        }
        //Register a new user
        [HttpPost]
        public IActionResult Register(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var obj = _context.Users.FirstOrDefault(u => u.Email == userDto.Email);
            if (obj != null)
            {
                return BadRequest(new { Message = "User already exists with this email" });
            }
            _context.Users.Add(new User
            {
                //UserId = _context.Users.Count() + 1,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Password = userDto.Password,
                IsActive = true,
                LastModifiedTime = DateTime.Now
            });

            _context.SaveChanges();

            return Ok(new { Message = "User registered successfully", User = userDto });
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var check = _context.Users.FirstOrDefault(u => u.Email == loginDto.Email);
            if (check == null) return NotFound(new { Message = "User Not found" });
            var user = _context.Users.FirstOrDefault(u => u.Email == loginDto.Email && u.Password == loginDto.Password);
            if (user == null) return BadRequest(new { Message = "Invalid password" });
            return Ok(new { message = "Successfully logged in" });
        }
    }
}
