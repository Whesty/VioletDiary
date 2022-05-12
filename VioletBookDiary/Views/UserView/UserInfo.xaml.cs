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
        }
    }
}
