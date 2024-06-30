using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSMS.Domain;

namespace JSMS.Application
{
    public class StudentDTO
    {

        public Domain.Enums.Roles Role { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Domain.Enums.Gender Gender { get; set; }
        public int Age { get; set; }
        public DateOnly Birthdate { get; set; }
        public int Grade { get; set; }
        public int GroupID { get; set; }
        public bool IsActive { get; set; } = false;
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
