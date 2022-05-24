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
    /// Логика взаимодействия для Catalog.xaml
    /// </summary>
    public partial class Catalog : Page
    {
        public CatalogViewModel model;
        public Catalog()
        {
            InitializeComponent();
            CurentWindows.catalog = this;
            model = new CatalogViewModel();
            this.DataContext = model;
            
        }
        private void CheckBoxZone_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox check = (CheckBox)sender;
            Tag tag = listTag.ItemsSource.OfType<Tag>().Where(x => x.Name == check.Content.ToString()).FirstOrDefault();
            if (tag != null)
            {
                model.selecttags.Add(tag);
            }
        }

        private void CheckBoxZone_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            Tag tag = listTag.ItemsSource.OfType<Tag>().Where(x => x.Name == box.Content.ToString()).FirstOrDefault();
            if (tag != null)
            {
                model.selecttags.Remove(tag);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            model.BooksList = model.FiltrList;
            model.serch(searchBox.Text);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = e.Source as Button;
            BookViewModel selectedBook = button.DataContext as BookViewModel;

            PageViewBook viewBook = new PageViewBook(selectedBook);
            CurentWindows.Add(viewBook); CurentWindows.Add(viewBook);
            
        }
    }
}
