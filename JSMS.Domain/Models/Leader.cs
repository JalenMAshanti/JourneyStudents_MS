using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSMS.Domain.Models
{
    public class Leader
    {
        public int LeaderId { get; set; } 
        public Enums.Roles Role { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public long BirthDate { get; set; }
        public long PhoneNumber { get; set; }    
        public Enums.Gender Gender { get; set; }
        public int? GroupID { get; set; }
        public string? Bio { get; set; }
        public bool IsActive { get; set; }  

        public Leader() { }

        public Leader(Enums.Roles role, string firstName, string lastName, Enums.Gender gender) 
        {
            Role = role;    
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
        }
    }
}
