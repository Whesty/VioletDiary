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
using VioletBookDiary.Models;
using VioletBookDiary.ViewModels;

namespace VioletBookDiary.Views
{
    /// <summary>
    /// Логика взаимодействия для ListViewsBooks.xaml
    /// </summary>
    public partial class ListViewsBooks : UserControl
    {
        public ListBooksViewModel model;
        public ListViewsBooks()
        {
            InitializeComponent();
            CurentWindows.listViewsBooks = this;
            model = new ListBooksViewModel();
            model.win = this;
            DataContext = model;
            DataList.ItemsSource = model.BooksList;        
        }

        private void DataList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //BookViewModel selectedBook = model.win.DataList.SelectedItem as BookViewModel;

            //PageViewBook viewBook = new PageViewBook();
            //viewBook.model = selectedBook;
            //viewBook.DataContext = viewBook.model;
            //model.main.CurrentPage = viewBook;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BookViewModel selectedBook = model.win.DataList.SelectedItem as BookViewModel;
            CurentWindows.mainWindow.Back.IsEnabled = true;

            PageViewBook viewBook = new PageViewBook(selectedBook);
            CurentWindows.mainWindow.m.CurrentPage = viewBook;

        }
    }
}
