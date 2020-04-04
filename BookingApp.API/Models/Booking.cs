using System;

namespace BookingApp.API.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Request { get; set; }

        public int NoPeople { get; set; }
        
        public Customer Customer { get; set;}

      

    
    }
}