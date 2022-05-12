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
using System.Windows.Navigation;
using System.Windows.Shapes;
using VioletBookDiary.Views;
using VioletBookDiary.ViewModels;
using VioletBookDiary.Models;

namespace VioletBookDiary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel m;
        User user = new User();
        
        public MainWindow(User u)
        {
            InitializeComponent();
            CurentWindows.mainWindow = this;
            m = new MainViewModel(u);
            user = u;
            m.user = user;
            DataContext = m;
        }
    }
}
