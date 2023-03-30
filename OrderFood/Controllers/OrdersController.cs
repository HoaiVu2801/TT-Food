using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderFood.Data;
using OrderFood.Models;

namespace OrderFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly API_OrderFood_Entities _context;
        private readonly IMapper _mapper;

        public OrdersController(API_OrderFood_Entities Context, IMapper Mapper)
        {
            _context = Context;
            _mapper = Mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            try
            {
                var data = _mapper.Map<List<OrderModel>>(await _context.Orders!.ToListAsync());
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderByID(string id)
        {
            try
            {
                var data = _mapper.Map<OrderModel>(await _context.Orders!.Where(x => x.OrderID == id).FirstOrDefaultAsync());
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
        public async Task<IActionResult> InsertOrder(OrderModel Model)
        {
            try
            {
                Model.OrderID = Guid.NewGuid().ToString();
                var data = new Order();
                data = _mapper.Map<Order>(Model);
                if (data != null)
                {
                    _context.Orders!.Add(data);
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
        public async Task<IActionResult> UpdateOrder(OrderModel Model)
        {
            try
            {
                var data = await _context.Orders!.FirstOrDefaultAsync(x => x.OrderID == Model.OrderID);
                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    data.UserID = Model.UserID;
                    data.OrderDate = Model.OrderDate;
                    data.Price = Model.Price;
                    data.UnitID = Model.UnitID;
                    data.Status = Model.UnitID;
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
        public async Task<IActionResult> DeleteOrder([FromRoute] string id)
        {
            try
            {
                var data = await _context.Orders!.Where(x => x.OrderID == id).FirstOrDefaultAsync();
                if (data != null)
                {
                    _context.Orders!.Remove(data);
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
