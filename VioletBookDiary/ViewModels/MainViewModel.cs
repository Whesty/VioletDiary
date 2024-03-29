﻿using System;
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
using VioletBookDiary.Views.Resources;

namespace VioletBookDiary.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        

        #region Constructor

        public MainViewModel()
        {
            
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
            Main = new MainPage();
            CurentWindows.Add(Main);
        }
        public ICommand open_UserInfo => new DelegateCommand(Open_UserInfo);
        private void Open_UserInfo()
        {
            User_Info = new UserInfo();
            CurentWindows.Add(User_Info);
        }
        public ICommand open_AddBook => new DelegateCommand(Open_AddBook);
        private void Open_AddBook()
        {
            if(CurentWindows.addBook != null)
            {
                CurentWindows.addBook.Close();
            }
            AddBook = new AddBook();
            AddBook.Show();
        }
        public ICommand updateWindow => new DelegateCommand(UpdateWindow);
        private void UpdateWindow()
        {

            Main = new MainPage();
            CurentWindows.mainPage.Button_ListBook.IsEnabled = false;
            
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
        public ICommand open_Setting => new DelegateCommand(Open_Setting);
        private void Open_Setting()
        {
            if(CurentWindows.setting != null)
            {
                CurentWindows.setting.Close();
            }
            Setting setting = new Setting();
            setting.Show();
        }
        public ICommand open_Catalog => new DelegateCommand(Open_Catalog);
        private void Open_Catalog()
        {
            Catalog = new Catalog();
            CurentWindows.Add(Catalog);
            //open_Setting
        }

        #endregion
    }
}
