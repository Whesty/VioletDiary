using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VioletBookDiary.Models;

namespace VioletBookDiary.ViewModels
{
    public class FeedBackViewModel
    {
        public string CurrentUserName { get=> CurrentUser._User.Name; set { } }
        public string CurrentUserStar { get; set; }
        public string CurrentUserComment { get; set; }
        public string CurrentUserAvatar { get => CurrentUser._User.Avatar; set { } }
        public ObservableCollection<Feedback> Feedbacks { get; set; }

        public FeedBackViewModel(int idbook)
        {
            Feedbacks = new ObservableCollection<Feedback>();

        }

        #region Function Service
        public ObservableCollection<Feedback> GetFeedbacks()
        {
            //Обратиться к серверу и поулчить список отзывов по id book
            return null;
        }
        #endregion
        #region Commands
        #endregion
    }
}
