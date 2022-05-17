using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VioletBookDiary.Commands;
using VioletBookDiary.Models;
using VioletBookDiary.Views;

namespace VioletBookDiary.ViewModels
{
    public class UserInfoViewModel : ViewModelBase
    {
        // Свойства подверагающиеся изменениям прописать OnPropertyChanged();
        public string Name
        {
            get { return User.Name; }
            set
            {
                if (User.Name != value)
                {
                    User.Name = value;
                    OnPropertyChanged("User");
                }
            }
        }
        public string Avatar {
            get { return User.Avatar; }
            set
            {
                if (User.Avatar != value)
                {
                   User.Avatar = value;
                    OnPropertyChanged("Avatar");
                }
            }
        }
        public string Info {
            get { return User.Info; }
            set
            {
                if (User.Info != value)
                {
                    User.Info = value;
                    OnPropertyChanged("Info");
                }
            }
        }
        public int Id { get; set; }
        public string DataCreate { get; set; }
        public string AccessLevel { get; set; }
       
        public User User { get; set; }
        public UserInfoViewModel()
        {
            User = CurrentUser._User;
        }
        public UserInfoViewModel(int Id)
        {

        }
        #region Commands
        public ICommand userUpdate => new DelegateCommand(User_Update);
        public void User_Update()
        {
            UserUpdate win = new UserUpdate(CurrentUser._User);
            CurrentClient.callBack.userinfoVM = this;
            win.Show();
        }
        #endregion
        public List<Book> BooksList { get; set; }
        public List<Book> Reading { get; set; }
        public List<Book> WillRead { get; set; }
        public List<Book> Read { get; set; }

        #region Service
        public void getBookMarks()
        {
            Reading = new List<Book>();
            WillRead = new List<Book>();
            Read = new List<Book>();
            foreach (Dictionary<string, string> result in CurrentClient.service.getBookMarksUser(User.Id))
            {
                Book book = new Book();
                book.Id = Convert.ToInt32(result["Id"]);
                book.Name = result["Name"];
                book.Description = result["Description"];
                book.Image = result["Image"];
                book.Dete = DateTime.Parse(result["Date"]);
                book.Bookmark = Convert.ToInt32(result["Mark"]);
                book.BookReading = result["StatusReading"];
                if(book.BookReading == "Читаю")
                {
                    Reading.Add(book);
                }
                if(book.BookReading =="Буду читать")
                {
                    WillRead.Add(book);
                }
                if (book.BookReading == "Прочитанно")
                {
                    Read.Add(book);
                }
            }
        }
        #endregion

    }
}
