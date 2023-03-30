using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderFood.Data;
using OrderFood.Models;

namespace OrderFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly API_OrderFood_Entities _context;
        private readonly IMapper _mapper;

        public RolesController(API_OrderFood_Entities Context, IMapper Mapper)
        {
            _context = Context;
            _mapper = Mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRole()
        {
            try
            {
                var data = _mapper.Map<List<RoleModel>>(await _context.Roles!.ToListAsync());
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleByID(string id)
        {
            try
            {
                var data = _mapper.Map<RoleModel>(await _context.Roles!.Where(x => x.RoleID == id).FirstOrDefaultAsync());
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
        public async Task<IActionResult> InsertRole(RoleModel Model)
        {
            try
            {
                Model.RoleID = Guid.NewGuid().ToString();
                var data = new Role();
                data = _mapper.Map<Role>(Model);
                if (data != null)
                {
                    _context.Roles!.Add(data);
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
        public async Task<IActionResult> UpdateRole(RoleModel Model)
        {
            try
            {
                var data = await _context.Roles!.FirstOrDefaultAsync(x => x.RoleID == Model.RoleID);
                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    data.RoleName = Model.RoleName;
                    data.Order = Model.Order;
                    data.Description = Model.Description;
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
        public async Task<IActionResult> DeleteRole([FromRoute] string id)
        {
            try
            {
                var data = await _context.Roles!.Where(x => x.RoleID == id).FirstOrDefaultAsync();
                if (data != null)
                {
                    _context.Roles!.Remove(data);
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
