using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using VioletBookDiary.MyServices;

namespace VioletBookDiary
{
    public class VDMyServiceCallBack : IServiceCallback
    {
        public VDMyServiceCallBack()
        {
        }

        public void OnCallback(string message)
        {
           
        }
    }
}
