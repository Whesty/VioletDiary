using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace VioletBookDiary.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Series { get; set; }
        public string Realease { get; set; }
        public List<Authors> Authors { get; set; }
        public string Description { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Tag> Tags { get; set; }
        public string Image { get; set; }
        public string File { get; set; }
        //Брать из UserTable
        public int Bookmark { get; set; }
        public string getAuthors()
        {
            string str = "";
            foreach (Authors a in Authors)
            {
                str = str + a.Name + " ";
            }
            return str;
        }
        public string getGenres() {
            string str = "";
            foreach (Genre a in Genres)
            {
                str = str + a.Name + " ";
            }
            return str;
        } 
        public string getTags() {
            string str = "";
            foreach (Tag a in Tags)
            {
                str = str + a.Name + " ";
            }
            return str;
        }


            public Book(int id, string name, bool status, string series,string realease, List<Authors> authors, string discription, List<Genre> genres, List<Tag> tags, string image)
        {
            Id = id;
            Name = name;
            Status = status;
            Series = series;
            Realease = realease;
            Authors = authors;
            Description = discription;
            Genres = genres;
            Tags = tags;
            Image = image;
        }
        public Book(string name, List<Authors> autors)
        {
            Name = name;
            Authors = autors;
        }
        public Book()
        {
            Image = @"D:\VioletDiary\VioletBookDiary\Views\Resources\Icons\Diary.ico";
            Tags = new List<Tag>();
            Genres = new List<Genre>();
            Authors = new List<Authors>();
            
        }

    }
}
