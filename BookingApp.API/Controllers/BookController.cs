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
    public class BookController : ControllerBase
    {
        private readonly DataContext _context;
        public BookController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooking()
        {
            var Booking = await _context.bookings.Include(c => c.Customers).ToListAsync();

            return Ok(Booking);
        }




        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            var Booking = await _context.bookings.FirstOrDefaultAsync(x => x.customerId == id);

            return Ok(Booking);
        }

   

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> PostBook(Booking bookings)
    {
        // code below means that the user will check if the table exists 
        
         var TableExists = 
            await _context.bookings.AnyAsync(b => b.TableNumber  == bookings.TableNumber);
        
        var SameTime =
            await _context.bookings.AnyAsync(b => b.Date  == bookings.Date);
        // var titleExists = 
        //     await _context.bookings.AnyAsync(b => b.Title == bookings.Title);   // && titleExists in the if statement  

         
              if (TableExists && SameTime) 
                 return BadRequest("already exists");
             
    
            _context.bookings.Add(bookings);
            await _context.SaveChangesAsync();
            
             return Ok();
    
    
    }  


 

    [AllowAnonymous]
    [HttpPut("{Id}")]
    public Booking PutBooking(int Id, [FromBody] Booking bookings )
    {
        var bookingsInDb = _context.bookings.SingleOrDefault(b => b.customerId == Id);

        bookingsInDb.Date = bookings.Date;
        bookingsInDb.AdditionalInfo = bookings.AdditionalInfo;
        bookingsInDb.TableNumber = bookings.TableNumber;
        bookingsInDb.NoPeople = bookings.NoPeople;

        _context.SaveChanges();

        return bookingsInDb;
    }
 


















       











        // PUT api/values/5
        // [HttpPut("{id}")]

        
        //

        //


        // }



        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
}


}
