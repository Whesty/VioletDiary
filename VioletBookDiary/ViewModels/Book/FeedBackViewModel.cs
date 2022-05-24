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
    public class FeedBackViewModel: ViewModelBase
    {
        public string CurrentUserName { get=> CurrentUser._User.Name; set { } }
        private float userStar { get; set; }
        public float CurrentUserStar { get => userStar; set {
                userStar = value;
                OnPropertyChanged("CurrentUserStar");
         
         } }
        private string userComment { get; set; }
        public string CurrentUserComment { get => userComment; set {
                userComment = value;
                OnPropertyChanged("CurrentUserComment");
            }
        }
   
        public string CurrentUserAvatar { get => CurrentUser._User.Avatar; set { } }
        private List<Feedback> feedbacks;
        public List<Feedback> Feedbacks { get => feedbacks; set {
                feedbacks = value;
                OnPropertyChanged("Feedbacks");
            }
        }
    
        public int IdBook;
        public FeedBackBook win;
        private float rating;
        public float Rating { get => rating; set {
                rating = value;
                OnPropertyChanged("rating");
            } }


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
            Feedbacks = new List<Feedback>();
            foreach (Dictionary<string, string> item in CurrentClient.service.getFeedBackBook(IdBook)) {
                Feedback feedback = new Feedback();
                feedback.Id = int.Parse(item["id"]);
                feedback.UserName = item["username"];
                feedback.feedback = item["text"];
                feedback.Id_user = int.Parse(item["userId"]);
                feedback.DateCreat = DateTime.Parse(item["date"]);
                feedback.Pating = float.Parse(item["pating"]);
                feedback.UserAvatar = item["useravatar"];
                Feedbacks.Add(feedback);
            }
            if (Feedbacks.Count > 0)
            {
                Rating = Feedbacks.Average(x => x.Pating);
                Rating = (float)Math.Round(Rating, 1);
                Feedbacks = Feedbacks.OrderByDescending(x => x.DateCreat).ToList();
            }
        }
        #endregion
        #region Commands
        public ICommand addFeedBack => new DelegateCommand(AddFeedback);
        private void AddFeedback()
        {
            try
            {
                if(CurrentUserComment == null)
                {
                    MessengViewModel.Show("Ошибка", "Не все поля заполнены");
                    return;
                }
                if(CurrentUserStar > 10)
                {
                    MessengViewModel.Show("Ошибка", "Оценка неверного формата");
                    return;
                }
                string result = CurrentClient.service.AddFeedBack(IdBook, CurrentUserComment, CurrentUser._User.Id, CurrentUserStar.ToString());
                if (result == "Отправлен!")
                {
                    CurrentUserComment = "";
                    CurrentUserStar = 0;
                    GetFeedbacks();
                }
            }catch(Exception ex)
            {
                MessengViewModel.Show("Ошибка", ex.Message);
            }
        }
        #endregion
    }
}
