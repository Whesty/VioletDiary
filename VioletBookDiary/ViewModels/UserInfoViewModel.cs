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
            get { return CurrentUser._User.Name; }
            set
            {
                if (CurrentUser._User.Name != value)
                {
                    CurrentUser._User.Name = value;
                    OnPropertyChanged("User");
                }
            }
        }
        public string Avatar {
            get { return CurrentUser._User.Avatar; }
            set
            {
                if (CurrentUser._User.Avatar != value)
                {
                    CurrentUser._User.Avatar = value;
                    OnPropertyChanged("Avatar");
                }
            }
        }
        public string Info {
            get { return CurrentUser._User.Info; }
            set
            {
                if (CurrentUser._User.Info != value)
                {
                    CurrentUser._User.Info = value;
                    OnPropertyChanged("Info");
                }
            }
        }
        public int Id { get; set; }
        public string DataCreate { get; set; }
        public string AccessLevel { get; set; }
        // Создать как отдельны статический класс User и использовать значения
        public User User { get; set; }
        public UserInfoViewModel()
        {
            User = CurrentUser._User;

            //Name = user.Name;
            //Avatar = user.Avatar;
            //Info = user.Info;
            //Id = user.Id;
            //DataCreate = user.DataCreate;
        }
        public ICommand userUpdate => new DelegateCommand(User_Update);
        public void User_Update()
        {
            UserUpdate win = new UserUpdate(CurrentUser._User);
            CurrentClient.callBack.userinfoVM = this;
            win.Show();
        }
    }
}
