using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VioletDiary.Models;
using System.Threading.Tasks;
using System.Windows.Input;


namespace VioletDiary.ViewModels
{
    internal class BookViewModel : ViewModelBase
    {
        public Book Book;
        
        public BookViewModel(Book book)
        {
            this.Book = book;
        }

        public string Title
        {
            get { return Book.Name; }
            set
            {
                if (Book.Name != value)
                {
                    Book.Name = value;
                    OnPropertyChanged("Title");
                }
            }
        }
        public string Author
        {
            get { return Book.Authors.FirstOrDefault().ToString(); }
            set
            {
                if (Book.Authors.FirstOrDefault().ToString() != value)
                {
                    Book.Authors[0] = new Authors(value);
                    OnPropertyChanged("Authors");
                }
            }
        }
        public bool Status
        {
            get { return Book.Status; }
            set
            {
                if (Book.Status != value)
                {
                    Book.Status = value;
                    OnPropertyChanged("Status");
                }
            }
        }
        public string Description
        {
            get { return Book.Description; }
            set
            {
                if (Book.Description != value)
                {
                    Book.Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        public List<Genre> Genres
        {
            get { return Book.Genres; }
            set
            {
                if (Book.Genres != value)
                {
                    Book.Genres = value;
                    OnPropertyChanged("Genres");
                }
            }
        }
        public List<Tag> Tags
        {
            get { return Book.Tags; }
            set
            {
                if (Book.Tags != value)
                {
                    Book.Tags = value;
                    OnPropertyChanged("Tags");
                }
            }
        }
        public string Realease 
        { 
            get { return Book.Realease; }
            set 
            {
                Book.Realease = value; 
                OnPropertyChanged("Realease");
            }
        }
        public string Series
        {
            get { return Book.Series; }
            set
            {
                if (Book.Series != value)
                {
                    Book.Series = value;
                    OnPropertyChanged("Series");
                }
            }
        }
        public string Image
        {
            get { return Book.Image; }
            set
            {
                if (Book.Image != value)
                {
                    Book.Image = value;
                    OnPropertyChanged("Image");
                }
            }
        }
        #region Commands
        
        #endregion
    }

}
