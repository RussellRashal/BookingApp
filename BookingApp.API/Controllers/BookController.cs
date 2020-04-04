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

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetBooking()
        {
            var Booking = await _context.bookings.Include(c => c.Customer).ToListAsync();

            return Ok(Booking);
        }




        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            var Booking = await _context.bookings.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(Booking);
        }

    //  POST api/values
       
          // if (bookings.Time && Table == exists)
             // return BadRequest
        //return Ok(bookings)

            // if(bookings has already been booked)
            //     return BadRequest("booking already booked");
            // return Ok(bookings);
            // using select queries WHere date = 1.00 and table = 1
            // return true         Task<IActionResult>


        // [AllowAnonymous]
        // [HttpPost]
        // public async Task<IList<Booking>> Checked(string Request, Booking bookings)
        // {
        //     var SearchData = await _context.bookings.
        //     Where(x => x.Title == Request).ToListAsync();


        //     return Ok(Booking);




        // }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> PostBook(Booking bookings)
    {
        // var titleExists = 
        //     await _context.bookings.AnyAsync(b => b.Title == bookings.Title);

        // if (titleExists) 
        //     return BadRequest($"Title '{bookings.Title}' already exists");

         var TimeExists = 
            await _context.bookings.AnyAsync(b => b.NoPeople  == bookings.NoPeople);
        
        var titleExists = 
            await _context.bookings.AnyAsync(b => b.Title == bookings.Title); 
            
         
         if (TimeExists  && titleExists) 
            return BadRequest(" already exists");
        
                
        
        
            _context.bookings.Add(bookings);
            await _context.SaveChangesAsync();

             return Ok();
    
    
    }  



  














    [AllowAnonymous]
    [HttpPut("{Id}")]
    public Booking PutBooking(int Id, [FromBody] Booking bookings )
    {
        var bookingsInDb = _context.bookings.SingleOrDefault(b => b.Id == Id);


        bookingsInDb.Title = bookings.Title;
        bookingsInDb.Date = bookings.Date;
        bookingsInDb.Request = bookings.Request;



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
