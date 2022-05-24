using System.Windows;
using System.Windows.Controls;
using VioletBookDiary.Models;
using VioletBookDiary.ViewModels;

namespace VioletBookDiary.Views
{
    /// <summary>
    /// Логика взаимодействия для AdminListBook.xaml
    /// </summary>
    public partial class AdminListBook : Page
    {
        public AdminListBookViewModel model;
        public AdminListBook()
        {
            model = new AdminListBookViewModel();
            DataContext = model;
            InitializeComponent();
            CurentWindows.adminListBook = this;
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            Button button = e.Source as Button;
            Book selectedBook = button.DataContext as Book;

            PageViewBook viewBook = new PageViewBook(new BookViewModel(selectedBook));
            viewBook.ViewLike.IsEnabled = false;
            viewBook.MoreInfo.IsEnabled = false;
            viewBook.MoreInfo.Opacity = 0;
            CurentWindows.Add(viewBook);

        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Button button = e.Source as Button;
            Book selectedBook = button.DataContext as Book;
            BookViewList.SelectedItem = selectedBook;
            model.AcceptBook();
        }
        private void Button_Click2(object sender, System.Windows.RoutedEventArgs e)
        {
            Button button = e.Source as Button;
            Book selectedBook = button.DataContext as Book;
            BookViewList.SelectedItem = selectedBook;
            model.DeleteBook();
        }
    }
}
