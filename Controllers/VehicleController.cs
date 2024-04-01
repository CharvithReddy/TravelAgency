using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
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
    public class VehicleController : ControllerBase
    {
        private readonly ATADbContext _context;
        private readonly IMapper _automapper;

        public VehicleController(ATADbContext context, IMapper automapper)
        {
            _context = context;
            _automapper = automapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
        {
            return await _context.Vehicles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var Vehicle = await _context.Vehicles.FindAsync(id);
            if (Vehicle == null)
            {
                return NotFound("Vehicle not found");
            }
            return Ok(Vehicle);
        }

        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(VehicleDto vehicle)
        {
            var user= _automapper.Map<Vehicle>(vehicle);
            _context.Vehicles.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, VehicleDto vehicle)
        {
            
            var user = await _context.Vehicles.FindAsync(id);

            if (user == null)
            {
                return NotFound("Vehicle not found");
            }

            _automapper.Map(vehicle, user);

            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteVehicle(int id){
            var user = await _context.Vehicles.FindAsync(id);

            if(user == null){
                return NotFound("Vehicle not found");
            }
            _context.Vehicles.Remove(user);
            await _context.SaveChangesAsync();

            return Ok("Vehicle removed successfully");

        }
    }
}