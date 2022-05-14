using System.Windows;
using VioletBookDiary.ViewModels;

namespace VioletBookDiary.Views
{
    /// <summary>
    /// Логика взаимодействия для Logon.xaml
    /// </summary>
    public partial class Logon : Window
    {
        AuthorizationViewModel authorizationViewModel;
        public Logon()
        {
            InitializeComponent();
            authorizationViewModel = new AuthorizationViewModel();
            DataContext = authorizationViewModel;
            CurentWindows.logon = this;
        }

        private void Passvord_Box_PasswordChanged(object sender, RoutedEventArgs e)
        {
            authorizationViewModel.password = Passvord_Box.Password;
        }
    }
}
