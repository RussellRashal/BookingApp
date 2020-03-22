using BookingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options){}  
        
         public DbSet<FoodItem> FoodItems { get; set; }

         public DbSet<Order> Order { get; set; }

        public DbSet<Booking> bookings { get; set; }

        
    
    
    }
}


      