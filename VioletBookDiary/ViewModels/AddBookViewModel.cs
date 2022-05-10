using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using VioletBookDiary.Commands;
using VioletBookDiary.Models;
using VioletBookDiary.Views;

namespace VioletBookDiary.ViewModels
{
    public class AddBookViewModel: ViewModelBase
    {
        public string Title
        {
            get { return book.Name; }
            set
            {
                if (book.Name != value)
                {
                    book.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Authors {
            get { return book.getAuthors(); }
            set
            {
            }
        }
        public string Genres {
            get { return book.getGenres(); }
            set
            {
            }
        }
        public string Description {
            get { return book.Description; }
            set
            {
                if (book.Description != value)
                {
                    book.Description = value;
                    OnPropertyChanged("Discription");
                }
            }
        }
        public string Image
        {
            get { return book.Image; }
            set
            {
                if (book.Image != value)
                {
                    book.Image = value;
                    OnPropertyChanged("Image");
                }
            }
        }
        public string Tags {
            get { return book.getTags(); }
            set
            {
            }
        }
        public Book book { get; set; }
        MyServices.ServiceClient client;
        AddBook Win;
        public AddBookViewModel(AddBook window)
        {
            Win = window;
            client = Win.Client;
            book = new Book();
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
            //update_Aothors 

        }
        //public ICommand update_Aothors => new DelegateCommand(Update_Authors);
        //private void Update_Authors()
        //{
        //    EditItemsBook win_A = new EditItemsBook(book, 1);
        //    win_A.Show();
        //}
        //public ICommand update_Ganres => new DelegateCommand(Update_Ganres);
        //private void Update_Ganres()
        //{

        //    EditItemsBook win_G = new EditItemsBook(book, 2);
        //    win_G.Show();
        //}
        //public ICommand update_Tags => new DelegateCommand(Update_Tags);
        //private void Update_Tags()
        //{

        //    EditItemsBook win_T = new EditItemsBook(book, 3);
        //    win_T.Show();
        //}
    }
}
