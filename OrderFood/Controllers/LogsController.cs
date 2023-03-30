using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderFood.Data;
using OrderFood.Models;

namespace OrderFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly API_OrderFood_Entities _context;
        private readonly IMapper _mapper;

        public LogsController(API_OrderFood_Entities Context, IMapper Mapper)
        {
            _context = Context;
            _mapper = Mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLog()
        {
            try
            {
                var data = _mapper.Map<List<LogModel>>(await _context.Logs!.ToListAsync());
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogByID(string id)
        {
            try
            {
                var data = _mapper.Map<LogModel>(await _context.Logs!.Where(x => x.LogID == id).FirstOrDefaultAsync());
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
        public async Task<IActionResult> InsertLog(LogModel Model)
        {
            try
            {
                Model.LogID = Guid.NewGuid().ToString();
                var data = new Log();
                data = _mapper.Map<Log>(Model);
                if (data != null)
                {
                    _context.Logs!.Add(data);
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



        [HttpDelete]
        public async Task<IActionResult> DeleteLog([FromRoute] string id)
        {
            try
            {
                var data = await _context.Logs!.Where(x => x.LogID == id).FirstOrDefaultAsync();
                if (data != null)
                {
                    _context.Logs!.Remove(data);
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
