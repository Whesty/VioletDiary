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
        public Book book;
        public EditItemsBook()
        {
            InitializeComponent();
            NameTable.SelectedIndex = 0;
            viewModel = new EditItemsBookViewModel(book, this);
            DataContext = viewModel;
            AllItemsTable.FrozenColumnCount = 1;
        }

        private void NameTable_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (NameTable.SelectedIndex != 0)
            {
                viewModel = new EditItemsBookViewModel(book, this);
            }
        }
        private void AllItemsTable_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            int sel = AllItemsTable.SelectedIndex;
            
        }
    }
}
