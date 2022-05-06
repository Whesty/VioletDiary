using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VioletBookDiary.ViewModels;

namespace VioletBookDiary.Views
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        RegViewModel reg;
        public Registration()
        {
            InitializeComponent();
            reg = new RegViewModel(this);
            DataContext = reg;
        }

        private void Passvord_Box_PasswordChanged(object sender, RoutedEventArgs e)
        {
            reg.password = Passvord_Box.Password;
        }

        private void Passvord2_Box_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (Passvord2_Box.Password != reg.password)
            {
                Passvord2_Box.BorderBrush = Brushes.Red;
                Reg_Button.IsEnabled = false;
            }
            else { 
                Passvord2_Box.BorderBrush = Brushes.Green;
                Reg_Button.IsEnabled = true;
            }
        }
    }
}
