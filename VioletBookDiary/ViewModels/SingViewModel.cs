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

namespace VioletBookDiary.ViewModels
{
    public class SingViewModel: ViewModelBase
    {
        ContentControl control;
        private double contentOpacity;
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

        public ICommand GoToRegistrationCommand => new DelegateCommand(GoToRegistration);
        private Logon logon;

        public SingViewModel(Window window)
        {

            //logon = new Logon(window);

            //Content = logon.GetPage("login");
            ContentOpacity = 1.0; 
        }

        

        private void GoToRegistration()
        {
            Registration registration = new Registration();
            registration.Show();
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

