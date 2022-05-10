using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VioletBookDiary.MyServices;
using VioletBookDiary.ViewModels;

namespace VioletBookDiary
{
    public static class CurrentClient
    {
        public readonly static VDMyServiceCallBack callBack = new VDMyServiceCallBack();
        public readonly static ServiceClient service = new ServiceClient(new System.ServiceModel.InstanceContext(callBack));
        public static void SetUserInfo(UserInfoViewModel userInfoVM)
        {
            callBack.userinfoVM = userInfoVM;
        }
    }
}
