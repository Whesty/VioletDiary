using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VioletBookDiary.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Info { get; set; }
        public string Avatar { get; set; }
        public bool AccessLevel { get; set; }
        public string DataCreate { get; set; }
        public int IdAuthorized { get; set; }
        public User()
        {
            Id = 0;
            Name = "";
            Email = "";
            Info = "";
            Avatar = "";
            AccessLevel = false;
            DataCreate = "";
            IdAuthorized = 0;
        }
        public User(int id, string name, string email, string info, string avatar, string date, int idautorized)
        {
            Id = id;
            Name = name;
            Email = email;
            Info = info;
            Avatar = avatar;
            AccessLevel = false;
            DataCreate = date;
            IdAuthorized = idautorized;
        }
    }
}
