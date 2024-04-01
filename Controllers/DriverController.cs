using AutoMapper;
using ATA.Data;
using ATA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ATA.DTO;

namespace ATA.Controllers
{
    // [ApiController]
    [Route("api/[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly ATADbContext _context;
        private readonly IMapper _automapper;

        public DriverController(ATADbContext context, IMapper automapper)
        {
            _context = context;
            _automapper = automapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Driver>>> GetDrivers()
        {
            return await _context.Drivers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriver(int id)
        {
            var Driver = await _context.Drivers.FindAsync(id);
            if (Driver == null)
            {
                return NotFound("Driver not found");
            }
            return Ok(Driver);
        }

        [HttpPost]
        public async Task<ActionResult<Driver>> PostDriver(DriverDto driver)
        {
            var user = _automapper.Map<Driver>(driver);
            _context.Drivers.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriver(int id, DriverDto driver)
        {
            
            var user = await _context.Drivers.FindAsync(id);

            if (user == null)
            {
                return NotFound("Driver not found.");
            }

            _automapper.Map(driver,user);

            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteDriver(int id)
        {
            var user = await _context.Drivers.FindAsync(id);

            if(user == null)
            {
                return NotFound("Driver not found");
            }
            _context.Drivers.Remove(user);
            await _context.SaveChangesAsync();

            return Ok("Driver removed successfully");

        }
    }
}