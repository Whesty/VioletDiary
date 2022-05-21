using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VioletBookDiary.Models;
using VioletBookDiary.Views;

namespace VioletBookDiary.ViewModels
{
    public class ListPaintViewModel
    {
        public List<Paint> ListPaint { get; set; }
        public ListPaintViewModel()
        {
            ListPaint = new List<Paint>();
            GetListPaint();
        }
        #region Function Service
        public void GetListPaint()
        {
            ListPaint = new List<Paint>();
            foreach (Dictionary<string, string> items in CurrentClient.service.getPaints())
            {
                ListPaint.Add(new Paint()
                {
                    Id = int.Parse(items["id"]),
                    link = items["link"],
                    Id_Book = int.Parse(items["idBook"]),
                    Data = DateTime.Parse(items["dataAdd"]),
                    Id_User_Add = int.Parse(items["userAdd"]),
                });
            }
        }
        #endregion
        public void ClickPaint(Paint paint)
        {
            //CurentWindows.mainPage.vm = new PageViewBook(idBook);
        }
    }
}
