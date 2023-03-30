using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderFood.Data;
using OrderFood.Models;

namespace OrderFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly API_OrderFood_Entities _context;
        private readonly IMapper _mapper;

        public UnitsController(API_OrderFood_Entities Context, IMapper Mapper)
        {
            _context = Context;
            _mapper = Mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllUnit()
        {
            try
            {
                var data = _mapper.Map<List<UnitModel>>(await _context.Units!.ToListAsync());
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUnitByID(string id)
        {
            try
            {
                var data = _mapper.Map<UnitModel>(await _context.Units!.Where(x => x.UnitID == id).FirstOrDefaultAsync());
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

        [HttpPost("create")]
        public async Task<IActionResult> InsertUnit(UnitModel Model)
        {
            try
            {
                Model.UnitID = Guid.NewGuid().ToString();
                var data = new Unit();
                data = _mapper.Map<Unit>(Model);
                if (data != null)
                {
                    _context.Units!.Add(data);
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

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUnit(UnitModel Model)
        {
            try
            {
                var data = await _context.Units!.FirstOrDefaultAsync(x => x.UnitID == Model.UnitID);
                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    data.UnitName = Model.UnitName;
                    data.Type = Model.Type;
                    data.Address = Model.Address;
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

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUnit(string id)
        {
            try
            {
                var data = await _context.Units!.FirstOrDefaultAsync(x => x.UnitID == id);
                if (data != null)
                {
                    _context.Units!.Remove(data);
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
