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
            CurentWindows.userInfo = this;
            model = new UserInfoViewModel();
          
            DataContext = model;
        } public UserInfo(int id)
        {
            InitializeComponent();
            CurentWindows.userInfo = this;
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
