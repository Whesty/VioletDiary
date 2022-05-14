using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using VioletBookDiary.Commands;
using VioletBookDiary.Models;
using VioletBookDiary.Views;


namespace VioletBookDiary.ViewModels
{
    public class EditItemsBookViewModel : ViewModelBase
    {
        private List<Authors> _author = new List<Authors>();
        private List<Genre> _genre = new List<Genre>();
        private List<Tag> _tag = new List<Tag>();
        private List<Book> _book = new List<Book>();
        private List<string> name = new List<string>();
        private int _t = 0;
        public Book book;
        public EditItemsBook win { get; set; }
        public EditItemsBookViewModel(Book Book, EditItemsBook Win)
        {
            this.book = Book;
            win = Win;
            _t = win.NameTable.SelectedIndex;
            switch (_t) { 
            case 1:
                    {
                        {
                            //Получаем от сервера список авторов
                            foreach (Dictionary<string, string> item in CurrentClient.service.getAuthors())
                            {
                                Authors author = new Authors();
                                author.Id = Convert.ToInt32(item["id"]);
                                author.Name = item["name"];
                                author.Country = item["country"];
                                _author.Add(author);
                            }
                            win.AllItemsTable.ItemsSource = _author;
                            break;
                        }
                    }
                case 2:
                        {
                            //Получаем от сервера список жанров
                            foreach (Dictionary<string, string> item in CurrentClient.service.getGenrs())
                            {
                                Genre genre = new Genre();
                                genre.Id = Convert.ToInt32(item["id"]);
                                genre.Name = item["name"];
                                _genre.Add(genre);
                            }
                            win.AllItemsTable.ItemsSource = _genre;
                        break;
                        }
                case 3:
                        {
                            //Получаем от сервера список тегов
                            foreach (Dictionary<string, string> item in CurrentClient.service.getTags())
                            {
                                Tag tag = new Tag();
                                tag.Id = Convert.ToInt32(item["id"]);
                                tag.Name = item["name"];
                                _tag.Add(tag);
                            }
                            win.AllItemsTable.ItemsSource = _tag;
                        break;
                        }
                case 0:
                        {
                            //Получаем от сервера список книг
                            foreach (Dictionary<string, string> item in CurrentClient.service.getBooks())
                            {
                                Book author = new Book();
                                author.Id = Convert.ToInt32(item["id"]);
                                author.Name = item["name"];
                                author.Realease = item["Realese"];
                                author.Description = item["description"];
                                author.Image = item["image"];
                                author.Status = bool.Parse(item["status"]);
                                author.File = item["file"];
                                _book.Add(author);

                            }
                        win.AllItemsTable.ItemsSource = _book;
                        break;
                        }
                    }
        }
        public void IsChecked()
        {
            if (_t == 1)
            {
                win.AllItemsTable.SelectedItems.OfType<Authors>().ToList().ForEach(x => book.Authors.Add(x));
            }
        }
        public ICommand open_View => new DelegateCommand(Open_View);
        private void Open_View()
        {

        }
    }
}
