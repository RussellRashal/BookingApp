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
            _context = context; // this is the database context 

        }

        // the code below is the Login method that contains paramters of FirstName and password
        // the purpose of this method it to match the firstname with the datbase when the user logs in. 
        // This goes same for the password but the only difference is that its using password hashing algorthm
        public async Task<Customer> Login(string FirstName, string Password)
        {
            var customer = await _context.customers.FirstOrDefaultAsync(x => x.FirstName == FirstName);

            if(customer == null )
                return null;
            if(!VerifyHashPasswordHashing(Password, customer.PasswordHashing, customer.PasswordSalt))
                return null;
            return customer;    
        }

        private bool VerifyHashPasswordHashing(string password, byte[] passwordHashing, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
              
                var ProcessHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < ProcessHash.Length; i++)    // interates through the length of the password and increaments it to convertion
                {
                    if(ProcessHash[i] != passwordHashing[i]) return false; 
                }
            }
            return true;
        }

        public async Task<Customer> Register(Customer customer, string password)
        {
            byte[] passwordHashing, passwordSalt;
            CreatePasswordHashing(password, out passwordHashing, out passwordSalt);

            customer.PasswordHashing = passwordHashing;
            customer.PasswordSalt = passwordSalt;

            await _context.customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return customer;
        }
        // below this is to convert the password string into a hashing which gets stored in the db 
        private void CreatePasswordHashing(string password, out byte[] passwordHashing, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHashing = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            
        }

        // below its to check if the name of the user exists in the database then return true 


        public async Task<bool> UserExists(string FirstName)
        {
            if(await _context.customers.AnyAsync(x => x.FirstName == FirstName))
                return true;
            return false;    
        }

      
    }
}