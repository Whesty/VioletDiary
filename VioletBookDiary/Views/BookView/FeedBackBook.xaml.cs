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

namespace VioletBookDiary.Views.BookView
{
    /// <summary>
    /// Логика взаимодействия для FeedBackBook.xaml
    /// </summary>
    public partial class FeedBackBook : UserControl
    {
        public FeedBackViewModel model;
        public FeedBackBook(int idbook)
        {
            InitializeComponent();
            CurentWindows.feedBackBook = this;
            model = new FeedBackViewModel(idbook);
            model.win = this;
            DataContext = model;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = e.Source as Button;
            Feedback feedback = button.DataContext as Feedback;
            CurentWindows.Add(new UserInfo(feedback.Id_user));
        }
    }
}
