using Api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DataModel.Dtos;
using DAL.Entity;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly ILogger<UserController> _logger;

        private readonly string _errorMessage = "An error occurred while processing your request";

        public UserController(IUserService userService, ITokenService tokenService, ILogger<UserController> logger)
        {
            _userService = userService;
            _tokenService = tokenService;
            _logger = logger;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var user = await _userService.GetLogin(loginDto);

                if (user == null)
                {
                    return BadRequest("Wrong username or password");
                }

                UserDto userDto = new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    IsActive = user.IsActive,
                    RoleType = user.RoleId,
                    Token = _tokenService.CreateToken(loginDto),
                    FullName = user.FullName,
                    RoleName = user.RoleType.Name
                };

                return Ok(userDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in UserController/Login");
                return StatusCode(500, _errorMessage);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult<AppUser>> CreateUserAsync(AppUser user)
        {
            try
            {
                return await _userService.AddAsync(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in UserController/CreateUserAsync");
                return StatusCode(500, _errorMessage);
            }
        }

        [HttpGet("GetUser/{id}")]
        public async Task<ActionResult<AppUser>> GetUserByIdAsync(int id)
        {
            try
            {
                return await _userService.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in UserController/GetUserByIdAsync");
                return StatusCode(500, _errorMessage);
            }
        }

        [HttpPost("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAllUsersAsync()
        {
            try
            {
                return Ok(await _userService.GetAllAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in UserController/GetAllUsersAsync");
                return StatusCode(500, _errorMessage);
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult<AppUser>> UpdateUserAsync(AppUser user)
        {
            try
            {
                return await _userService.UpdateAsync(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in UserController/UpdateUserAsync");
                return StatusCode(500, _errorMessage);
            }
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<AppUser>> DeleteUserAsync(int id)
        {
            try
            {
                return await _userService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in UserController/DeleteUserAsync");
                return StatusCode(500, _errorMessage);
            }
        }

        [HttpPost("ChangePassword")]
        public async Task<ActionResult<bool>> ChangeUserPasswordAsync(int userId, string currentPassword, string newPassword)
        {
            try
            {
                return await _userService.ChangePasswordAsync(userId, currentPassword, newPassword);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in UserController/ChangePasswordAsync");
                return StatusCode(500, _errorMessage);
            }
        }
    }
}
