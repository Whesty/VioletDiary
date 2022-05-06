using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VioletBookDiary.Commands;
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
        }
        public ICommand open_PageViewBook => new DelegateCommand(Open_PageViewBook);
        private void Open_PageViewBook()
        {
            //Открытие страницы
            PageViewBook viewBook = new PageViewBook();
        }

    }
}
