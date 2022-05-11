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
    internal class ListBooksViewModel : ViewModelBase
    {
        public ObservableCollection<BookViewModel> BooksList { get; set; }

        public ListBooksViewModel()
        {
            BooksList = new ObservableCollection<BookViewModel>();
            foreach (Dictionary<string, string> items in CurrentClient.service.getBooks())
            {
                Book book = new Book() { 
                   Name = items["name"],
                   Description = items["description"],
                   Status = bool.Parse(items["status"]),
                   Id = int.Parse(items["id"]),
                   File = items["file"],
                   Image = items["image"]
                };
                BooksList.Add(new BookViewModel(book));
            }
            // Не показывает список книг при загрузке приложения
        }
        public ICommand open_PageViewBook => new DelegateCommand(Open_PageViewBook);
        private void Open_PageViewBook()
        {
            //Открытие страницы
            PageViewBook viewBook = new PageViewBook();
        }

    }
}
