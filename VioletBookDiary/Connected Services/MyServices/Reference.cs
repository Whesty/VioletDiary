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
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/UpdateUser")]
        void UpdateUser(int id, string name, string info, string avatar);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/UpdateUser")]
        System.Threading.Tasks.Task UpdateUserAsync(int id, string name, string info, string avatar);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Disconnect", ReplyAction="http://tempuri.org/IService/DisconnectResponse")]
        void Disconnect(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Disconnect", ReplyAction="http://tempuri.org/IService/DisconnectResponse")]
        System.Threading.Tasks.Task DisconnectAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddBook", ReplyAction="http://tempuri.org/IService/AddBookResponse")]
        string AddBook(string name, string author, string genre, string description, string image);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddBook", ReplyAction="http://tempuri.org/IService/AddBookResponse")]
        System.Threading.Tasks.Task<string> AddBookAsync(string name, string author, string genre, string description, string image);
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
        
        public string AddBook(string name, string author, string genre, string description, string image) {
            return base.Channel.AddBook(name, author, genre, description, image);
        }
        
        public System.Threading.Tasks.Task<string> AddBookAsync(string name, string author, string genre, string description, string image) {
            return base.Channel.AddBookAsync(name, author, genre, description, image);
        }
    }
}
