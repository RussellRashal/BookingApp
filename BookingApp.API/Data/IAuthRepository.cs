using System;
using System.Threading.Tasks;
using BookingApp.API.Models;

namespace BookingApp.API.Data
{
    public interface IAuthRepository
    {
         
         Task<Customer> Register(Customer customer, String Password);
         Task<Customer> Login(string FirstName, string Password );

         Task<bool> UserExists(string FirstName);
        
    }
}