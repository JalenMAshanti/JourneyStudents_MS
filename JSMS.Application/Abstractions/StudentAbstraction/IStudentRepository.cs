using JSMS.Domain.Models;


namespace JSMS.Application.Abstractions.StudentAbstraction;

public interface IStudentRepository
{
    Task<Student> GetStudentByIdAsync(int id);
    Task<IEnumerable<Student>> GetAllStudentsAsync();
    Task AddStudentAsync(Student student);
}
