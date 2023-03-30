using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderFood.Data;
using OrderFood.Models;

namespace OrderFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodByRestaurantsController : ControllerBase
    {
        private readonly API_OrderFood_Entities _context;
        private readonly IMapper _mapper;

        public FoodByRestaurantsController(API_OrderFood_Entities Context, IMapper Mapper)
        {
            _context = Context;
            _mapper = Mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllFoodByRestaurant()
        {
            try
            {
                var data = _mapper.Map<List<FoodByRestaurantModel>>(await _context.FoodByRestaurants!.Include(e => e.Unit).ToListAsync());
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodByRestaurantByID(string id)
        {
            try
            {
                var data = _mapper.Map<FoodByRestaurantModel>(await _context.FoodByRestaurants!.Where(x => x.FoodID == id).FirstOrDefaultAsync());
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
        public async Task<IActionResult> InsertFoodByRestaurant(FoodByRestaurantModel Model)
        {
            try
            {
                Model.FoodID = Guid.NewGuid().ToString();
                var data = new FoodByRestaurant();
                data = _mapper.Map<FoodByRestaurant>(Model);
                if (data != null)
                {
                    _context.FoodByRestaurants!.Add(data);
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
        public async Task<IActionResult> UpdateFoodByRestaurant(FoodByRestaurantModel Model)
        {
            try
            {
                var data = await _context.FoodByRestaurants!.FirstOrDefaultAsync(x => x.FoodID == Model.FoodID);
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

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteFoodByRestaurant(string id)
        {
            try
            {
                var data = await _context.FoodByRestaurants!.Where(x => x.FoodID == id).FirstOrDefaultAsync();
                if (data != null)
                {
                    _context.FoodByRestaurants!.Remove(data);
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
