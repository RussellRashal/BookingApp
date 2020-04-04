using System;
using System.Threading.Tasks;
using BookingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<Booking> booking(Booking booking, DateTime Date, string Request, int NoPeople)
        {
            await _context.bookings.AddAsync(booking);
            await _context.SaveChangesAsync();

            return booking;
        }

        public async Task<bool> TitleExists(string Title)
        {
            if(await _context.bookings.AnyAsync(x => x.Title == Title))
                return true;

            return false;
        }
    }
}