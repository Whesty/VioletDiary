using System.Windows;
using VioletBookDiary.Models;
using VioletBookDiary.ViewModels;

namespace VioletBookDiary.Views
{
    /// <summary>
    /// Логика взаимодействия для EditItemsBook.xaml
    /// </summary>
    public partial class EditItemsBook : Window
    {
        public EditItemsBookViewModel viewModel;
        public int _t;
        public Book book;
        public EditItemsBook()
        {
            viewModel = new EditItemsBookViewModel(book, this, _t);
            InitializeComponent();
            DataContext = viewModel;
        }
        public EditItemsBook(Book _b, int t)
        {

            InitializeComponent();
            book = _b;
            _t = t;
            viewModel = new EditItemsBookViewModel(book, this, _t);
            DataContext = viewModel;
        }

    }
}
