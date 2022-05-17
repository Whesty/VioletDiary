using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VioletBookDiary.Commands;
using VioletBookDiary.Models;
using VioletBookDiary.MyServices;
using VioletBookDiary.Views;

namespace VioletBookDiary.ViewModels
{
    internal class AuthorizationViewModel : ViewModelBase
    {
        
        public string login { get; set; }

        public string password { get; set; }
        public ICommand gotoregistration => new DelegateCommand(GoToRegistration);
       
        private void GoToRegistration()
        {
            Registration registration = new Registration();
            registration.Show();
        }
        ServiceClient client;
        public ICommand log_In => new DelegateCommand(Log_In);

        private void Log_In()
        {
            string email = this.login;
            string password = this.password;
            if (email == null || password == null)
            {
                 MessengViewModel.Show("Введите логин и пароль");
                return;
            }

            Dictionary<string, string> log;
            try
            {

                log = CurrentClient.service.Login(email, password);
                if (log == null)
                    throw new Exception("Неправельные логин или пороль");
            }
            catch (Exception ex)
            {

                 MessengViewModel.Show(ex.Message.ToString());

                return;
            }
            //client.Open();
            User user = new User()
            {
                Id = int.Parse(log["id"]),
                Info = log["info"],
                AccessLevel = bool.Parse(log["AccessLevel"]),
                Name = log["name"],
                Avatar = log["avatar"],
                DataCreate = log["data_create"],
                IdAuthorized = int.Parse(log["id_authorized"])
            };
            CurrentUser.SetUser(user);
            MainWindow window = new MainWindow();
            CurentWindows.listViewsBooks.DataList.SelectedItem = null;
            window.Show();
            CurentWindows.logon.Close();
        }
    }
}
