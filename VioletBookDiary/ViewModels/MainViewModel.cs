using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VioletBookDiary.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VioletBookDiary.Views;
using VioletBookDiary.Commands;
namespace VioletBookDiary.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        

        #region Constructor

        //public MainViewModel()
        //{
        //    BooksList = new ObservableCollection<BookViewModel>(books.Select(b => new BookViewModel(b)));
        //}
        public MainViewModel()
        {
            //BooksList = new ObservableCollection<BookViewModel>();
            Main = new MainPage();
        }
        private Page Main;
        private Page Reed;
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

        public ICommand open_Main => new DelegateCommand(Open_Main);
        private void Open_Main()
        {
           
            CurrentPage = Main;
        }
        //public ICommand open_ReedBook => new DelegateCommand(Open_ReedBook);
        //private void Open_ReedBook()
        //{
            
        //    CurrentPage = Reed;
        //}

        #endregion
    }
}
