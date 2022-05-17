using System.Windows;
using System.Windows.Controls;
using VioletBookDiary.Models;
using VioletBookDiary.ViewModels;

namespace VioletBookDiary.Views
{
    /// <summary>
    /// Логика взаимодействия для UserInfo.xaml
    /// </summary>
    public partial class UserInfo : Page
    {
        UserInfoViewModel model;

        public UserInfo()
        {
            InitializeComponent();
            model = new UserInfoViewModel();
            CurentWindows.userInfo = this;
            DataContext = model;
        } public UserInfo(int id)
        {
            InitializeComponent();
            model = new UserInfoViewModel(id);
            DataContext = model;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = e.Source as Button;
            Book selectedBook = button.DataContext as Book;

            PageViewBook viewBook = new PageViewBook(new BookViewModel(selectedBook));
            CurentWindows.Add(viewBook);
        }
    }
}
