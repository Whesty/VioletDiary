using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace VioletDiary.Models
{
    class Book
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
        
    }
}
