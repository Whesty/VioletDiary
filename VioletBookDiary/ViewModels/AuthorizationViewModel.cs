using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VioletBookDiary.Commands;
using VioletBookDiary.Views;
using VioletBookDiary.MyServices;
using System.ServiceModel;

namespace VioletBookDiary.ViewModels
{
    internal class AuthorizationViewModel : ViewModelBase
    {
        public void OnCallback(string message)
        {
            throw new NotImplementedException();
        }
        ContentControl control;
        private double contentOpacity;
        public string login { get; set; }

        public string password { get; set; }
        public double ContentOpacity
        {
            get => contentOpacity;
            set
            {
                contentOpacity = value;
                OnPropertyChanged("Opacity");
            }
        }

        public ContentControl Content
        {
            get => control;
            set
            {
                control = value;
                OnPropertyChanged("Control");
            }
        }

        public ICommand gotoregistration => new DelegateCommand(GoToRegistration);
        private Logon logon;

        public AuthorizationViewModel()
        {

            //logon = new Logon(window);

            //Content = logon.GetPage("login");
            ContentOpacity = 1.0;
        }
        public AuthorizationViewModel(Logon window)
        {

            logon = window;

            //Content = logon.GetPage("login");
            ContentOpacity = 1.0;
        }



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
                MessageBox.Show("Введите логин и пароль");
                return;
            }
            client = new ServiceClient(new InstanceContext(new VDMyServiceCallBack()));
               Dictionary<string, string> log = client.Login(email, password);

            try
            {
                
               //Dictionary<string, string> log = client.Login(email, password);
                
                
            }
            catch (Exception ex) { 
                MessageBox.Show("Неправельный логин и пароль");
                return;
            }
            //client.Open();
            Window window = new MainWindow();
            window.Show();
            //Service.ServiceClient.Login(email, password);
            logon.Close();

        }

        private async void SlowOpacity(UserControl control)
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i > 0.0; i -= 0.1)
                {
                    ContentOpacity = i;
                    Thread.Sleep(50);
                }

                Content = control;

                for (double i = 0.0; i < 1.1; i += 0.1)
                {
                    ContentOpacity = i;
                    Thread.Sleep(50);
                }
            });
        }
    }
}
