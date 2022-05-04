using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VioletDiary.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VioletDiary.Views;
namespace VioletDiary.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public ObservableCollection<BookViewModel> BooksList { get; set; }

        #region Constructor

        public MainViewModel(List<Book> books)
        {
            BooksList = new ObservableCollection<BookViewModel>(books.Select(b => new BookViewModel(b)));
        }
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


        #endregion
    }
}
