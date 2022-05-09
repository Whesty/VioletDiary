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
using VioletBookDiary.MyServices;
using System.ServiceModel;

namespace VioletBookDiary.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        

        #region Constructor

        //public MainViewModel()
        //{
        //    BooksList = new ObservableCollection<BookViewModel>(books.Select(b => new BookViewModel(b)));
        //}
        public MainViewModel(User u)
        {
            //BooksList = new ObservableCollection<BookViewModel>();
            Main = new MainPage();
            User_Info = new UserInfo(u);
            user = u;
            client = new ServiceClient(new InstanceContext(new VDMyServiceCallBack()));
        }
        public User user { get; set; }
        private Page Main;
        private Page User_Info;
        private Page currentpage;
        private Window AddBook;
        public ServiceClient client;
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
        public ICommand open_UserInfo => new DelegateCommand(Open_UserInfo);
        private void Open_UserInfo()
        {
           
            CurrentPage = User_Info;
        }
        public ICommand open_AddBook => new DelegateCommand(Open_AddBook);
        private void Open_AddBook()
        {
            AddBook = new AddBook(client);
            AddBook.Show();
        }
        //public ICommand open_ReedBook => new DelegateCommand(Open_ReedBook);
        //private void Open_ReedBook()
        //{
            
        //    CurrentPage = Reed;
        //}

        #endregion
    }
}
