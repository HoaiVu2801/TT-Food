using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderFood.Data;
using OrderFood.Models;

namespace OrderFood.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly API_OrderFood_Entities _context;
        private readonly IMapper _mapper;

        public UsersController(API_OrderFood_Entities context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                var data = _mapper.Map<List<UserModel>>(await _context.Users!.Include(e => e.Role).ToListAsync());
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByID(string id)
        {
            try
            {
                var data = _mapper.Map<UserModel>(await _context.Users!.Where(x => x.UserID == id).FirstOrDefaultAsync());
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertUser(UserModel Model)
        {
            try
            {
                Model.UserID = Guid.NewGuid().ToString();
                var data = new User();
                data = _mapper.Map<User>(Model);
                if (data != null)
                {
                    _context.Users!.Add(data);
                    await _context.SaveChangesAsync();
                    return Ok(Model);
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

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserModel Model)
        {
            try
            {
                var data = await _context.Users!.FirstOrDefaultAsync(x => x.UserID == Model.UserID);
                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    data.UserName = Model.UserName;
                    data.Password = BCrypt.Net.BCrypt.HashPassword(Model.Password, "$2y$13$/.ThienHoang@#2023H");
                    data.Name = Model.Name;
                    data.Email = Model.Email;
                    data.RoleID = Model.RoleID;
                    data.UnitID = Model.UnitID;
                    data.PhoneNumber = Model.PhoneNumber;
                    data.Mode = Model.Mode;
                    await _context.SaveChangesAsync();
                    return Ok(data);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromRoute] string id)
        {
            try
            {
                var data = await _context.Users!.Where(x => x.UserID == id).FirstOrDefaultAsync();
                if (data != null)
                {
                    _context.Users!.Remove(data);
                    await _context.SaveChangesAsync();
                    return Ok(id);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
