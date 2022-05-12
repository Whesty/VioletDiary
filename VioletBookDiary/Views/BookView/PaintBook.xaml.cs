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

namespace VioletBookDiary.Views.BookView
{
    /// <summary>
    /// Логика взаимодействия для PaintBook.xaml
    /// </summary>
    public partial class PaintBook : Page
    {
        PaintBookViewModel model;
        public PaintBook(int idbook)
        {
            InitializeComponent();
            model = new PaintBookViewModel(idbook);
            DataContext = model;
        }
    }
}
