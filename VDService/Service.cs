using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using VDService.Unit;

namespace VDService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service" в коде и файле конфигурации.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        private List<ServerUser> ConnectUsers = new List<ServerUser>();
        private List<ServerUser> ConnectAdmins = new List<ServerUser>();
        
        public void Disconnect(int id)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                USERS user = unit.UserRepository.GetAll().Where(x => x.ID_USER == id).FirstOrDefault();
                if (user != null)
                {
                    if (user.ACCESS_LEVEL == false)
                    {
                        ConnectAdmins.Remove(ConnectUsers.Where(x => x.Id == id).FirstOrDefault());
                        //Сообщаем всем админам об отключении пользователя
                    }
                }
                else
                {
                    ConnectUsers.Remove(ConnectAdmins.Where(x => x.Id == id).FirstOrDefault());
                }
            }
        }

        public Dictionary<string, string> Login(string mail, string password)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                int userAuthid = unit.UserAuthRepository.GetAll().Where(x => x.USER_EMAIL == mail && x.PASSWORD == password).FirstOrDefault().ID_AUTHORIZED;
                USERS user = unit.UserRepository.GetAll().Where(x => x.ID_AUTHORIZED == userAuthid).FirstOrDefault();
                if (user != null)
                {
                    if (user.ACCESS_LEVEL == true)
                    {
                        ConnectAdmins.Add(new ServerUser { Id = user.ID_USER, OperationContext = OperationContext.Current });
                    }
                    else
                    {
                        //Сообщаем о подключении клиента
                        //foreach (var item in ConnectAdmins)
                        //{
                        //    //item.OperationContext.GetCallbackChannel<IMyServiceCallback>().AdminUpdate();
                        //}
                        ConnectUsers.Add(new ServerUser { 
                            Id = user.ID_USER, OperationContext = OperationContext.Current
                        });
                    }
                    Dictionary<string, string> result = new Dictionary<string, string>();
                    result.Add("id", user.ID_USER.ToString());
                    result.Add("name", user.USER_NAME);
                    result.Add("AccessLevel", user.ACCESS_LEVEL.ToString());
                    //Скорее всего остальные свойства клиента
                    return result;

                }
                else
                {
                    return null;
                }
            }
        }

        public string Registration(string mail, string password)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    AUTHORIZED userAuth = new AUTHORIZED() { USER_EMAIL = mail, PASSWORD = password };
                    unitOfWork.UserAuthRepository.Add(userAuth);
                    USERS user = new USERS()
                    {
                        USER_NAME = "",
                        USER_INFO = "",
                        USER_AVATAR = "",
                        ID_AUTHORIZED = userAuth.ID_AUTHORIZED
                    };
                    unitOfWork.UserRepository.Add(user);
                    unitOfWork.Save();
                    return "Accept registre!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
