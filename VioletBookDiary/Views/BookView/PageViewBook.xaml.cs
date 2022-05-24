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
            switch (ViewStatusMarks.SelectedIndex)
            {
                case 0:
                    model.status_reading = "Читаю";
                    break;
                case 1:
                    model.status_reading = "Буду читать";
                    break;
                case 2:
                    model.status_reading = "Прочитанно";
                    break;
                default:
                    model.status_reading = "Брошенно";
                    break;
            }
            model.editBookMark();
        }
    }
}
