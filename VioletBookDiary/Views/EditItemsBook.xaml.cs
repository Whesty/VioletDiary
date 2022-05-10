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
