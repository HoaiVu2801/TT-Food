using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderFood.Data;
using OrderFood.Models;

namespace OrderFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly API_OrderFood_Entities _context;
        private readonly IMapper _mapper;

        public OrderDetailsController(API_OrderFood_Entities Context, IMapper Mapper)
        {
            _context = Context;
            _mapper = Mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderDetail()
        {
            try
            {
                var data = _mapper.Map<List<OrderDetailModel>>(await _context.OrderDetails!.ToListAsync());
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailByID(string id)
        {
            try
            {
                var data = _mapper.Map<OrderDetailModel>(await _context.OrderDetails!.Where(x => x.OrderDetailID == id).FirstOrDefaultAsync());
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
        public async Task<IActionResult> InsertOrderDetail(OrderDetailModel Model)
        {
            try
            {
                Model.OrderDetailID = Guid.NewGuid().ToString();
                var data = new OrderDetail();
                data = _mapper.Map<OrderDetail>(Model);
                if (data != null)
                {
                    _context.OrderDetails!.Add(data);
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
        public async Task<IActionResult> UpdateOrderDetail(OrderDetailModel Model)
        {
            try
            {
                var data = await _context.OrderDetails!.FirstOrDefaultAsync(x => x.OrderDetailID == Model.OrderDetailID);
                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    data.OrderID = Model.OrderID;
                    data.FoodID = Model.FoodID;
                    data.Quantity = Model.Quantity;
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
        public async Task<IActionResult> DeleteOrderDetail([FromRoute] string id)
        {
            try
            {
                var data = await _context.OrderDetails!.Where(x => x.OrderDetailID == id).FirstOrDefaultAsync();
                if (data != null)
                {
                    _context.OrderDetails!.Remove(data);
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
