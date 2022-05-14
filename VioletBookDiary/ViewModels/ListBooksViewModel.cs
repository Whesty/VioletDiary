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
                    Realease = items["Realese"]
                };
                if (book.Status)
                    BooksList.Add(new BookViewModel(book));
            }
        }
        public ICommand open_PageViewBook => new DelegateCommand(Open_PageViewBook);
        private void Open_PageViewBook()
        {
           
            //Открытие страницы
            BookViewModel selectedBook = win.DataList.SelectedItem as BookViewModel;
            
            PageViewBook viewBook = new PageViewBook(selectedBook);
            
            viewBook.model = selectedBook;
            viewBook.model.win = viewBook;
            viewBook.DataContext = viewBook.model;
            
            main.CurrentPage = viewBook;
        }
        
    }
}
