namespace BookingApp.API.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
      
        public string LastName { get; set; }

        public byte[] PasswordHashing { get; set; } 

        public byte[] PasswordSalt { get; set; }      


    }
}