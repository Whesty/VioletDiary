using System.Windows;
using VioletBookDiary.Models;
using VioletBookDiary.ViewModels;

namespace VioletBookDiary.Views
{
    /// <summary>
    /// Логика взаимодействия для UserUpdate.xaml
    /// </summary>
    public partial class UserUpdate : Window
    {
        UpdateUserViewModel viewModel;
        public UserUpdate()
        {
            InitializeComponent();
            CurentWindows.userUpdate = this;
        }
        public UserUpdate(User user)
        {
            CurentWindows.userUpdate = this;
            InitializeComponent();
            viewModel = new UpdateUserViewModel(user);
            DataContext = viewModel;
        }
    }
}
