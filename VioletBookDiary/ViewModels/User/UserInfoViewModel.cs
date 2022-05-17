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
        #region Service
        public void getBookMarks()
        {
            
        }
        #endregion

    }
}
