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
using VioletDiary.ViewModels;

namespace VioletDiary.Views
{
    /// <summary>
    /// Логика взаимодействия для ReedBook.xaml
    /// </summary>
    public partial class ReedBook : Page
    {
        string _path;
        ReadBookViewModel readBookViewModel;
        public ReedBook()
        {
            InitializeComponent();
            readBookViewModel = new ReadBookViewModel(_path);
            Task task = readBookViewModel.ReadFB2FileStreamAsync();
            Chapters.SelectedIndex = 0;
            readBookViewModel.getParagraph(Chapters.SelectedIndex);
            DataContext = readBookViewModel;
        }

        private void Chapters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            readBookViewModel.getParagraph(Chapters.SelectedIndex);
            DataContext = readBookViewModel;
        }
    }
}
