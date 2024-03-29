﻿using System;
using System.ComponentModel.DataAnnotations;
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

                try
                {
                    string str = CurrentClient.service.Registration(email, password);
                    MessengViewModel.Show(str);
                }
                catch (Exception ex)
                {
                    MessengViewModel.Show("Ошибка при регистрации", "Возможно данный пользователь уже сущсвует");
                    return;
                }
                reg.Close(); }
          
        
        public  bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }
}
