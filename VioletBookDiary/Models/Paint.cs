using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VioletBookDiary.ViewModels;

namespace VioletBookDiary.Models
{
    public class Paint: ViewModelBase
    {
        public int Id { get; set; }
        public int Id_Artist { get; set; }
        public string NameArtist { get; set; }
        public int Id_Book { get; set; }
        public int Id_User_Add { get; set; }
        public string link { get; set; }
        public DateTime Data { get; set; }
    }
}
