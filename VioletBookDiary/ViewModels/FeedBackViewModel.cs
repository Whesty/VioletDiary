using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VioletBookDiary.Commands;
using VioletBookDiary.Models;
using VioletBookDiary.Views.BookView;

namespace VioletBookDiary.ViewModels
{
    public class FeedBackViewModel
    {
        public string CurrentUserName { get=> CurrentUser._User.Name; set { } }
        public string CurrentUserStar { get; set; }
        public string CurrentUserComment { get; set; }
        public string CurrentUserAvatar { get => CurrentUser._User.Avatar; set { } }
        public List<Feedback> Feedbacks { get; set; }
        public int IdBook;
        public FeedBackBook win;
        public float Rating { get; set; }


        public FeedBackViewModel(int idbook)
        {
            Feedbacks = new List<Feedback>();
            IdBook = idbook;
            GetFeedbacks();
        }
        
        #region Function Service
        public void GetFeedbacks()
        {
            //Обратиться к серверу и поулчить список отзывов по id book
            foreach (Dictionary<string, string> item in CurrentClient.service.getFeedBackBook(IdBook)) {
                Feedback feedback = new Feedback();
                feedback.Id = int.Parse(item["id"]);
                feedback.UserName = item["username"];
                feedback.feedback = item["text"];
                feedback.DateCreat = DateTime.Parse(item["date"]);
                feedback.Pating = float.Parse(item["pating"]);
                feedback.UserAvatar = item["useravatar"];
                Feedbacks.Add(feedback);
            }
            if (Feedbacks.Count > 0)
            {
                Rating = Feedbacks.Average(x => x.Pating);
            }
        }
        #endregion
        #region Commands
        public ICommand addFeedBack => new DelegateCommand(AddFeedback);
        private void AddFeedback()
        {
            string result = CurrentClient.service.AddFeedBack(IdBook, CurrentUserComment, CurrentUser._User.Id, CurrentUserStar );
            if (result == "Отправлен!")
            {
                GetFeedbacks();
                CurrentUserComment = "";
                CurrentUserStar = "";
            }
        }
        #endregion
    }
}
