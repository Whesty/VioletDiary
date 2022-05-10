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
        } 
        public UserUpdate(User user)
        {
            InitializeComponent();
            viewModel = new UpdateUserViewModel(user);
            DataContext = viewModel;
        }
    }
}
