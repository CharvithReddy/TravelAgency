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
    public class CustomerController : ControllerBase
    {
        private readonly ATADbContext _context;
        private readonly IMapper _automapper;   


        public CustomerController(ATADbContext context, IMapper automapper)
        {
            _context = context;
            _automapper = automapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound("Customer not found");
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer([FromBody]CustomerDto customer)
        {
            var user= _automapper.Map<Customer>(customer);
            _context.Customers.Add(user);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, CustomerDto customer)
        {

            var user = await _context.Customers.FindAsync(id);

            if (user == null)
            {
                return NotFound("Customer not found");
            }

            _automapper.Map(customer, user);

            await _context.SaveChangesAsync();
            return Ok(user);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteCustomer(int id){
            var user = await _context.Customers.FindAsync(id);

            if(user == null){
                return NotFound("Customer not found");
            }
            _context.Customers.Remove(user);
            await _context.SaveChangesAsync();

            return Ok("Customer removed successfully");

        }
        
        [HttpPost("Login")]
        public async Task<ActionResult<Customer>>Login(CustomerLoginDto customer)
        {
            var user= await _context.Customers.SingleOrDefaultAsync(x => x.CustomerMail == customer.CustomerMail && x.CustomerPassword == customer.CustomerPassword);
 
            if(user == null){
                return Unauthorized("Invalid Email or Password");
            }
            return Ok($"Login Successful. Welcome {user.CustomerFullName}.");
        }
    }
}