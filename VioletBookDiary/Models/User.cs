using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VioletBookDiary.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Info { get; set; }
        public string Avatar { get; set; }
        public bool AccessLevel { get; set; }
        public string DataCreate { get; set; }
        public int IdAuthorized { get; set; }
        
    }
}
