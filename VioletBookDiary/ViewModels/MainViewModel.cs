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
    public class MainViewModel : ViewModelBase
    {
        

        #region Constructor

        //public MainViewModel()
        //{
        //    BooksList = new List<BookViewModel>(books.Select(b => new BookViewModel(b)));
        //}
        public MainViewModel()
        {
            //BooksList = new List<BookViewModel>();
            
            User_Info = new UserInfo();
            client = new ServiceClient(new InstanceContext(new VDMyServiceCallBack()));
            Admin = new AdminListBook();
        }
        public User user { get; set; }
        public MainPage Main;
        private Page User_Info;
        private Page currentpage;
        private Page Admin;
        private Page Catalog;
        private Window AddBook;
        private EditItemsBook EditItemsBook;
        public ServiceClient client;
        public Page CurrentPage
        {
            get { return currentpage; }
            set
            {
                currentpage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        public ICommand open_Main => new DelegateCommand(Open_Main);
        private void Open_Main()
        {
            CurentWindows.Add(Main);
        }
        public ICommand open_UserInfo => new DelegateCommand(Open_UserInfo);
        private void Open_UserInfo()
        {

            CurentWindows.Add(User_Info);
        }
        public ICommand open_AddBook => new DelegateCommand(Open_AddBook);
        private void Open_AddBook()
        {
            AddBook = new AddBook();
            AddBook.Show();
        }
        public ICommand open_EditDataBase => new DelegateCommand(Open_EditDataBase);
        private void Open_EditDataBase()
        {
            EditItemsBook = new EditItemsBook();
            EditItemsBook.Show();
        }
        public ICommand updateWindow => new DelegateCommand(UpdateWindow);
        private void UpdateWindow()
        {

            Main = new MainPage();
            CurentWindows.mainPage.Button_ListBook.IsEnabled = false;
            CurentWindows.mainPage.Filters.IsEnabled = true;
            User_Info = new UserInfo();
            CurrentUser.SetUser(user);
            client = new ServiceClient(new InstanceContext(new VDMyServiceCallBack()));

            Admin = new AdminListBook();
            CurrentPage = Main;
        }
        public ICommand open_Admin => new DelegateCommand(Open_Admin);
        private void Open_Admin()
        {
            Admin = new AdminListBook();
            CurentWindows.Add(Admin);
        }
        public ICommand open_Catalog => new DelegateCommand(Open_Catalog);
        private void Open_Catalog()
        {
            Catalog = new Catalog();
            CurentWindows.Add(Catalog);
        }

        #endregion
    }
}
