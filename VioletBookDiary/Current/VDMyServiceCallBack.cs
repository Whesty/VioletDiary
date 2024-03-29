﻿using System.Collections.Generic;
using System.Management;
using System.Windows;
using VioletBookDiary.Models;
using VioletBookDiary.MyServices;
using VioletBookDiary.ViewModels;
using VioletBookDiary.Views;

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
            MessengViewModel.Show("Изменения прошли успешно!");
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
            UserInfo userInfo = new UserInfo();
            CurentWindows.userInfo = userInfo;
            //CurentWindows.Update();
        }
    }
}
