using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VioletDiary.Models
{
    internal class Authors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public Authors(int id, string name, string country)
        {
            Id = id;
            Name = name;
            Country = country;
        }
    }
}
