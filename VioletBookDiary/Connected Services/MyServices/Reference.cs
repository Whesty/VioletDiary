﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VioletBookDiary.MyServices {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MyServices.IService", CallbackContract=typeof(VioletBookDiary.MyServices.IServiceCallback))]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Registration", ReplyAction="http://tempuri.org/IService/RegistrationResponse")]
        string Registration(string mail, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Registration", ReplyAction="http://tempuri.org/IService/RegistrationResponse")]
        System.Threading.Tasks.Task<string> RegistrationAsync(string mail, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Login", ReplyAction="http://tempuri.org/IService/LoginResponse")]
        System.Collections.Generic.Dictionary<string, string> Login(string mail, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Login", ReplyAction="http://tempuri.org/IService/LoginResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, string>> LoginAsync(string mail, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/getAuthors", ReplyAction="http://tempuri.org/IService/getAuthorsResponse")]
        System.Collections.Generic.Dictionary<string, string>[] getAuthors();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/getAuthors", ReplyAction="http://tempuri.org/IService/getAuthorsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, string>[]> getAuthorsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/getGenrs", ReplyAction="http://tempuri.org/IService/getGenrsResponse")]
        System.Collections.Generic.Dictionary<string, string>[] getGenrs();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/getGenrs", ReplyAction="http://tempuri.org/IService/getGenrsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, string>[]> getGenrsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/getTags", ReplyAction="http://tempuri.org/IService/getTagsResponse")]
        System.Collections.Generic.Dictionary<string, string>[] getTags();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/getTags", ReplyAction="http://tempuri.org/IService/getTagsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, string>[]> getTagsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/getAuthorsBook", ReplyAction="http://tempuri.org/IService/getAuthorsBookResponse")]
        System.Collections.Generic.Dictionary<string, string>[] getAuthorsBook(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/getAuthorsBook", ReplyAction="http://tempuri.org/IService/getAuthorsBookResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, string>[]> getAuthorsBookAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/getTagsBook", ReplyAction="http://tempuri.org/IService/getTagsBookResponse")]
        System.Collections.Generic.Dictionary<string, string>[] getTagsBook(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/getTagsBook", ReplyAction="http://tempuri.org/IService/getTagsBookResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, string>[]> getTagsBookAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/getGenresBook", ReplyAction="http://tempuri.org/IService/getGenresBookResponse")]
        System.Collections.Generic.Dictionary<string, string>[] getGenresBook(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/getGenresBook", ReplyAction="http://tempuri.org/IService/getGenresBookResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, string>[]> getGenresBookAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/getFeedBackBook", ReplyAction="http://tempuri.org/IService/getFeedBackBookResponse")]
        System.Collections.Generic.Dictionary<string, string>[] getFeedBackBook(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/getFeedBackBook", ReplyAction="http://tempuri.org/IService/getFeedBackBookResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, string>[]> getFeedBackBookAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/getPaintBook", ReplyAction="http://tempuri.org/IService/getPaintBookResponse")]
        System.Collections.Generic.Dictionary<string, string>[] getPaintBook(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/getPaintBook", ReplyAction="http://tempuri.org/IService/getPaintBookResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, string>[]> getPaintBookAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/getBooks", ReplyAction="http://tempuri.org/IService/getBooksResponse")]
        System.Collections.Generic.Dictionary<string, string>[] getBooks();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/getBooks", ReplyAction="http://tempuri.org/IService/getBooksResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, string>[]> getBooksAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/UpdateUser")]
        void UpdateUser(int id, string name, string info, string avatar);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/UpdateUser")]
        System.Threading.Tasks.Task UpdateUserAsync(int id, string name, string info, string avatar);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Disconnect", ReplyAction="http://tempuri.org/IService/DisconnectResponse")]
        void Disconnect(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Disconnect", ReplyAction="http://tempuri.org/IService/DisconnectResponse")]
        System.Threading.Tasks.Task DisconnectAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddBook", ReplyAction="http://tempuri.org/IService/AddBookResponse")]
        string AddBook(string name, string author, string genre, string tag, string description, string image, string file, string Serialize, string Realese, int idUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddBook", ReplyAction="http://tempuri.org/IService/AddBookResponse")]
        System.Threading.Tasks.Task<string> AddBookAsync(string name, string author, string genre, string tag, string description, string image, string file, string Serialize, string Realese, int idUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddFeedBack", ReplyAction="http://tempuri.org/IService/AddFeedBackResponse")]
        string AddFeedBack(int idBook, string text, int idUser, string pating);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddFeedBack", ReplyAction="http://tempuri.org/IService/AddFeedBackResponse")]
        System.Threading.Tasks.Task<string> AddFeedBackAsync(int idBook, string text, int idUser, string pating);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddPaint", ReplyAction="http://tempuri.org/IService/AddPaintResponse")]
        string AddPaint(int idBook, int idUser, string rating);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddPaint", ReplyAction="http://tempuri.org/IService/AddPaintResponse")]
        System.Threading.Tasks.Task<string> AddPaintAsync(int idBook, int idUser, string rating);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/OnCallback")]
        void OnCallback(string message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdateUserCallBack", ReplyAction="http://tempuri.org/IService/UpdateUserCallBackResponse")]
        void UpdateUserCallBack(System.Collections.Generic.Dictionary<string, string> result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : VioletBookDiary.MyServices.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.DuplexClientBase<VioletBookDiary.MyServices.IService>, VioletBookDiary.MyServices.IService {
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public string Registration(string mail, string password) {
            return base.Channel.Registration(mail, password);
        }
        
        public System.Threading.Tasks.Task<string> RegistrationAsync(string mail, string password) {
            return base.Channel.RegistrationAsync(mail, password);
        }
        
        public System.Collections.Generic.Dictionary<string, string> Login(string mail, string password) {
            return base.Channel.Login(mail, password);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, string>> LoginAsync(string mail, string password) {
            return base.Channel.LoginAsync(mail, password);
        }
        
        public System.Collections.Generic.Dictionary<string, string>[] getAuthors() {
            return base.Channel.getAuthors();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, string>[]> getAuthorsAsync() {
            return base.Channel.getAuthorsAsync();
        }
        
        public System.Collections.Generic.Dictionary<string, string>[] getGenrs() {
            return base.Channel.getGenrs();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, string>[]> getGenrsAsync() {
            return base.Channel.getGenrsAsync();
        }
        
        public System.Collections.Generic.Dictionary<string, string>[] getTags() {
            return base.Channel.getTags();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, string>[]> getTagsAsync() {
            return base.Channel.getTagsAsync();
        }
        
        public System.Collections.Generic.Dictionary<string, string>[] getAuthorsBook(int id) {
            return base.Channel.getAuthorsBook(id);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, string>[]> getAuthorsBookAsync(int id) {
            return base.Channel.getAuthorsBookAsync(id);
        }
        
        public System.Collections.Generic.Dictionary<string, string>[] getTagsBook(int id) {
            return base.Channel.getTagsBook(id);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, string>[]> getTagsBookAsync(int id) {
            return base.Channel.getTagsBookAsync(id);
        }
        
        public System.Collections.Generic.Dictionary<string, string>[] getGenresBook(int id) {
            return base.Channel.getGenresBook(id);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, string>[]> getGenresBookAsync(int id) {
            return base.Channel.getGenresBookAsync(id);
        }
        
        public System.Collections.Generic.Dictionary<string, string>[] getFeedBackBook(int id) {
            return base.Channel.getFeedBackBook(id);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, string>[]> getFeedBackBookAsync(int id) {
            return base.Channel.getFeedBackBookAsync(id);
        }
        
        public System.Collections.Generic.Dictionary<string, string>[] getPaintBook(int id) {
            return base.Channel.getPaintBook(id);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, string>[]> getPaintBookAsync(int id) {
            return base.Channel.getPaintBookAsync(id);
        }
        
        public System.Collections.Generic.Dictionary<string, string>[] getBooks() {
            return base.Channel.getBooks();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, string>[]> getBooksAsync() {
            return base.Channel.getBooksAsync();
        }
        
        public void UpdateUser(int id, string name, string info, string avatar) {
            base.Channel.UpdateUser(id, name, info, avatar);
        }
        
        public System.Threading.Tasks.Task UpdateUserAsync(int id, string name, string info, string avatar) {
            return base.Channel.UpdateUserAsync(id, name, info, avatar);
        }
        
        public void Disconnect(int id) {
            base.Channel.Disconnect(id);
        }
        
        public System.Threading.Tasks.Task DisconnectAsync(int id) {
            return base.Channel.DisconnectAsync(id);
        }
        
        public string AddBook(string name, string author, string genre, string tag, string description, string image, string file, string Serialize, string Realese, int idUser) {
            return base.Channel.AddBook(name, author, genre, tag, description, image, file, Serialize, Realese, idUser);
        }
        
        public System.Threading.Tasks.Task<string> AddBookAsync(string name, string author, string genre, string tag, string description, string image, string file, string Serialize, string Realese, int idUser) {
            return base.Channel.AddBookAsync(name, author, genre, tag, description, image, file, Serialize, Realese, idUser);
        }
        
        public string AddFeedBack(int idBook, string text, int idUser, string pating) {
            return base.Channel.AddFeedBack(idBook, text, idUser, pating);
        }
        
        public System.Threading.Tasks.Task<string> AddFeedBackAsync(int idBook, string text, int idUser, string pating) {
            return base.Channel.AddFeedBackAsync(idBook, text, idUser, pating);
        }
        
        public string AddPaint(int idBook, int idUser, string rating) {
            return base.Channel.AddPaint(idBook, idUser, rating);
        }
        
        public System.Threading.Tasks.Task<string> AddPaintAsync(int idBook, int idUser, string rating) {
            return base.Channel.AddPaintAsync(idBook, idUser, rating);
        }
    }
}
