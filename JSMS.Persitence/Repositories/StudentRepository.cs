using Dapper;
using JSMS.Application.Abstractions.StudentAbstraction;
using JSMS.Domain.Models;
using System.Data;

namespace JSMS.Persitence.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly IDbConnection _db;

    public StudentRepository(IDbConnection dbConnection)
    {
        _db = dbConnection;
    }

    public async Task<Student> GetStudentByIdAsync(int id)
    {
        string sql = "SELECT * FROM students WHERE StudentId = @Id";
        Student? student = await _db.QuerySingleOrDefaultAsync<Student>(sql, new { Id = id });
        return student;
    }


    public async Task<IEnumerable<Student>> GetAllStudentsAsync()
    {
        _db.Open();
        string sql = "SELECT StudentId, FirstName, LastName, Age, Grade, GroupID, IsActive, PhoneNumber, Email FROM students;";
        var students = await _db.QueryAsync<Student>(sql);

        return students.ToList();
    }

    public async Task AddStudentAsync(Student student)
    {
        string? FirstName = student.FirstName;
        string? LastName = student.LastName;
        int? Age = student.Age;
        int? Grade = student.Grade;
        string? Email = student.Email;
        _db.Open();

        string sql = "INSERT INTO students (StudentId, FirstName, LastName, Age, Grade, Email) VALUES (FLOOR(100000 + RAND() * 900000), @FirstName, @LastName, @Age, @Grade, @Email);";
        await _db.ExecuteAsync(sql, student);
        _db.Close();
    }
}
