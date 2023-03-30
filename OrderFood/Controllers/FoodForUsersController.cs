using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderFood.Data;
using OrderFood.Models;

namespace OrderFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodForUsersController : ControllerBase
    {
        private readonly API_OrderFood_Entities _context;
        private readonly IMapper _mapper;

        public FoodForUsersController(API_OrderFood_Entities Context, IMapper Mapper)
        {
            _context = Context;
            _mapper = Mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFoodForUser()
        {
            try
            {
                var data = _mapper.Map<List<FoodForUserModel>>(await _context.FoodForUsers!.ToListAsync());
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodForUserByID(string id)
        {
            try
            {
                var data = _mapper.Map<FoodForUserModel>(await _context.FoodForUsers!.Where(x => x.FoodID == id).FirstOrDefaultAsync());
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
        public async Task<IActionResult> InsertFoodForUser(FoodForUserModel Model)
        {
            try
            {
                Model.FoodID = Guid.NewGuid().ToString();
                var data = new FoodForUser();
                data = _mapper.Map<FoodForUser>(Model);
                if (data != null)
                {
                    _context.FoodForUsers!.Add(data);
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
        public async Task<IActionResult> UpdateFoodForUser(FoodForUserModel Model)
        {
            try
            {
                var data = await _context.FoodForUsers!.FirstOrDefaultAsync(x => x.FoodID == Model.FoodID);
                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    data.FoodName = Model.FoodName;
                    data.Type = Model.Type;
                    data.CreatedDate = Model.CreatedDate;
                    data.UnitID = Model.UnitID;
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
        public async Task<IActionResult> DeleteFoodForUser([FromRoute] string id)
        {
            try
            {
                var data = await _context.FoodForUsers!.Where(x => x.FoodID == id).FirstOrDefaultAsync();
                if (data != null)
                {
                    _context.FoodForUsers!.Remove(data);
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
