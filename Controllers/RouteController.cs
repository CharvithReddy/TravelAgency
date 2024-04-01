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
    public class RouteController : ControllerBase
    {
        private readonly ATADbContext _context;
         private readonly IMapper _automapper;

        public RouteController(ATADbContext context, IMapper automapper)
        {
            _context = context;
            _automapper = automapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Route>>> GetRoutes()
        {
            return await _context.Routes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoute(int id)
        {
            var Route = await _context.Routes.FindAsync(id);
            if (Route == null)
            {
                return NotFound("Route not found");
            }
            return Ok(Route);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostRoute(RouteDto routed)
        {
            var user= _automapper.Map<Models.Route>(routed);
            _context.Routes.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoute(int id, RouteDto routed)
        {
            
            var user = await _context.Routes.FindAsync(id);

            if (user == null)
            {
                return NotFound("Route not found");
            }

            _automapper.Map(routed, user);

            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteRoute(int id){
            var user = await _context.Routes.FindAsync(id);

            if(user == null){
                return NotFound("Route not found");
            }
            _context.Routes.Remove(user);
            await _context.SaveChangesAsync();

            return Ok("Route removed successfully");

        }
    }
}