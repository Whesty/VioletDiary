using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
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
        private ServerUser serverUser;
        public string AddBook(string name, string author, string genre, string description, string image)
        {
            throw new NotImplementedException();
        }

        public void Disconnect(int id)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                USER user = unit.UserRepository.GetAll().Where(x => x.Id == id).FirstOrDefault();
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
                
                AUTHORIZED userAuth = unit.UserAuthRepository.GetAll().Where(x => x.USER_EMAIL == mail && x.PASSWORD == password).FirstOrDefault();
                if (userAuth != null)
                {
                    int userAuthid = userAuth.Id;
                    USER user = unit.UserRepository.GetAll().Where(x => x.ID_AUTHORIZED == userAuthid).FirstOrDefault();

                    if (user != null)
                    {
                        if (user.ACCESS_LEVEL == true)
                        {
                            serverUser = new ServerUser { Id = user.Id, OperationContext = OperationContext.Current };
                            ConnectAdmins.Add(serverUser);
                        }
                        else
                        {
                            //Сообщаем о подключении клиента
                            //foreach (var item in ConnectAdmins)
                            //{
                            //    //item.OperationContext.GetCallbackChannel<IMyServiceCallback>().AdminUpdate();
                            //}
                            ConnectUsers.Add(new ServerUser
                            {
                                Id = user.Id,
                                OperationContext = OperationContext.Current
                            });
                        }
                        Dictionary<string, string> result = new Dictionary<string, string>();
                        result.Add("id", user.Id.ToString());
                        result.Add("name", user.USER_NAME);
                        result.Add("AccessLevel", user.ACCESS_LEVEL.ToString());
                        result.Add("avatar", user.USER_AVATAR);
                        result.Add("data_create", user.DATA_CREATE.ToString());
                        result.Add("id_authorized", user.ID_AUTHORIZED.ToString());
                        result.Add("info", user.USER_INFO);
                        return result;

                    }
                    else
                    {
                        return null;
                    }
                }
                return null;
            }
        }

        public string Registration(string mail, string password)
        {
            string str = "";
            try
            {
                str += "Start";
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    str += "\ncreate UnitofWork";
                    AUTHORIZED userAuth = new AUTHORIZED() { USER_EMAIL = mail, PASSWORD = password };
                    str += "\nРегистрация прошла успешно!";
                    unitOfWork.UserAuthRepository.Add(userAuth);
                    unitOfWork.Save();
                    AUTHORIZED Auth = unitOfWork.UserAuthRepository.GetAll().Where(x => x.USER_EMAIL == mail && x.PASSWORD == password).FirstOrDefault();
                    int id = Auth.Id;
                    str += "\nAdd " + id;
                    USER user = new USER()
                    {
                        USER_NAME = "User",
                        USER_INFO = "Info",
                        USER_AVATAR = null,
                        ACCESS_LEVEL = false,
                        DATA_CREATE = DateTime.Now,
                        ID_AUTHORIZED = id,
                        AUTHORIZED = Auth,
                    };
                    str += "\nCreateUser";
                    unitOfWork.UserRepository.Add(user);
                    str += "\nAddUser!";
                        unitOfWork.Save();
                        return "Accept registre!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message + "\n" + str;
            }
        }

        public void UpdateUser(int id, string name, string info, string avatar)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {


              
                USER user = unit.UserRepository.GetAll().Where(x => x.Id == id).FirstOrDefault();
                user.USER_NAME = name;
                user.USER_INFO = info;
                user.USER_AVATAR = avatar;
                unit.Save();
                Dictionary<string, string> result = new Dictionary<string, string>();
                result.Add("id", user.Id.ToString());
                result.Add("name", user.USER_NAME);
                result.Add("AccessLevel", user.ACCESS_LEVEL.ToString());
                result.Add("avatar", user.USER_AVATAR);
                result.Add("data_create", user.DATA_CREATE.ToString());
                result.Add("id_authorized", user.ID_AUTHORIZED.ToString());
                result.Add("info", user.USER_INFO);
                IMyServiceCallback callback = serverUser.OperationContext.GetCallbackChannel<IMyServiceCallback>();
                
                callback.UpdateUserCallBack(result);   
            }
        }
    }
}
