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
        public int Id
        {
            get => User.Id; set
            {
             
            }
        }            
        
    
        public string DataCreate { get; set; }
        public string AccessLevel { get; set; }
       
        public User User { get; set; }
        public UserInfoViewModel()
        {
            User = CurrentUser._User;
            getBookMarks();
            BooksList = Reading;

        }
        public UserInfoViewModel(int Id)
        {
            Dictionary<string, string> result = CurrentClient.service.getUserInfo(Id);
            
                User = new User()
                {
                    Id = Convert.ToInt32(result["id"]),
                    Name = result["name"],
                    Avatar = result["avatar"],
                    Info = result["info"],
                    DataCreate = result["data_create"],
                    AccessLevel = bool.Parse(result["AccessLevel"])
                };
            CurentWindows.userInfo.EditButton.Opacity = 0;
            CurentWindows.userInfo.EditButton.IsEnabled = false;
            CurentWindows.userInfo.ExiteButton.Opacity = 0;
            CurentWindows.userInfo.ExiteButton.IsEnabled = false;
            getBookMarks();
            BooksList = Reading;
        }
        #region Commands
        public ICommand userUpdate => new DelegateCommand(User_Update);
        public void User_Update()
        {
            UserUpdate win = new UserUpdate(CurrentUser._User);
            CurrentClient.callBack.userinfoVM = this;
            win.Show();
        }
        public ICommand buttonReading => new DelegateCommand(Button_Reading);
        public void Button_Reading()
        {
            BooksList = Reading;
            CurentWindows.userInfo.bReading.IsEnabled = false;
            CurentWindows.userInfo.bWillRead.IsEnabled = true;
            CurentWindows.userInfo.bRead.IsEnabled = true;      
            CurentWindows.userInfo.DataList.ItemsSource = BooksList;
        }
        public ICommand buttonWillRead => new DelegateCommand(Button_WillRead);
        public void Button_WillRead()
        {
            BooksList = WillRead;
            CurentWindows.userInfo.bReading.IsEnabled = true;
            CurentWindows.userInfo.bWillRead.IsEnabled = false;
            CurentWindows.userInfo.bRead.IsEnabled = true;      
            CurentWindows.userInfo.DataList.ItemsSource = BooksList;
        }
        public ICommand buttonRead => new DelegateCommand(Button_Read);
        public void Button_Read()
        {
            BooksList = Read;
            CurentWindows.userInfo.bReading.IsEnabled = true;
            CurentWindows.userInfo.bWillRead.IsEnabled = true;
            CurentWindows.userInfo.bRead.IsEnabled = false;
            CurentWindows.userInfo.DataList.ItemsSource = BooksList;
        }
        public ICommand log_Out => new DelegateCommand(Log_Out);
        public void Log_Out()
        {

            CurentWindows.logon = new Logon();
            CurentWindows.logon.Show();
            CurentWindows.mainWindow.Close();
        }
        #endregion
        private List<Book> _BooksList;
        public List<Book> BooksList { get=> _BooksList; set {
                _BooksList = value;
                OnPropertyChanged("BooksList");
            } }
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
                book.Id = Convert.ToInt32(result["idBook"]);
                book.Name = result["name"];
                book.Description = result["description"];
                book.Image = result["image"];
                book.Date = DateTime.Parse(result["Date"]);
                book.DateReading = DateTime.Parse(result["DateReading"]);
                book.Bookmark = Convert.ToInt32(result["Marks"]);
                book.File = result["file"];
                book.Realease = int.Parse(result["Realese"]);
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
            Reading = Reading.OrderByDescending(x => x.DateReading).ToList();
            WillRead = WillRead.OrderByDescending(x => x.DateReading).ToList();
            Read = Read.OrderByDescending(x => x.DateReading).ToList();
        }
        #endregion

    }
}
