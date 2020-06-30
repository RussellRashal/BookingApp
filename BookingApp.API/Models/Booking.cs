using System;

namespace BookingApp.API.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }        
       
        public int TableNumber { get; set; }

        public string AdditionalInfo { get; set; }

        public string Allergies { get; set; }

        public string Diet { get; set; }

        public int NoPeople { get; set; }
        
        public Customer Customers { get; set;}

        public int customerId { get; set; }   

    
    }
}