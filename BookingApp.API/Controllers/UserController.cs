using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingApp.API.Data;
using BookingApp.API.Dtos;
using BookingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BookingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public UserController(IAuthRepository repo, IConfiguration config, IMapper mapper)
        {
            _config = config;
            _mapper = mapper;
            _repo = repo;


        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CustomerForRegisterDto customerForRegisterDto)
        {
            customerForRegisterDto.FirstName = customerForRegisterDto.FirstName.ToLower();

            if (await _repo.UserExists(customerForRegisterDto.FirstName))
                return BadRequest("The name exists");
            var CustomerToCreate = new Customer
            {
                FirstName = customerForRegisterDto.FirstName
            };

            var createCustomer = await _repo.Register(CustomerToCreate, customerForRegisterDto.Password);

            return StatusCode(201);



        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var customerFromRepo = await _repo.Login(userForLoginDto.FirstName, userForLoginDto.Password);

            if (customerFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, customerFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, customerFromRepo.FirstName)
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            //return Ok(new {
             //   token = tokenHanler.WriteToken(token)
          //  });

          //it the recieved user ID from the front side to the back
            var CustomerObj = _mapper.Map<RecieveDto>(customerFromRepo);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                
                
                CustomerObj.Id
            });

        }

    }
}