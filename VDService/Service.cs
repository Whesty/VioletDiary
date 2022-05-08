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
                            ConnectAdmins.Add(new ServerUser { Id = user.Id, OperationContext = OperationContext.Current });
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
                        //Скорее всего остальные свойства клиента
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
                    str += "\nРегистрация прошла успешно!" + userAuth.Id;
                    unitOfWork.UserAuthRepository.Add(userAuth);
                    str += "\nAdd";
                    USER user = new USER()
                    {
                        USER_NAME = "User",
                        USER_INFO = "Info",
                        USER_AVATAR = null,
                        ID_AUTHORIZED = userAuth.Id
                    };
                    str += "\nCreateUser";
                    unitOfWork.UserRepository.Add(user);
                    str += "\nAddUser!";
                    try
                    {
                        unitOfWork.Save();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                        {
                            str += "\nObject: " + validationError.Entry.Entity.ToString();
                            foreach (DbValidationError error in validationError.ValidationErrors)
                            {
                                str += "\n" + error.ErrorMessage;
                            }
                        }
                    }
                        return "Accept registre!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message+ ex.InnerException.InnerException.InnerException.InnerException.Message.ToString() + "\n" + str;
            }
        }
    }
}
