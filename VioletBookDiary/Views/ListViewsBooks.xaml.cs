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
        ListBooksViewModel model = new ListBooksViewModel();
        public ListViewsBooks()
        {
            //InitializeComponent();
            //List<Authors> authors = new List<Authors>();
            //authors.Add(new Authors("Джон Роулинг"));
            //List<Book> books = new List<Book>()
            //{

            //    new Book("Пттерны проетирования", authors),
            //    new Book("CLR via C#", authors),
            //    new Book("Исскуство программирования", authors)
            //};

            DataContext = model;
        }

        
    }
}
