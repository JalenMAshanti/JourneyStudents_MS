using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSMS.Domain.Models
{
    public class Group
    {
        public int? GroupId { get; set; }
        public string? GroupName { get; set; }
        public List<Student>? Students { get; set; }    
        public List<Leader>? Leaders { get; set; }
        public int? StudentAmount { get; set; }  
        public int? LeaderAmount { get; set; }

     

    }
}
