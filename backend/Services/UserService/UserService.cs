using System.Security.Claims;
using AutoMapper;
using Luxelane.Db;
using Luxelane.DTOs;
using Luxelane.Helpers;
using Luxelane.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Luxelane.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly ITokenService _tokenService;
        private readonly ILogger<UserService> _logger;
        protected readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IMapper _mapper;

        public UserService(IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager,
            RoleManager<IdentityRole<int>> roleManager,
            ITokenService tokenService,
            ILogger<UserService> logger,
            DataContext context,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserSignInReadDto?> SignInAsync(UserSignInDto request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                throw ServiceException.Unauthorized();
            }
            if (!await _userManager.CheckPasswordAsync(user, request.Password))
            {
                throw ServiceException.Unauthorized();
            }
            return await _tokenService.GenerateTokenAsync(user);
        }

        public async Task<UserSignInReadDto> UpdateAsync(int id, UserUpdateDto update)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
            {
                throw ServiceException.NotFound();
            }

            var updateData = _mapper.Map<User>(update);

            user.FirstName = update.FirstName;
            user.LastName = update.LastName;
            user.UserName = update.UserName;
            user.Email = update.Email;
            user.Avatar = update.Avatar;

            await _context.SaveChangesAsync();

            return await _tokenService.GenerateTokenAsync(user);
        }

        public async Task<UserSignUpReadDto?> SignUpAsync(UserSignUpDto request)
        {
            var newUser = _mapper.Map<User>(request);

            var result = await _userManager.CreateAsync(newUser, request.Password);
            if (!result.Succeeded)
            {
                return null;
            }

            var roles = new[] { "Customer" };
            foreach (var role in roles)
            {
                if (await _roleManager.FindByNameAsync(role) is null)
                {
                    await _roleManager.CreateAsync(new IdentityRole<int>
                    {
                        Name = role,
                    });
                }
            }

            await _userManager.AddToRolesAsync(newUser, roles);
            var userResponse = _mapper.Map<UserSignUpReadDto>(newUser);

            return userResponse;
        }

        public async Task<UserReadDto?> GetAsync(int id)
        {
            var item = await _userManager.FindByIdAsync(id.ToString());
            var result = _mapper.Map<UserReadDto>(item);
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _userManager.FindByIdAsync(id.ToString());
            if (item == null)
            {
                return false;
            }
            await _userManager.DeleteAsync(item);
            return true;
        }
        public async Task<ICollection<UserReadDto>> GetAllAsync()
        {
            var data = await _context.Users.AsNoTracking().ToListAsync();
            var result = _mapper.Map<ICollection<UserReadDto>>(data);
            return result;
        }

        public async Task<UserProfileDto> GetProfile()
        {
            var authenticatedUser = _httpContextAccessor.HttpContext!.User;
            var id = authenticatedUser.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = _httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.Role);
            var user = await GetAsync(int.Parse(id!));
            var userProfile = new UserProfileDto
            {
                Id = user!.Id,
                Addresses = user.Addresses,
                Orders = user.Orders,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = role!,
                Avatar = user.Avatar
            };
            return userProfile;
        }
    }
}