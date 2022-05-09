using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using VioletBookDiary.Commands;
using VioletBookDiary.Views;

namespace VioletBookDiary.ViewModels
{
    public class AddBookViewModel
    {
        public string Title { get; set; }
        public string Authors { get; set; }
        public string Genres { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Tags { get; set; }
        MyServices.ServiceClient client;
        AddBook Win;
        public AddBookViewModel(AddBook window)
        {
            Win = window;
            client = Win.Client;
        }

        public ICommand open_LoadImage => new DelegateCommand(Open_LoadImage);
        private void Open_LoadImage()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image file (*.png;*jpg)|*png;*.jpg";
            if (openFile.ShowDialog() == true)
            {
                string selFileName = openFile.FileName;
                Image = selFileName;
            }
            Win.LoadingImage.Background = new ImageBrush(new System.Windows.Media.Imaging.BitmapImage(new Uri(Image)));
        } 
        public ICommand button_AddBook => new DelegateCommand(Button_AddBook);
        private void Button_AddBook()
        {
            if (Title == null || Authors == null || Genres == null || Description == null || Image == null || Tags == null)
            {
               // Win.Error.Text = "Please fill all fields";
            }
            
            
        }
    }
}
