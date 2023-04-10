using Luxelane.Db;
using Luxelane.DTOs;
using Luxelane.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Luxelane.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        protected readonly IUserService _service;
        private readonly ILogger<UserController> _logger;
        private readonly DataContext _context;

        public UserController(IUserService service, ILogger<UserController> logger, DataContext context)
        {
            _service = service;
            _logger = logger;
            _context = context;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(UserSignInDto request)
        {
            var response = await _service.SignInAsync(request);
            if (response is null)
            {
                return Unauthorized();
            }
            return Ok(response);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUpAsync(UserSignUpDto request)
        {
            var user = await _service.SignUpAsync(request);
            if (user is null)
            {
                return BadRequest();
            }
            return Ok(user);
        }

        [HttpGet("{id:int}")]
        [Authorize(Policy = "AdminOrOwner")]
        public async Task<UserReadDto?> GetAsync(int id)
        {
            return await _service.GetAsync(id);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            if (await _service.DeleteAsync(id))
            {
                return Ok(new { Message = "Item is deleted " });
            }
            return NotFound("Item is not found");
        }

        [HttpPatch("{id:int}")]
        [Authorize(Policy = "AdminOrOwner")]
        public async Task<ActionResult> UpdateAsync(int id, UserUpdateDto update)
        {
            var result = await _service.UpdateAsync(id, update);
            return Ok(result);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetAllAsync()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("profile")]
        [Authorize]
        public async Task<ActionResult> GetProfileAsync()
        {

            var result = await _service.GetProfile();

            return Ok(result);
        }
    }

}