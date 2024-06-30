using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSMS.Domain.Models
{
    
    public class Student
    {
        public int StudentId { get; set; }
        public Enums.Roles Role { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }        
        public Enums.Gender Gender { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
        public int GroupID { get; set; }
        public bool IsActive { get; set; } = false;
        public int PhoneNumber { get; set; }
        public string? Email { get; set; }   


            public Student() 
            { 
            }

        public Student(string firstName, string lastName, int age, int grade, Enums.Gender gender) 
        { 
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Grade = grade;
            Gender = gender;
        }
         
        public static List<Student> studentList = new List<Student>();
    }
}
