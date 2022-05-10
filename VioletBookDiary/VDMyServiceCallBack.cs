using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using VioletBookDiary.MyServices;
using VioletBookDiary.ViewModels;
using System.Windows;
using VioletBookDiary.Models;
using System.Management;

namespace VioletBookDiary
{
    public class VDMyServiceCallBack : IServiceCallback
    {
        private ManagementEventWatcher _watcher;
        public UserInfoViewModel userinfoVM { get; set; }
        public void OnCallback(string message)
        {
           
        }

        public void UpdateUserCallBack(Dictionary<string, string> result)
        {
            MessageBox.Show("User updated");
            User user = new User()
            {
                Id = int.Parse(result["id"]),
                Info = result["info"],
                AccessLevel = bool.Parse(result["AccessLevel"]),
                Name = result["name"],
                Avatar = result["avatar"],
                DataCreate = result["data_create"],
                IdAuthorized = int.Parse(result["id_authorized"])
            };
            CurrentUser.SetUser(user);
            userinfoVM = new UserInfoViewModel();
        }
    }
}
