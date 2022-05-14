using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VioletBookDiary.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using VioletBookDiary.Commands;
using VioletBookDiary.Views;
using System.Windows.Controls;
using VioletBookDiary.Views.BookView;

namespace VioletBookDiary.ViewModels
{
    public class BookViewModel : ViewModelBase
    {
        public Book Book;
        public PageViewBook win;
        
        public BookViewModel(Book book)
        {
            //CurrentPage = 
            if (book.Id != 0)
            {
                foreach (Dictionary<string, string> items in CurrentClient.service.getAuthorsBook(book.Id))
                {
                    book.Authors.Add(new Models.Authors()
                    {
                        Id = int.Parse(items["id"]),
                        Name = items["name"],
                        Country = items["country"]
                    });
                }
                foreach (Dictionary<string, string> items in CurrentClient.service.getGenresBook(book.Id))
                {
                    book.Genres.Add(new Models.Genre()
                    {
                        Id = int.Parse(items["id"]),
                        Name = items["name"]
                    });
                }
                foreach (Dictionary<string, string> items in CurrentClient.service.getTagsBook(book.Id))
                {
                    book.Tags.Add(new Models.Tag()
                    {
                        Id = int.Parse(items["id"]),
                        Name = items["name"]
                    });
                }
            }
            
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
        public List<Authors> Authors
        {
            get { return Book.Authors; }
            set
            {
                if (Book.Authors != value)
                {
                    Book.Authors = new List<Authors>(value);
                    OnPropertyChanged("Authors");
                }
            }
        }
        public string AuthStr { get
            {
                string authStr = "";
                foreach (Authors author in Book.Authors)
                {
                    authStr += author.Name + ", ";
                }
                if(authStr != "")
                authStr = authStr.Substring(0, authStr.Length - 2);
                return authStr;
            }
            set { } }
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
        public string GenreStr { get
            {
                string genreStr = "";
                foreach (Genre genre in Book.Genres)
                {
                    genreStr += genre.Name + ", ";
                }
                if(genreStr!="")
                genreStr = genreStr.Remove(genreStr.Length - 2);
                return genreStr;
            }set { } }
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
        public string TagStr { get 
            {
                string tagStr = "";
                foreach (Tag tag in Book.Tags)
                {
                    tagStr += tag.Name + ", ";
                }
                if(tagStr!="")
                tagStr = tagStr.Substring(0, tagStr.Length - 2);
                return tagStr;
            } set { } }
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
        #region BookMarks
        public string status_reading { get; set; }
        public int marks { get; set; }
        public bool Presence { get; set; }

        public bool getBookMark()
        {
            Dictionary<string, string> result = CurrentClient.service.getBookMarks(Book.Id, CurrentUser._User.Id);
            if (result == null) return false;
            status_reading = result["StatusReading"];
            marks = int.Parse(result["Marks"]);
            Presence = bool.Parse(result["Presence"]);
            return true;
        }
        public void addBookMark()
        {
            CurrentClient.service.addBookMarks(Book.Id, CurrentUser._User.Id, marks, status_reading, Presence);
        }
        public void editBookMark()
        {
            CurrentClient.service.editBookMarks(Book.Id, CurrentUser._User.Id, marks, status_reading, Presence);

        }
        #endregion
        #region Commands

        private Page currentpage;
        
        public Page CurentPage
        {
            get { return currentpage; }
            set
            {
                this.currentpage = value;
                OnPropertyChanged(nameof(CurentPage));
            }
        }
        private FeedBackBook feedBack;
        private PaintBook paintBook;
        public float Rating { get; set; }
        public int SaveMark { get; set; }
        public int CountImage { get; set; }
        public void Open_PageViewBook()
        {
            feedBack = new FeedBackBook(Book.Id);
            paintBook = new PaintBook(Book.Id);
            CountImage = paintBook.model.Count;
            Rating = feedBack.model.Rating;
            CurentPage = feedBack;
            CurentWindows.pageViewBook.Button_FeedBack.IsEnabled = false;
            CurentWindows.pageViewBook.Button_Paint.IsEnabled = true;
            if (getBookMark())
            {
                CurentWindows.pageViewBook.ViewLike.IsEnabled = false;
                CurentWindows.pageViewBook.ViewStatusMarks.SelectedItem = status_reading;
            }
            else
            {
                CurentWindows.pageViewBook.ViewStatusMarks.IsEnabled = false;
            }
        }
        public ICommand open_FeedBack => new DelegateCommand(Open_FeedBack);
        public void Open_FeedBack()
        {
            feedBack = new FeedBackBook(Book.Id);
            CurentPage = feedBack;
            CurentWindows.pageViewBook.Button_FeedBack.IsEnabled = false;
            CurentWindows.pageViewBook.Button_Paint.IsEnabled = true;
        }
        public ICommand open_Paint => new DelegateCommand(Open_Paint);
        public void Open_Paint()
        {
            paintBook = new PaintBook(Book.Id);
            CurentPage = paintBook;
            CurentWindows.pageViewBook.Button_FeedBack.IsEnabled = true;
            CurentWindows.pageViewBook.Button_Paint.IsEnabled = false;

        }
        public ICommand open_Reed => new DelegateCommand(Open_Reed);
        private void Open_Reed()
        {
            CurentWindows.Add(new ReedBook(Book.File, marks));
        }
        public ICommand button_Like => new DelegateCommand(ButtonLike);
        private void ButtonLike()
        {
            CurentWindows.pageViewBook.ViewStatusMarks.SelectedIndex = 0;
            marks = 0;
            addBookMark();
            CurentWindows.pageViewBook.ViewLike.IsEnabled = false;
            CurentWindows.pageViewBook.ViewStatusMarks.IsEnabled = true;

        }
        #endregion
    }

}
