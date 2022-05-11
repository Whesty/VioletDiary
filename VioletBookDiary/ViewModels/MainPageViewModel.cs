using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VioletBookDiary.Views;

namespace VioletBookDiary.ViewModels
{
    public class MainPageViewModel
    {
        public MainPage win;
        public MainWindow mainWindow;
        public MainPageViewModel(MainPage win)
        {
            this.win = win;
        }
    }
}
