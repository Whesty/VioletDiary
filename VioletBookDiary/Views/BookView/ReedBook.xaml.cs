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
    /// Логика взаимодействия для ReedBook.xaml
    /// </summary>
    public partial class ReedBook : Page
    {
        string _path;
        ReadBookViewModel readBookViewModel;
        public ReedBook(string path, int mark)
        {

            _path = path;
            readBookViewModel = new ReadBookViewModel(_path);
            readBookViewModel.Chapter_selection = mark;
            Task task = readBookViewModel.ReadFB2FileStreamAsync();
            InitializeComponent();
            DataContext = readBookViewModel;
            Chapters.SelectedIndex = mark;
            CurentWindows.reedBook = this;

        }

        private void Chapters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            readBookViewModel.getParagraph(Chapters.SelectedIndex);
            DataContext = readBookViewModel;
            wbSample.Refresh();
            CurentWindows.pageViewBook.model.marks = Chapters.SelectedIndex;
            CurentWindows.pageViewBook.model.editBookMark();
        }
    }
}
