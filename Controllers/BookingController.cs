using ATA.Data;
using ATA.DTO;
using ATA.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATA.Controllers
{
    // [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly ATADbContext _context;
          private readonly IMapper _automapper;

        public BookingController(ATADbContext context, IMapper automapper)
        {
            _context = context;
            _automapper = automapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            return await _context.Bookings.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            var Booking = await _context.Bookings.FindAsync(id);
            if (Booking == null)
            {
                return NotFound("Booking not found");
            }
            return Ok(Booking);
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(BookingDto Booking)
        {
             var user= _automapper.Map<Booking>(Booking);
            _context.Bookings.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, BookingDto Booking)
        {
             var user = await _context.Bookings.FindAsync(id);
            if (user == null)
            {
                return NotFound("Booking not found");
            }

            _automapper.Map(Booking, user);

            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteBooking(int id){
            var user = await _context.Bookings.FindAsync(id);

            if(user == null){
                return NotFound("Booking not found");
            }
            _context.Bookings.Remove(user);
            await _context.SaveChangesAsync();

            return Ok("Booking removed successfully");

        }
    }
}