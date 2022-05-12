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
using VioletBookDiary.ViewModels;

namespace VioletBookDiary.Views
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPageViewModel vm;
        public ListViewsBooks listBooks = new ListViewsBooks();
        //ListImage
        public MainPage()
        {
            InitializeComponent();
            CurentWindows.mainPage = this;
            Filters.SelectedItem = Filters.Items[0];
            ViewsListData.Children.Add(listBooks);
            Button_ListBook.IsEnabled = false;
        }
    }
}
