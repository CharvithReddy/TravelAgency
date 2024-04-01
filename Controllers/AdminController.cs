using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using ATA.Data;
using ATA.DTO;
using ATA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATA.Controllers
{
    // [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ATADbContext _context;

        public AdminController(ATADbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        {
            return await _context.Admins.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdmin(int id)
        {
            var Admin = await _context.Admins.FindAsync(id);
            if (Admin == null)
            {
                return NotFound("Admin not found");
            }
            return Ok(Admin);
        }

        [HttpPost]
        public async Task<ActionResult<Admin>> PostAdmin(Admin Admin)
        {
            _context.Admins.Add(Admin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdmin", new { id = Admin.AdminId }, Admin);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin(int id, Admin Admin)
        {
            if (id != Admin.AdminId)
            {
                return BadRequest("Matching not found");
            }

            var user = await _context.Admins.FindAsync(id);

            if (user == null)
            {
                return NotFound("Admin not found");
            }

            user.AdminEmail = Admin.AdminEmail;
            user.AdminPassword = Admin.AdminPassword;

            await _context.SaveChangesAsync();
            return Ok("Admin details edited successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteAdmin(int id) {
            var user = await _context.Admins.FindAsync(id);

            if(user == null){
                return NotFound("Admin not found");
            }
            _context.Admins.Remove(user); 
            await _context.SaveChangesAsync();

            return Ok("Admin removed successfully");

        }        [HttpPost("Login")]
        public async Task<ActionResult<Customer>>Login(AdminLoginDto admin)
        {
            var user= await _context.Admins.SingleOrDefaultAsync(x => x.AdminEmail == admin.AdminEmail && x.AdminPassword == admin.AdminPassword);
 
            if(user == null){
                return Unauthorized("Invalid Email or Password");
            }
            return Ok("Login Successful");
        }
    }
}