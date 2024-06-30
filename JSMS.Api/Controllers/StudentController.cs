using JSMS.Application.Abstractions.StudentAbstraction;
using Microsoft.AspNetCore.Mvc;
using JSMS.Persitence.Repositories;
using JSMS.Domain.Models;
using Newtonsoft.Json.Serialization;
using System.Text.Json;
using MySqlX.XDevAPI.Common;
using JSMS.Persitence.Factories;


namespace JSMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class StudentController : ControllerBase
{
    DbConnectionFactory connectionFactory = new DbConnectionFactory();

    [HttpGet("GetStudentByID")]
    public async Task<IActionResult> GetStudentByID(int id) 
    {    
        StudentRepository studentRepository = new StudentRepository(connectionFactory.GetConnection());
        var student = await studentRepository.GetStudentByIdAsync(id); 
        return Ok(student);
    }
    
   
    [HttpGet("GetAllStudents")]
    public async Task<IActionResult> GetAllStudents()
    {
        StudentRepository studentRepository = new StudentRepository(connectionFactory.GetConnection());
        var students = await studentRepository.GetAllStudentsAsync();

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        var studentsDes = JsonSerializer.Serialize(students, options);
        return Ok(studentsDes);       
    }


    [HttpPost ("AddStudent")]
    public async void AddAStudent(string firstName, string lastName, int age, int grade, string email)
    {
        Student student = new Student();

        student.FirstName = firstName;
        student.LastName = lastName;
        student.Age = age;
        student.Grade = grade;
        student.Email = email;

        StudentRepository studentRepository = new StudentRepository(connectionFactory.GetConnection());
        await studentRepository.AddStudentAsync(student) ;
    }


    // DELETE api/<StudentController>/5
    [HttpDelete("DeleteStudentById")]
    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}
