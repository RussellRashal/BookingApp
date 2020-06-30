using System;
using System.Threading.Tasks;
using BookingApp.API.Models;

namespace BookingApp.API.Data
{
    public interface IAuthRepository
    {
         // interface is used to match the specific attributes in the database
         Task<Customer> Register(Customer customer, String Password);
         Task<Customer> Login(string FirstName, string Password );

         Task<bool> UserExists(string FirstName);
        
    }
}