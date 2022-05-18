using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using VioletBookDiary.Commands;
using VioletBookDiary.Models;
using VioletBookDiary.Views;

namespace VioletBookDiary.ViewModels
{
    public class AddBookViewModel : ViewModelBase, IDataErrorInfo
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
        public string Series
        {
            get { return book.Series; }
            set
            {
                if (book.Series != value)
                {
                    book.Series = value;
                    OnPropertyChanged("Series");
                }
            }
        }
        public int Realease
        {
            get { return book.Realease; }
            set
            {
                if (book.Realease != value)
                {
                    book.Realease = value;
                    OnPropertyChanged("Release");
                }
            }
        }
        public string Authors { get; set; }

        public string Genres { get; set; }

        private List<Genre> genre = new List<Genre>();
        public string Description
        {
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
        public string Tags { get; set; }
        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                string pattern = @"(\w*; )*";
                switch (columnName)
                {
                    case "Tags":
                        if (!Regex.IsMatch(Tags, pattern, RegexOptions.IgnoreCase))
                        {
                            error = "Неправильный формат поля Тэги";
                        }
                        break;
                    case "Authors":
                        if (!Regex.IsMatch(Authors, pattern, RegexOptions.IgnoreCase))
                        {
                            error = "Неправильный формат поля Авторы";
                        }
                        break;
                }
                return error;
            }
        }
        public string Error
        {
            get { throw new FormatException(); }
        }        
        public string File { get; set; }
        public Book book { get; set; }
        public AddBookViewModel()
        {
            book = new Book();
            Tags = "";
            Authors = "";
            //Получаем от сервера список жанров
            foreach (Dictionary<string, string> item in CurrentClient.service.getGenrs())
            {
                Genre genre1 = new Genre();
                genre1.Id = Convert.ToInt32(item["id"]);
                genre1.Name = item["name"];
                genre.Add(genre1);
            }
            CurentWindows.addBook.GenresComboBox.ItemsSource = genre;
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
            CurentWindows.addBook.LoadingImage.Background = new ImageBrush(new System.Windows.Media.Imaging.BitmapImage(new Uri(Image)));
        }
        public ICommand open_LoadFile => new DelegateCommand(Open_LoadFile);
        private void Open_LoadFile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image file (*.fb2;)|*fb2;";
            if (openFile.ShowDialog() == true)
            {
                string selFileName = openFile.FileName;
                File = selFileName;
            }

        }
        public ICommand button_AddBook => new DelegateCommand(Button_AddBook);
        private void Button_AddBook()
        {
            if (Title == null || Authors == null || Genres == null || Description == null || Image == null || Tags == null)
            {
                MessengViewModel.Show("Ошибка", "Поля: Название, Автор, Жанр, Описание, Обложка и Таги - должны быть заполнены");
            }
            string result = CurrentClient.service.AddBook(Title, Authors, Genres, Tags, Description, Image, File, Series, Realease.ToString(), CurrentUser._User.Id);
             MessengViewModel.Show(result);

        }
    }
}
