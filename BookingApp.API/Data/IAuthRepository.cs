using System;
using System.Threading.Tasks;
using BookingApp.API.Models;

namespace BookingApp.API.Data
{
    public interface IAuthRepository
    {
         Task<Booking> booking(Booking booking, DateTime Date, string Request, int NoPeople);
   
        Task<bool> TitleExists(string Title);



    }
}