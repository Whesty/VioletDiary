using System.Windows;
using System.Windows.Controls;
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
            DataContext = model;
        } public UserInfo(int id)
        {
            InitializeComponent();
            model = new UserInfoViewModel(id);
            DataContext = model;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //DataList.SelectedItem = DataList.Items.CurrentItem;
            BookViewModel selectedBook = DataList.SelectedItem as BookViewModel;
            if (selectedBook != null)
            {
                PageViewBook viewBook = new PageViewBook(selectedBook);
                CurentWindows.Add(viewBook);
            }
        }
    }
}
