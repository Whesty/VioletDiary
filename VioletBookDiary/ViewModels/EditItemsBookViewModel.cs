using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VioletBookDiary.Models;
using System.Windows.Input;
using System.Collections.ObjectModel;
using VioletBookDiary.Commands;
using VioletBookDiary.Views;


namespace VioletBookDiary.ViewModels
{
    public class EditItemsBookViewModel : ViewModelBase
    {
        private ObservableCollection<Authors> _author = new ObservableCollection<Authors>();
        private ObservableCollection<Genre> _genre = new ObservableCollection<Genre>();
        private ObservableCollection<Tag> _tag = new ObservableCollection<Tag>();
        private ObservableCollection<string> name = new ObservableCollection<string>();
        private int _t = 0;
        public Book book;
        public EditItemsBook win { get; set; }
        public EditItemsBookViewModel(Book Book, EditItemsBook Win, int table)
        {
            this.book = Book;
            win = Win;
            _t = table;
            if (table == 1)
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
            }
            if (table == 2)
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
            } 
            if (table == 3)
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
