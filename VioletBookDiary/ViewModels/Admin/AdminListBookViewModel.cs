using System;
using System.Collections.Generic;
using System.Windows.Input;
using VioletBookDiary.Commands;
using VioletBookDiary.Models;

namespace VioletBookDiary.ViewModels
{
    public class AdminListBookViewModel: ViewModelBase
    {
        private List<Book> LisBook;
        public List<Book> listBook { get { return LisBook; } 
            set { 
                if(LisBook != value)
                {
                    LisBook = value;
                    OnPropertyChanged("listBook");
                }
            } }
        public AdminListBookViewModel()
        {
            getListBook();
        }
        public void getListBook()
        {
            listBook = new List<Book>();
            foreach (Dictionary<string, string> item in CurrentClient.service.getBooks())
            {
                Book book = new Book();
                book.Id = Convert.ToInt32(item["id"]);
                book.Name = item["name"];
                book.Realease = int.Parse(item["Realese"]);
                book.Description = item["description"];
                book.Image = item["image"];
                book.Status = bool.Parse(item["status"]);
                book.File = item["file"];
                if (book.Status == false)
                {
                    listBook.Add(book);
                }
            }
            listBook.Reverse();
        }

        public ICommand acceptBook => new DelegateCommand(AcceptBook);
        public void AcceptBook()
        {
            try
            {
                int sel = CurentWindows.adminListBook.BookViewList.SelectedIndex;
                CurrentClient.service.EditBook(listBook[sel].Id, listBook[sel].Name, listBook[sel].Description, listBook[sel].Image, listBook[sel].File, listBook[sel].Series, listBook[sel].Realease.ToString(), CurrentUser._User.Id, true);
                CurentWindows.adminListBook = new Views.AdminListBook();
                CurentWindows.mainWindow.GridPage.GoBack();
                CurentWindows.Add(CurentWindows.adminListBook);
            }
            catch (Exception ex) {
                MessengViewModel.Show(ex.Message);
            }
        }
        public ICommand deleteBook => new DelegateCommand(DeleteBook);
        public void DeleteBook()
        {
            try
            {
                int sel = CurentWindows.adminListBook.BookViewList.SelectedIndex;
                CurrentClient.service.DeleteBooks(listBook[sel].Id);
                CurentWindows.adminListBook = new Views.AdminListBook();
                CurentWindows.mainWindow.GridPage.GoBack();
                CurentWindows.Add(CurentWindows.adminListBook);
            } catch(Exception ex)
            {
                MessengViewModel.Show(ex.Message);
            }
        }

    }
}
