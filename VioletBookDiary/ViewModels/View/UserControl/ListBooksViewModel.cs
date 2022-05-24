using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VioletBookDiary.Commands;
using VioletBookDiary.Models;
using VioletBookDiary.Views;

namespace VioletBookDiary.ViewModels
{
    //VM для списка книг
    public class ListBooksViewModel : ViewModelBase
    {
        public List<BookViewModel> BooksList { get; set; }
        public ListViewsBooks win;
        public MainViewModel main;
        public ListBooksViewModel()
        {

            getListBook();
            SelectedBook = null;
            
        }
        public void getListBook()
        {
            BooksList = new List<BookViewModel>();
            foreach (Dictionary<string, string> items in CurrentClient.service.getBooks())
            {
                Book book = new Book()
                {
                    Name = items["name"],
                    Description = items["description"],
                    Status = bool.Parse(items["status"]),
                    Id = int.Parse(items["id"]),
                    File = items["file"],
                    Image = items["image"],
                    Realease = int.Parse(items["Realese"])
                };
                if (book.Status)
                    BooksList.Add(new BookViewModel(book));
            }
            BooksList = BooksList.OrderByDescending(x => x.Realease).ToList();
        }
        private BookViewModel selectedBook { get; set; }
        public BookViewModel SelectedBook
        {
            get => selectedBook; set { selectedBook = value; OnPropertyChanged("SelectedBook"); } }
        public ICommand open_PageViewBook => new DelegateCommand(Open_PageViewBook);
        private void Open_PageViewBook()
        {
           
            //Открытие страницы
            BookViewModel selectedBook = win.DataList.SelectedItem as BookViewModel;
            
            PageViewBook viewBook = new PageViewBook(selectedBook);
            
            viewBook.model = selectedBook;
            viewBook.model.win = viewBook;
            viewBook.DataContext = viewBook.model;
            if (win.DataList.SelectedItem != null)
            {
                CurentWindows.Add(viewBook);
            }
        }

        public BookViewModel BookViewModel
        {
            get => default;
            set
            {
            }
        }
    }
}
