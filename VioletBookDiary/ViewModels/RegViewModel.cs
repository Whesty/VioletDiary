using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VioletBookDiary.Commands;
using VioletBookDiary.MyService;
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
            
            InstanceContext binding = new InstanceContext(this);
            client = new ServiceClient(binding);
            try
            {
                
                client.Registration(email, password);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка");
                return;
            }
            //client.Open();
            //Service.ServiceClient.Login(email, password);
            reg.Close();

        }

    }
}
