using System.Threading.Tasks;
using BookingApp.API.Data;
using BookingApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;

        }

        [HttpPost("Booking")]
        public async Task<IActionResult> TitleExists([FromBody]string Title)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            if(await _repo.TitleExists(Title))
                return BadRequest("This title is takem");

            var TitleToCreate = new Booking
            {
                Title = Title
            };


            return StatusCode(201);

    



        }



    }
}