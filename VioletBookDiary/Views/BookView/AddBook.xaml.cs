using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using VioletBookDiary.MyServices;
using VioletBookDiary.ViewModels;
namespace VioletBookDiary.Views
{
    /// <summary>
    /// Логика взаимодействия для AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        AddBookViewModel Model;
        public ServiceClient Client;
        public AddBook()
        {
            InitializeComponent();
            CurentWindows.addBook = this;
            Model = new AddBookViewModel();
            DataContext = Model;
        }

        private void TextBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void ButAuth_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox text = sender as TextBox;
            string pattern = @"[\w*; ]*;$";
            if (text.Text != null)
                if (!Regex.IsMatch(text.Text, pattern, RegexOptions.IgnoreCase))
                {
                   
                    text.BorderBrush = Brushes.Red;
                    ButAdd.IsEnabled = false;
                }
                else
                {
                    text.BorderBrush = Brushes.Green;
                    Regex regex = new Regex(@"([\w ]+);");
                    MatchCollection math = regex.Matches(text.Text);
                    foreach (Match mat in math)
                    {
                        string str = mat.Groups[1].Value;
                        if (str.Length > 25)
                        {
                            text.BorderBrush = Brushes.Red;
                            ButAdd.IsEnabled = false;
                        }
                    }
                }
            if (ButTag.BorderBrush != Brushes.Red && ButAuth.BorderBrush != Brushes.Red)
            {
                ButAdd.IsEnabled = true;
            }
        }
    }
}
