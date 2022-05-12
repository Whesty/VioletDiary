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
        //public ObservableCollection<>
        #region Commands
        //public ICommand open_PageViewBook => new DelegateCommand(Open_PageViewBook);
        //private void Open_PageViewBook()
        //{
        //    //Открытие страницы
        //    PageViewBook viewBook = new PageViewBook();

        //    CurrentPage = new FeedBackBook(Book.Id);
        //    win.Button_FeedBack.IsEnabled = false;
        //    win.Button_Paint.IsEnabled = true;
        //}
        private Page currentpage;
        
        public Page CurrentPage
        {
            get { return currentpage; }
            set
            {
                this.currentpage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }
        private FeedBackBook feedBack;
        private PaintBook paintBook;
        public void Open_PageViewBook()
        {
            feedBack = new FeedBackBook(Book.Id);
            paintBook = new PaintBook(Book.Id);
            CurrentPage = feedBack;
            CurentWindows.pageViewBook.Button_FeedBack.IsEnabled = false;
            CurentWindows.pageViewBook.Button_Paint.IsEnabled = true;
        }
        public ICommand open_FeedBack => new DelegateCommand(Open_FeedBack);
        private void Open_FeedBack()
        {
            CurrentPage = feedBack;
            CurentWindows.pageViewBook.Button_FeedBack.IsEnabled = false;
            CurentWindows.pageViewBook.Button_Paint.IsEnabled = true;
        }
        public ICommand open_Paint => new DelegateCommand(Open_Paint);
        private void Open_Paint()
        {
            CurrentPage = paintBook;
            CurentWindows.pageViewBook.Button_FeedBack.IsEnabled = true;
            CurentWindows.pageViewBook.Button_Paint.IsEnabled = false;

        }
        #endregion
    }

}
