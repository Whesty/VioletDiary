using NPOI.SS.Formula.Functions;
using System.Collections.Generic;
using System.Windows.Controls;
using VioletBookDiary.ViewModels;
using VioletBookDiary.Views;
using VioletBookDiary.Views.BookView;
using VioletBookDiary.Views.Resources;

namespace VioletBookDiary
{
    public static class CurentWindows
    {
        public static Logon logon;
        public static MainWindow mainWindow;
        public static MainPage mainPage;
        public static UserInfo userInfo;
        public static UserUpdate userUpdate;
        public static AddBook addBook;
        public static FeedBackBook feedBackBook;
        public static PaintBook paintBook;
        public static ListPaintView listPaint;
        public static PageViewBook pageViewBook;
        public static ListViewsBooks listViewsBooks;
        public static ReedBook reedBook;
        public static Catalog catalog;
        public static AdminListBook adminListBook;
        public static Setting setting;
        public static string Thems;
        //public static List<Page> History = new List<Page>();
        public static Page CurrentPage { get; set; }
        public static void Add(Page page)
        {
                mainWindow.model.CurrentPage = page;
            
        }
    }
}
