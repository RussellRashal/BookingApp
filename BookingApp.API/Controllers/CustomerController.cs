
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingApp.API.Data;
using BookingApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BookingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;
        public CustomerController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
            var Customer = await _context.customers.ToListAsync();

            return Ok(Customer);
        }

      




        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            var Booking = await _context.bookings.FirstOrDefaultAsync(x => x.Id == id);
            
            return Ok(Booking);
        }

        // POST api/values
        [AllowAnonymous]
        [HttpPost]
        public Customer PostBook(Customer customers)
        {           
             _context.customers.Add(customers);
             _context.SaveChanges();  

             return customers;        

        }



        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
