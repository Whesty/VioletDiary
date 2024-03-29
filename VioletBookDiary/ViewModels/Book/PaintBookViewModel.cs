﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VioletBookDiary.Commands;
using VioletBookDiary.Models;
using VioletBookDiary.Views.BookView;

namespace VioletBookDiary.ViewModels
{
    public class PaintBookViewModel : ViewModelBase
    {
        private List<Paint> paints { get; set; }
        public List<Paint> ListPaint { get => paints; set 
            {
                paints = value;
                OnPropertyChanged("ListPaint");
            } }
        private string link;
        public int Count { get; set; }
        public string Link
        {
            get { return link; }
            set
            {
                this.link = value;
                OnPropertyChanged(nameof(Link));
            }
        }
        int IdBook;
        public PaintBookViewModel(int idBook)
        {
            ListPaint = new List<Paint>();
            IdBook = idBook;
            GetListPaint();
        }
        #region Function Service
        public void GetListPaint()
        {
            ListPaint = new List<Paint>();
            foreach (Dictionary<string, string> items in CurrentClient.service.getPaintBook(IdBook))
            {
                ListPaint.Add(new Paint()
                {
                    Id = int.Parse(items["id"]),
                    link = items["link"],
                    Id_Book = IdBook,
                    Data = DateTime.Parse(items["dataAdd"]),
                    Id_User_Add = int.Parse(items["userAdd"]),
                });
            }
            Count = ListPaint.Count;
            ListPaint = ListPaint.OrderByDescending(x => x.Data).ToList();
        }
        #endregion
        #region Command
        public ICommand open_LoadImage => new DelegateCommand(Open_LoadImage);
        private void Open_LoadImage()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image file (*.png;*jpg)|*png;*.jpg";
            if (openFile.ShowDialog() == true)
            {
                string selFileName = openFile.FileName;
                Link = selFileName;
            }
        }
        public ICommand add_Paint => new DelegateCommand(Add_Paint);
        private void Add_Paint()
        {
            if (Link != null)
            {
                string result = CurrentClient.service.AddPaint(IdBook, CurrentUser._User.Id, Link);
                if (result == "Загружен!")
                {
                    GetListPaint();
                     MessengViewModel.Show("Загружено!", "Успешно");
                    CurentWindows.pageViewBook.model.Open_Paint();
                }
                else  MessengViewModel.Show("Ошибка!", result);
            }
        }

            #endregion
    }
}
