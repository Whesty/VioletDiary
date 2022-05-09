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
    public class UserInfoViewModel
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Info { get; set; }
        public int Id { get; set; }
        public string DataCreate { get; set; }
        public string AccessLevel { get; set; }
        public UserInfoViewModel(User user)
        {
            Name = user.Name;
            Avatar = user.Avatar;
            Info = user.Info;
            Id = user.Id;
            DataCreate = user.DataCreate;
        }
        public ICommand userUpdate => new DelegateCommand(UserUpdate);
        public void UserUpdate()
        {
            
        }
    }
}
