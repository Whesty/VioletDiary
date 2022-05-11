using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Text.RegularExpressions;
using VDService.Unit;
using VDService.Model;

namespace VDService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service" в коде и файле конфигурации.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        private List<ServerUser> ConnectUsers = new List<ServerUser>();
        private List<ServerUser> ConnectAdmins = new List<ServerUser>();
        private ServerUser serverUser;
        public string AddBook(string name, string author, string genre, string tag, string description, string image, string file, string Serialize, string Realese, int idUser)
        {
            string str = "";
            try
            {
                str += "Start";
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    str += "\ncreate UnitofWork";
                    Regex regex = new Regex(@"(\w*);");
                    MatchCollection math = regex.Matches(author);
                    str += "\ncreate BOOK 1";
                    BOOK book = new BOOK()
                    {
                        BOOK_NAME = name,
                        BOOK_DESCRIPTION = description,
                        BOOK_IMAGE = image,
                        BOOK_FILE = file,
                        DATA_RELEASE = int.Parse(Realese),
                        ID_USER_ADD = idUser,
                        BOOK_SERIES = Serialize,
                        BOOK_STATUS = false

                    };
                    str += "\ncreate BOOK 2";

                    unitOfWork.BooksRepository.Add(book);
                    str += "\nAdd BOOK";

                    unitOfWork.Save();
                    str += "\nSave";

                    book = unitOfWork.BooksRepository.GetAll().Where(x => x.BOOK_NAME == name).FirstOrDefault();
                    str += "\nget BOOK";
                    foreach (Match match in math)
                    {
                        //"\n" + match.Value;
                        str += "\nmath avtors" + match.Value;

                        AUTHOR author1 = unitOfWork.AuthorsRepository.GetAll().Where(a => a.AUTHOR_NAME == match.Value).FirstOrDefault();
                        str += "\nget av";

                        if (author1 == null)
                        {
                            author1 = new AUTHOR()
                            {
                                AUTHOR_NAME = match.Value,
                                COUNTRY = null
                            };
                            str += "\nadd av";
                            unitOfWork.AuthorsRepository.Add(author1);
                            unitOfWork.Save();
                            str += "\nSave";

                            //unitOfWork.
                        }
                        AUTHOR author2 = unitOfWork.AuthorsRepository.GetAll().Where(a => a.AUTHOR_NAME == match.Value).FirstOrDefault();
                        str += "\nCreate av2";
                        unitOfWork.BookAuthorsRepository.Add(new BOOK_AUTHOR()
                        {
                            BOOKId = book.Id,
                            AUTHORId = author2.Id

                        });
                        unitOfWork.Save();
                        str += "\nSave";
                    }
                    MatchCollection match1 = regex.Matches(tag);
                    str += "\nMatch";
                    foreach (Match match in match1)
                    {
                        //"\n" + match.Value;
                        TAG tag1 = unitOfWork.TagsRepository.GetAll().Where(a => a.TAG_NAME == match.Value).FirstOrDefault();
                        str += "\nCreat tag1";
                        if (tag1 == null)
                        {
                            tag1 = new TAG()
                            {
                                TAG_NAME = match.Value
                            };
                            str += "\nCreate tag1+";
                            unitOfWork.TagsRepository.Add(tag1);
                            str += "\nAdd tag2";
                            unitOfWork.Save();
                            str += "\nSave";
                        }
                        TAG tag2 = unitOfWork.TagsRepository.GetAll().Where(a => a.TAG_NAME == match.Value).FirstOrDefault();
                        str += "\nCreate tag2";
                        unitOfWork.BookTagsRepository.Add(new BOOK_TAG()
                        {
                            BOOKId = book.Id,
                            TAGId = tag2.TAGId
                        });
                        str += "\ntag2+";
                        unitOfWork.Save();
                        str += "\nSave";
                    }
                    GENRE genre1 = unitOfWork.GenresRepository.GetAll().Where(a => a.GENRE_NAME == genre).FirstOrDefault();
                    if (genre1 == null)
                    {
                        str += "Genre null";
                        throw new Exception("Genre null");
                    }
                    unitOfWork.BookGenresRepository.Add(new BOOK_GENRE()
                    {
                        BOOKId = book.Id,
                        GENREId = genre1.Id
                    });
                    unitOfWork.Save();
                    return "Accept registre!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message + "\n" + str;
            }
        
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

        public List<Dictionary<string, string>> getAuthors()
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                List<AUTHOR> authors = unit.AuthorsRepository.GetAll();
                List<Dictionary<string, string>> authorsList = new List<Dictionary<string, string>>();
                foreach (AUTHOR author in authors)
                {
                    Dictionary<string, string> authorDict = new Dictionary<string, string>();
                    authorDict.Add("id", author.Id.ToString());
                    authorDict.Add("name", author.AUTHOR_NAME);
                    authorDict.Add("country", author.COUNTRY);
                    authorsList.Add(authorDict);
                }
                return authorsList;
            }
        }

        public List<Dictionary<string, string>> getBooks()
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                List<BOOK> books = unit.BooksRepository.GetAll();
                List<Dictionary<string, string>> booksList = new List<Dictionary<string, string>>();
                foreach (BOOK book in books)
                {
                    Dictionary<string, string> bookDict = new Dictionary<string, string>();
                    bookDict.Add("id", book.Id.ToString());
                    bookDict.Add("name", book.BOOK_NAME);
                    bookDict.Add("status", book.BOOK_STATUS.ToString());
                    bookDict.Add("file", book.BOOK_FILE);
                    bookDict.Add("image", book.BOOK_IMAGE);
                    bookDict.Add("description", book.BOOK_DESCRIPTION);
                    booksList.Add(bookDict);
                }
                return booksList;
            }
        }

        public List<Dictionary<string, string>> getGenrs()
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                List<GENRE> genrs = unit.GenresRepository.GetAll();
                List<Dictionary<string, string>> genrsList = new List<Dictionary<string, string>>();
                foreach (GENRE genr in genrs)
                {
                    Dictionary<string, string> genrDict = new Dictionary<string, string>();
                    genrDict.Add("id", genr.Id.ToString());
                    genrDict.Add("name", genr.GENRE_NAME);
                    genrsList.Add(genrDict);
                }
                return genrsList;
            }                
        }

        public List<Dictionary<string, string>> getTags()
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                List<TAG> tags = unit.TagsRepository.GetAll();
                List<Dictionary<string, string>> tagsList = new List<Dictionary<string, string>>();
                foreach (TAG tag in tags)
                {
                    Dictionary<string, string> tagDict = new Dictionary<string, string>();
                    tagDict.Add("id", tag.TAGId.ToString());
                    tagDict.Add("name", tag.TAG_NAME);
                    tagsList.Add(tagDict);
                }
                return tagsList;
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
