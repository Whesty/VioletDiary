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
    public class UserInfoViewModel
    {
        // Свойства подверагающиеся изменениям прописать OnPropertyChanged();
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Info { get; set; }
        public int Id { get; set; }
        public string DataCreate { get; set; }
        public string AccessLevel { get; set; }
        // Создать как отдельны статический класс User и использовать значения
        public User User { get; set; }
        public UserInfoViewModel(User user)
        {
            Name = user.Name;
            Avatar = user.Avatar;
            Info = user.Info;
            Id = user.Id;
            DataCreate = user.DataCreate;
            User = user;
        }
        public ICommand userUpdate => new DelegateCommand(User_Update);
        public void User_Update()
        {
            UserUpdate win = new UserUpdate(User);
            CurrentClient.callBack.userinfoVM = this;
            win.Show();
            
        }
    }
}
