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
        void OnComboboxTextChanged(object sender, RoutedEventArgs e)
        {
            var tb = (TextBox)e.OriginalSource;
            if (tb.SelectionStart != 0)
            {
                GanreFiltr.SelectedItem = null; // Если набирается текст сбросить выбраный элемент
            }
            if (tb.SelectionStart == 0 && GanreFiltr.SelectedItem == null)
            {
                GanreFiltr.IsDropDownOpen = false; // Если сбросили текст и элемент не выбран, сбросить фокус выпадающего списка
            }

            GanreFiltr.IsDropDownOpen = true;
            if (GanreFiltr.SelectedItem == null)
            {
                // Если элемент не выбран менять фильтр
                CollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView(GanreFiltr.ItemsSource);
                cv.Filter = s => ((string)s).IndexOf(GanreFiltr.Text, StringComparison.CurrentCultureIgnoreCase) >= 0;
            }
        }

        private void AuthorsFiltr_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tb = (TextBox)e.OriginalSource;
            if (tb.SelectionStart != 0)
            {
                AuthorsFiltr.SelectedItem = null; // Если набирается текст сбросить выбраный элемент
            }
            if (tb.SelectionStart == 0 && AuthorsFiltr.SelectedItem == null)
            {
                AuthorsFiltr.IsDropDownOpen = false; // Если сбросили текст и элемент не выбран, сбросить фокус выпадающего списка
            }

            AuthorsFiltr.IsDropDownOpen = true;
            if (AuthorsFiltr.SelectedItem == null)
            {
                // Если элемент не выбран менять фильтр
                CollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView(AuthorsFiltr.ItemsSource);
                cv.Filter = s => ((string)s).IndexOf(AuthorsFiltr.Text, StringComparison.CurrentCultureIgnoreCase) >= 0;
            }

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
