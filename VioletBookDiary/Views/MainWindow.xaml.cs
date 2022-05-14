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
        public MainViewModel model;
        
        public MainWindow()
        {
            InitializeComponent();
            CurentWindows.mainWindow = this;
            model = new MainViewModel();
            DataContext = model;
            model.Main = new MainPage();
            CurentWindows.Add(model.Main);
            if(CurrentUser._User.AccessLevel != true)
            {
                AdminAccept.IsEnabled = false;
                AdminAccept.Visibility = Visibility.Hidden;
            }
        }
        
        
    }
}
