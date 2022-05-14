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

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book book = BookViewList.SelectedItem as Book;
            book.getGenres();
            book.getAuthors();
            book.getTags();
           
            CurentWindows.mainWindow.model.CurrentPage = new PageViewBook(new ViewModels.BookViewModel(book));
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            BookViewList.SelectedItem = BookViewList.Items.CurrentItem;
            model.AcceptBook();
        }
        private void Button_Click2(object sender, System.Windows.RoutedEventArgs e)
        {
            BookViewList.SelectedItem = BookViewList.Items.CurrentItem;
            model.DeleteBook();
        }
    }
}
