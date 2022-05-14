﻿using System;
using System.Windows;
using System.Windows.Input;
using VioletBookDiary.Commands;
using VioletBookDiary.MyServices;
using VioletBookDiary.Views;

namespace VioletBookDiary.ViewModels
{
    public class RegViewModel
    {
        public string login { get; set; }
        public string password { get; set; }
        ServiceClient client;
        Registration reg;
        public ICommand reg_In => new DelegateCommand(Reg_In);
        public RegViewModel(Registration _reg)
        {
            reg = _reg;
        }
        private void Reg_In()
        {
            string email = this.login;
            string password = this.password;

            //client = new ServiceClient(new InstanceContext(new VDMyServiceCallBack()));
            try
            {
                //string str = client.Registration(email, password);
                string str = CurrentClient.service.Registration(email, password);
                MessengViewModel.Show(str);
            }
            catch (Exception ex)
            {
                 MessengViewModel.Show(ex.Message);
                return;
            }
            //client.Open();
            //Service.ServiceClient.Login(email, password);
            reg.Close();
        }

    }
}