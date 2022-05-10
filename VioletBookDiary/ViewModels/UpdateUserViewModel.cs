using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VioletBookDiary.Commands;
using VioletBookDiary.Models;
using VioletBookDiary.MyServices;

namespace VioletBookDiary.ViewModels
{
    public class UpdateUserViewModel
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Info { get; set; }
        public int Id { get; set; }
        public UpdateUserViewModel(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Avatar = user.Avatar;
            Info = user.Info;
        }
        public ICommand open_LoadImage => new DelegateCommand(Open_LoadImage);
        private void Open_LoadImage()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image file (*.png;*jpg)|*png;*.jpg";
            if (openFile.ShowDialog() == true)
            {
                string selFileName = openFile.FileName;
                Avatar = selFileName;
            }
        }
        public ICommand update => new DelegateCommand(Update);
        private void Update()
        {
            IServiceCallback callBack = new VDMyServiceCallBack();
            InstanceContext context = new InstanceContext(callBack);
            ServiceClient client = new ServiceClient(context);

            client.UpdateUser(Id, Name, Info, Avatar);
            //CurrentClient.service.UpdateUser(Id, Name, Info, Avatar);


        }
    }
}
