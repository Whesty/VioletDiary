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
    public class UpdateUserViewModel: ViewModelBase
    {
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
        public string Avatar
        {
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
        public string Info
        {
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

        public UpdateUserViewModel(User user)
        {
            Id = user.Id;
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
