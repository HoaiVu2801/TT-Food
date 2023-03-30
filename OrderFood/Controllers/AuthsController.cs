using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderFood.Data;
using OrderFood.Models;
using OrderFood.Repositories;

namespace OrderFood.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly API_OrderFood_Entities _context;
        private readonly UserRepository _repo;

        public AuthsController(API_OrderFood_Entities Context, UserRepository Repository)
        {
            _repo = Repository;
            _context = Context;
        }

        [HttpPost("login")]

        public async Task<IActionResult> Login(UserModel Model)
        {
            try
            {
                var result = await _repo.LoginAsync(Model);
                var user = await _context.Users!.FindAsync(result.UserID);
                return Ok(new
                {
                    token = new
                    {
                        AccessToken = result.AccessToken,
                        RefreshToken = result.RefreshToken,
                    },
                    user = user
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("register")]

        public async Task<IActionResult> Register(UserModel Model)
        {
            try
            {
                var result = await _repo.RegisterAsync(Model);


                if (result)
                {
                    return Ok(Model.UserID);
                }
                else
                {
                    return BadRequest(Model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(TokenModel Model)
        {
            try
            {
                var result = await _repo.RefreshToken(Model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout(TokenModel Model)
        {
            try
            {
                var result = await _repo.LogoutAsync(Model);
                if (!result)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
