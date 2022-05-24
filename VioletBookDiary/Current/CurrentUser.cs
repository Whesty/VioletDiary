using VioletBookDiary.Models;

namespace VioletBookDiary
{
    public class CurrentUser
    {
        public readonly static User _User = new User();

        public static void SetUser(User user)
        {
            _User.Id = user.Id;
            _User.Name = user.Name;
            _User.AccessLevel = user.AccessLevel;
            _User.Email = user.Email;
            _User.Avatar = user.Avatar;
            _User.Info = user.Info;
        }

    }
}
