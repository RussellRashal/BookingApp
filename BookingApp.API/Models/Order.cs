using System.Collections.Generic;

namespace BookingApp.API.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int Number { get; set; }

        public ICollection <FoodItem> FoodItems { get; set; }

    }
}