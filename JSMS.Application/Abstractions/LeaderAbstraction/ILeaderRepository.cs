using JSMS.Domain.Models;
using System.Runtime.ExceptionServices;

namespace JSMS.Application.Abstractions.LeaderAbstraction;

public interface ILeaderRepository
{
     Task<Leader> GetLeaderByIdAsync(int id);

    Task<IEnumerable<Leader>> GetAllLeadersAsync();

    Task AddLeaderAsync(string firstName, string lastName, long phoneNumber, int birthdate, string email);

}
