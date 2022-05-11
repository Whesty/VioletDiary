using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VioletBookDiary.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        public int Id_user { get; set; }

        public int Id_book { get; set; }

        public string feedback { get; set; }

        public float Pating { get; set; }

        public DateTime DateCreat { get; set; }

        public string UserName { get; set; }
        public string UserAvatar { get; set; }

    }
}
