using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VioletBookDiary.Commands;
using VioletBookDiary.Models;

namespace VioletBookDiary.ViewModels
{
    public class CatalogViewModel : ViewModelBase
    {
        private List<BookViewModel> FullBooks;
        private List<BookViewModel> booksList { get; set; }
        public List<BookViewModel> BooksList { get => booksList; set {
                booksList = value;
                OnPropertyChanged("BooksList");
            } }
        public List<Genre> Ganres { get; set; }
        public List<Authors> Authors { get; set; }
        public List<Tag> TheListTags { get; set; }
        public CatalogViewModel()
        {
            getAuthors();
            getGenre();
            getTags();
            getListBook();
            FullBooks = BooksList;
            FiltrList = FullBooks;
        }
        #region Command
        public List<Tag> selecttags = new List<Tag>();
        public ICommand button_Filtr => new DelegateCommand(Button_Filtr);
        private void Button_Filtr()
        {
            CurentWindows.catalog.DataList.ItemsSource = null;
            Genre selectgen = CurentWindows.catalog.GanreFiltr.SelectedItem as Genre;
            Authors selectauthors = CurentWindows.catalog.AuthorsFiltr.SelectedItem as Authors;
            if (selectgen == null && selectauthors == null && selecttags.Count == 0)
            {
                BooksList = FullBooks;
            }
            List<BookViewModel> list = FullBooks;
            if (selectgen != null)
            {
                BooksList = new List<BookViewModel>();
                foreach (BookViewModel items in list)
                {
                    foreach (Genre i in items.Genres)
                    {
                        if (i.Id == selectgen.Id)
                        {
                            BooksList.Add(items);
                        }
                    }
                }
                list = BooksList;
            }
            
            if (selectauthors != null)
            {
                BooksList = new List<BookViewModel>();
                foreach (BookViewModel items in list)
                {
                    foreach (Authors i in items.Authors)
                    {
                        if (i.Id == selectauthors.Id)
                        {
                            BooksList.Add(items);
                        }
                    }
                }
                list = BooksList;
            }
            if(selecttags.Count > 0)
            {
                BooksList = new List<BookViewModel>();
                foreach (BookViewModel items in list)
                {
                    foreach (Tag i in items.Tags)
                    {
                        foreach(Tag j in selecttags)
                        if (i.Id == j.Id)
                        {
                            BooksList.Add(items);
                        }
                    }
                }
            }
            CurentWindows.catalog.DataList.ItemsSource = BooksList;
            FiltrList = booksList;
        }
        public List<BookViewModel> FiltrList;
        public void serch(string str)
        {
            List<BookViewModel> list = BooksList;
            CurentWindows.catalog.DataList.ItemsSource = null;
            BooksList = list.FindAll(x => x.Title.Contains(str));
            CurentWindows.catalog.DataList.ItemsSource = BooksList;
        }
        #endregion
        #region function
        public void getTags()
        {
            TheListTags = new List<Tag>();
            foreach(Dictionary<string, string> result in CurrentClient.service.getTags())
            {
                TheListTags.Add(new Tag() {
                    Id = int.Parse(result["id"]),
                    Name = result["name"]
                });
            }
        }
        public void getGenre()
        {
            Ganres = new List<Genre>();
            foreach (Dictionary<string, string> result in CurrentClient.service.getGenrs())
            {
                Ganres.Add(new Genre()
                {
                    Id = int.Parse(result["id"]),
                    Name = result["name"]
                });
            }
        }
        public void getAuthors()
        {
            Authors = new List<Authors>();
            foreach (Dictionary<string, string> result in CurrentClient.service.getAuthors())
            {
                Authors.Add(new Authors()
                {
                    Id = int.Parse(result["id"]),
                    Name = result["name"]
                });
            }
        }
        public void getListBook()
        {
            BooksList = new List<BookViewModel>();
            foreach (Dictionary<string, string> items in CurrentClient.service.getBooks())
            {
                Book book = new Book()
                {
                    Name = items["name"],
                    Description = items["description"],
                    Status = bool.Parse(items["status"]),
                    Id = int.Parse(items["id"]),
                    File = items["file"],
                    Image = items["image"],
                    Realease = int.Parse(items["Realese"])
                };
                if (book.Status)
                    BooksList.Add(new BookViewModel(book));
            }
        }
        #endregion
    }
}
