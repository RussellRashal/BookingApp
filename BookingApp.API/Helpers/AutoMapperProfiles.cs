using AutoMapper;
using BookingApp.API.Models;
using BookingApp.API.Dtos;


namespace BookingApp.API.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CustomerForRegisterDto, Customer>();
            CreateMap<Customer, RecieveDto>();

        }
    }
}