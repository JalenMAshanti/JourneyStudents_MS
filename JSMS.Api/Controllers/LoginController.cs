using JSMS.Persitence.Factories;
using JSMS.Persitence.Models.Login;
using JSMS.Persitence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JSMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {

        DbConnectionFactory connectionFactory = new DbConnectionFactory();

        private readonly LoginRepository _LoginRepository;

        public LoginController()
        {
            _LoginRepository = new LoginRepository(connectionFactory.GetConnection());
        }


        [HttpGet("UserLogin")]
        public async Task<IActionResult> UserLogin(string email, string password)
        {

            var request = new LoginRequest(email, password);

            var user = await _LoginRepository.LoginUserAsync(request);

            if (user.Password is null || user.Email is null)
            {
                return NotFound("Incorrect Username or Password, Please try again.");
            }
            else
            {
                return Ok(user);
            }
        }
    }
}
