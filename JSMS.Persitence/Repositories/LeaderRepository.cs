using Dapper;
using JSMS.Application.Abstractions.LeaderAbstraction;
using JSMS.Domain.Models;
using System.Data;

namespace JSMS.Persitence.Repositories;

public class LeaderRepository : ILeaderRepository
{

    private readonly IDbConnection _conn;

    public LeaderRepository(IDbConnection conn) 
    { 
        _conn = conn;        
    }



    public async Task AddLeaderAsync(string firstName, string lastName, long phoneNumber, int birthdate, string email)
    {
        _conn.Open();
        await _conn.ExecuteAsync("INSERT INTO leaders (LeaderId, FirstName, LastName, PhoneNumber, BirthDate, Email) VALUES (FLOOR(100000 + RAND() * 900000), @FirstName, @LastName, @PhoneNumber, @BirthDate, @Email);",
            new {FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber, BirthDate = birthdate, Email = email });        
        //return Task.CompletedTask;
    }

    public async Task<IEnumerable<Leader>> GetAllLeadersAsync()
    {
        var leaders = await _conn.QueryAsync<Leader>("SELECT * FROM leaders");
        return leaders;
        

    }

    public async Task<Leader> GetLeaderByIdAsync(int id)
    {
        _conn.Open();
        Leader? leader = await _conn.QueryFirstOrDefaultAsync<Leader>("SELECT * FROM leaders WHERE LeaderId = @Id;", new {Id = id });
        return leader;
    }
}
