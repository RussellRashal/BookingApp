using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookingApp.API.Data;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;


using BookingApp.API.Models;


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
            var Customers = await _context.customers.ToListAsync();

            return Ok(Customers);
        }



    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> PostBook(Customer customers)
    {
        // var titleExists = 
        //     await _context.bookings.AnyAsync(b => b.Title == bookings.Title);

        // if (titleExists) 
        //     return BadRequest($"Title '{bookings.Title}' already exists");
               //......................................
        //  var FirstNameExists = 
        //     await _context.customers.AnyAsync(c => c.FirstName  == customers.FirstName);


        // var LastNameExists = 
        //     await _context.customers.AnyAsync(c => c.LastName  == customers.LastName);

        
        // var PasswordExists = 
        //     await _context.customers.AnyAsync(c => c.Password  == customers.Password);
    

               
        //  if ( FirstNameExists && LastNameExists && PasswordExists) 
        //     return BadRequest(" already exists");
    
        
            _context.customers.Add(customers);
            await _context.SaveChangesAsync();

             return Ok();
    
    
    }  













        



    }
}