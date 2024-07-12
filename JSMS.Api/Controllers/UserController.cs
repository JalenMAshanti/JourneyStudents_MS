using JSMS.Persitence.DataTransferObjects;
using JSMS.Persitence.Factories;
using JSMS.Persitence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JSMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DbConnectionFactory connectionFactory = new DbConnectionFactory();
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = new UserRepository(connectionFactory.GetConnection());          
        }


        [HttpGet("GetUserByID")]
        public async Task<User_DTO> GetUserById(int id) => await _userRepository.GetUserByIdAsync(id); 
      
      
        [HttpDelete("DeleteUserById")]
        public async Task DeleteUser(int id) => await _userRepository.DeleteUserAsync(id);      
    }
}
