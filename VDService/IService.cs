using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace VDService
{
    // ПРИМЕЧАНИЕ. Можно использовать команду "Переименовать" в меню "Рефакторинг", чтобы изменить имя интерфейса "IService" в коде и файле конфигурации.
    [ServiceContract(CallbackContract = typeof(IMyServiceCallback))]
    public interface IService
    {
        [OperationContract]
        string Registration(string mail, string password);
        [OperationContract]
        Dictionary<string, string> Login(string mail, string password);
        [OperationContract(IsOneWay = true)]
        void UpdateUser(int id, string name, string info, string avatar);
        [OperationContract]
        void Disconnect(int id);
        [OperationContract]
        string AddBook(string name, string author, string genre, string description, string image);
        
        
    }
    
    public interface IMyServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnCallback(string message);
        [OperationContract]
        void UpdateUserCallBack(Dictionary<string, string> result);
    }
}
