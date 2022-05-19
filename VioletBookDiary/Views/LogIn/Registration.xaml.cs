using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
            else
            {
                Passvord2_Box.BorderBrush = Brushes.Green;
                Reg_Button.IsEnabled = true;
            }
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            TextBox text = sender as TextBox;
            if (text.Text != null)
                if (reg.IsValidEmail(text.Text))
                {
                    text.BorderBrush = Brushes.Red;
                    Reg_Button.IsEnabled = false;
                }
                else
                {
                    text.BorderBrush = Brushes.Green;
                    Reg_Button.IsEnabled = true;
                }
           
        }
    }
}
