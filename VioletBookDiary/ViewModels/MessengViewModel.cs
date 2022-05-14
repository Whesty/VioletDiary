using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VioletBookDiary.Views;

namespace VioletBookDiary.ViewModels
{
    static class MessengViewModel
    {
        
        public static void Show(string title, string info)
        {
            MessengeView messeng = new MessengeView(title, info);
            messeng.Show();
        }
        public static void Show(string info)
        {
            MessengeView messeng = new MessengeView(info);
            messeng.Show();
        }
    }
}
