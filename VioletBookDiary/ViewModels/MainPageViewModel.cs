using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VioletBookDiary.Commands;
using VioletBookDiary.Views;
using VioletBookDiary.Views.BookView;

namespace VioletBookDiary.ViewModels
{
    public class MainPageViewModel
    {
        public MainWindow mainWindow;
        public MainPageViewModel()
        {
            

            listViewsBooks = new ListViewsBooks();
            listPaintView = new ListPaintView();
            CurentWindows.mainPage.ViewsListData.Children.Add(listViewsBooks);
            CurentWindows.mainPage.Button_ListBook.IsEnabled = false;
        }
        private ListViewsBooks listViewsBooks;
        private ListPaintView listPaintView;

        public ICommand open_PaintList => new DelegateCommand(Open_PaintList);
        private void Open_PaintList()
        {
            CurentWindows.mainPage.ViewsListData.Children.Clear();
            CurentWindows.mainPage.ViewsListData.Children.Add(listPaintView);
            CurentWindows.mainPage.Button_ListBook.IsEnabled = true;
            CurentWindows.mainPage.Button_ListImage.IsEnabled = false;
            CurentWindows.mainPage.Filters.IsEnabled = false;
        }
        public ICommand open_BookList => new DelegateCommand(Open_BookList);
        private void Open_BookList()
        {
            CurentWindows.mainPage.ViewsListData.Children.Clear();
            CurentWindows.mainPage.ViewsListData.Children.Add(listViewsBooks);
            CurentWindows.mainPage.Button_ListBook.IsEnabled = false;
            CurentWindows.mainPage.Button_ListImage.IsEnabled = true;
            CurentWindows.mainPage.Filters.IsEnabled = true;

        }
    }
}
