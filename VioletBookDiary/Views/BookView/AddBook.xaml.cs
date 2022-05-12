using System.Windows;
using VioletBookDiary.MyServices;
using VioletBookDiary.ViewModels;
namespace VioletBookDiary.Views
{
    /// <summary>
    /// Логика взаимодействия для AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        AddBookViewModel Model;
        public ServiceClient Client;
        public AddBook(ServiceClient client)
        {
            InitializeComponent();
            Model = new AddBookViewModel(this);
            Client = client;
            DataContext = Model;
        }
    }
}
