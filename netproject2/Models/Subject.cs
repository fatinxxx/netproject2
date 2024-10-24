using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netproject2.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }  // Added Id as the primary key
        public string SubjectName { get; set; }
        public string Description { get; set; }
        // Foreign key for User
        public int UserId { get; set; }
        public User User { get; set; }  // Navigation property to User
    }
}

