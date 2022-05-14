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

namespace VioletBookDiary.Views
{
    /// <summary>
    /// Логика взаимодействия для MessengeView.xaml
    /// </summary>
    public partial class MessengeView : Window
    {

        public MessengeView(string Title, string info)
        {
            InitializeComponent();
            TitelText.Text = Title;
            InfoText.Text = info;
        }
        public MessengeView(string info)
        {
            InitializeComponent();
            InfoText.Text = info;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
