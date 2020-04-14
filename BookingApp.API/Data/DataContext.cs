using System.Collections.Generic;
using BookingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options){}  
        

        public DbSet<Booking> bookings { get; set; }

        public DbSet<Customer> customers{ get; set;}

     
        public DbSet<Staff> staffs{ get; set; }

    

    
    }

}



      