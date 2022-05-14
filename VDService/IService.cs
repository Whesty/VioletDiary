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
        [OperationContract]
        List<Dictionary<string, string>> getAuthors();
        [OperationContract]
        List<Dictionary<string, string>> getGenrs();
        [OperationContract]
        List<Dictionary<string, string>> getTags(); 
        [OperationContract]
        List<Dictionary<string, string>> getPaints();
        [OperationContract]
        List<Dictionary<string, string>> getAuthorsBook(int id);
        [OperationContract]
        List<Dictionary<string, string>> getTagsBook(int id);
        [OperationContract]
        List<Dictionary<string, string>> getGenresBook(int id); 
        [OperationContract]
        Dictionary<string, string> getUserInfo(int id);
        
        [OperationContract]
        List<Dictionary<string, string>> getFeedBackBook(int id);
        
        
        [OperationContract]
        List<Dictionary<string, string>> getPaintBook(int id);
        [OperationContract]
        Dictionary<string, string> getBookMarks(int idBook, int IdUser);
        [OperationContract]
        bool addBookMarks(int idBook, int IdUser, int mark, string status, bool presence);
        [OperationContract]
        bool editBookMarks(int idBook, int IdUser, int mark, string status, bool presence);

        [OperationContract]
        List<Dictionary<string, string>> getBooks();
        [OperationContract]
        void DeleteBooks(int idBook);
        [OperationContract(IsOneWay = true)]
        void UpdateUser(int id, string name, string info, string avatar);
        [OperationContract]
        void Disconnect(int id);
        [OperationContract] 
        void ClearDataBase();
        [OperationContract]
        string AddBook(string name, string author, string genre, string tag, string description, string image, string file, string Serialize, string Realese, int idUser);
        [OperationContract]
        string EditBook(int id, string name, string description, string image, string file, string Serialize, string Realese, int idUser, bool bookstatus);
        [OperationContract]
        string AddFeedBack(int idBook, string text, int idUser, string pating);
        [OperationContract]
        string AddPaint(int idBook, int idUser, string rating);

    }
    
    public interface IMyServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnCallback(string message);
        [OperationContract]
        void UpdateUserCallBack(Dictionary<string, string> result);
    }
}
