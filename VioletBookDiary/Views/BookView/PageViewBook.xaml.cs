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
    /// Логика взаимодействия для PageViewBook.xaml
    /// </summary>
    public partial class PageViewBook : Page
    {
        public BookViewModel model;
        public PageViewBook(BookViewModel Model)
        {
            InitializeComponent();
            CurentWindows.pageViewBook = this;
            model = Model;
            DataContext = model;
            model.Open_PageViewBook();
        }

        private void ViewStatusMarks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            model.editBookMark();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            //UserBookInfo.GoBack();
            CurentWindows.mainWindow.GridPage.GoBack();
            CurentWindows.pageViewBook.Button_FeedBack.IsEnabled = !CurentWindows.pageViewBook.Button_FeedBack.IsEnabled;
            CurentWindows.pageViewBook.Button_Paint.IsEnabled = !CurentWindows.pageViewBook.Button_Paint.IsEnabled;
            CurentWindows.listViewsBooks.DataList.SelectedItem = null; 
        }
    }
}
