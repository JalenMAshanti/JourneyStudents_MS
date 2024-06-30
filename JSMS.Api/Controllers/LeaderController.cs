using JSMS.Domain.Models;
using JSMS.Persitence.Factories;
using JSMS.Persitence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace JSMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderController : ControllerBase
    {
        DbConnectionFactory _conn = new DbConnectionFactory();


        [HttpGet("GetLeaderById")]
        public async Task<IActionResult> GetLeaderById(int id)
        {
            LeaderRepository leaderRepo = new LeaderRepository(_conn.GetConnection());
            
            var leader = JsonSerializer.Serialize( await leaderRepo.GetLeaderByIdAsync(id), 
                new JsonSerializerOptions{ WriteIndented = true });  
            
            return Ok(leader);
        }


        [HttpGet("GetAllLeaders")]
        public async Task<IActionResult> GetAllLeaders()
        {
            LeaderRepository leaderRepo = new LeaderRepository(_conn.GetConnection());
                            
            var leadersDes = JsonSerializer.Serialize( await leaderRepo.GetAllLeadersAsync(),
                new JsonSerializerOptions { WriteIndented = true });
           
            return Ok(leadersDes);
        }


        [HttpPost("AddANewLeader")]
        public async void Post(string firstName, string lastName, long phoneNumber, int birthdate, string email)
        {
            LeaderRepository leaderRepo = new LeaderRepository(_conn.GetConnection());

            await leaderRepo.AddLeaderAsync(firstName, lastName, phoneNumber, birthdate, email);
        }

       
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        
        [HttpDelete("RemoveLeader")]
        public void Delete(int id)
        {
        }
    }
}
