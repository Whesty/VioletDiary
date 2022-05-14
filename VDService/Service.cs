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
        #region Add
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
                        BOOK_STATUS = false,
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
                        string value = match.Value;
                        value.Remove(value.Length - 1, 1);
                        AUTHOR author1 = unitOfWork.AuthorsRepository.GetAll().Where(a => a.AUTHOR_NAME == value).FirstOrDefault();
                        str += "\nget av";

                        if (author1 == null)
                        {
                            author1 = new AUTHOR()
                            {
                                AUTHOR_NAME = value,
                                COUNTRY = null
                            };
                            str += "\nadd av";
                            unitOfWork.AuthorsRepository.Add(author1);
                            unitOfWork.Save();
                            str += "\nSave";

                            //unitOfWork.
                        }
                        AUTHOR author2 = unitOfWork.AuthorsRepository.GetAll().Where(a => a.AUTHOR_NAME == value).FirstOrDefault();
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
                        string value = match.Value;
                        value.Remove(value.Length - 1, 1);
                        TAG tag1 = unitOfWork.TagsRepository.GetAll().Where(a => a.TAG_NAME == value).FirstOrDefault();
                        str += "\nCreat tag1";
                        if (tag1 == null)
                        {
                            tag1 = new TAG()
                            {
                                TAG_NAME = value
                            };
                            str += "\nCreate tag1+";
                            unitOfWork.TagsRepository.Add(tag1);
                            str += "\nAdd tag2";
                            unitOfWork.Save();
                            str += "\nSave";
                        }
                        TAG tag2 = unitOfWork.TagsRepository.GetAll().Where(a => a.TAG_NAME == value).FirstOrDefault();
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

        public bool addBookMarks(int idBook, int IdUser, int mark, string status, bool presence)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                USER_BOOKMARKS book = new USER_BOOKMARKS(){
                    BOOKId = idBook,
                    USERId = IdUser,
                    MARKS = mark,
                    STATUS_READING = status,
                    PRESENCE = presence,
                    DATA_ADD = DateTime.Now,
                    DATA_READING = DateTime.Now
                };
                if (book == null)
                    return false;
                unitOfWork.UserBookmarksRepository.Add(book);
                unitOfWork.Save();
                return true;
            }
        }

        public string AddFeedBack(int idBook, string text, int idUser, string rating)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                FEEDBACK feedback = new FEEDBACK()
                {
                    ID_BOOK = idBook,
                    ID_USER = idUser,
                    FEEDBACK1 = text,
                    RATING = float.Parse(rating),
                    DATE = DateTime.Now
                };
                unitOfWork.FeedbacksRepository.Add(feedback);
                unitOfWork.Save();
                return "Отправлен!";
            }
        }
        public string AddPaint(int idBook, int idUser, string pating)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                PAINT paint = new PAINT()
                {
                    ID_BOOK = idBook,
                    ID_USER_ADD = idUser,
                    LINK = pating,
                    DATA = DateTime.Now,
                    ID_ARTIST = 1
                };
                unitOfWork.PaintsRepository.Add(paint);
                unitOfWork.Save();
                return "Загружен!";
            } 
        }

        #endregion
        #region Delete
        public void DeleteBooks(int idBook)
        {
            string str = "";
            try
            {

                using (UnitOfWork unit = new UnitOfWork())
                {
                    BOOK book = unit.BooksRepository.GetAll().Where(x => x.Id == idBook).FirstOrDefault();
                    foreach (BOOK_TAG i in unit.BookTagsRepository.GetAll().Where(x => x.BOOKId == idBook).ToList())
                    {
                        unit.BookTagsRepository.Remove(i.Id);
                        unit.Save();
                        //int count = unit.BookTagsRepository.GetAll().Where(x => x.TAGId == i.TAGId).Count();
                        //if(count > 1)
                        //{
                       // unit.TagsRepository.Remove(i.TAGId);
                        //    unit.Save();
                        //}
                    }
                    foreach (BOOK_AUTHOR i in unit.BookAuthorsRepository.GetAll().Where(x => x.BOOKId == idBook).ToList())
                    {
                        unit.BookAuthorsRepository.Remove(i.Id);
                        unit.Save();
                        //int count = unit.BookAuthorsRepository.GetAll().Where(x => x.AUTHORId == i.AUTHORId).Count();
                        //if(count > 1)
                        //{
                        //    unit.AuthorsRepository.Remove(i.AUTHORId);
                        //    unit.Save();
                        //}

                    }
                    foreach (BOOK_GENRE i in unit.BookGenresRepository.GetAll().Where(x => x.BOOKId == idBook).ToList())
                    {
                        unit.BookGenresRepository.Remove(i.Id);
                        unit.Save();
                    }
                    foreach (FEEDBACK i in unit.FeedbacksRepository.GetAll().Where(x => x.ID_BOOK == idBook).ToList())
                    {
                        unit.FeedbacksRepository.Remove(i.Id);
                        unit.Save();
                    }
                    foreach (PAINT i in unit.PaintsRepository.GetAll().Where(x => x.ID_BOOK == idBook).ToList())
                    {
                        unit.PaintsRepository.Remove(i.Id);
                        unit.Save();
                    }
                    unit.Save();
                    unit.BooksRepository.Remove(idBook);
                    unit.Save();
                    ClearDataBase();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
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
        #region Edit
        public string EditBook(int id, string name, string description, string image, string file, string Serialize, string Realese, int idUser, bool bookstatus)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                try
                {
                    BOOK book = unitOfWork.BooksRepository.GetAll().Where(x => x.Id == id).FirstOrDefault();
                    if (book == null)
                        return "Книга не найдена!";
                    book.BOOK_NAME = name;
                    book.BOOK_DESCRIPTION = description;
                    book.BOOK_IMAGE = image;
                    book.BOOK_FILE = file;
                    book.BOOK_SERIES = Serialize;
                    book.DATA_RELEASE = int.Parse(Realese);
                    book.BOOK_STATUS = bookstatus;
                    unitOfWork.BooksRepository.Update(book);
                    unitOfWork.Save();
                    return "Книга отредактирована!";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public bool editBookMarks(int idBook, int IdUser, int mark, string status, bool presence)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                USER_BOOKMARKS book = unitOfWork.UserBookmarksRepository.GetAll().Where(x => x.BOOKId == idBook && x.USERId == IdUser).FirstOrDefault();
                if (book == null)
                    return false;
                book.MARKS = mark;
                book.STATUS_READING = status;
                book.PRESENCE = presence;
                unitOfWork.UserBookmarksRepository.Update(book);
                unitOfWork.Save();
                return true;
            }
        }
        #endregion
        #region Get
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

        public List<Dictionary<string, string>> getAuthorsBook(int id)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                List<AUTHOR> authors = unit.BookAuthorsRepository.GetAll().Where(x => x.BOOKId == id).Select(x => x.AUTHOR).ToList();
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

        public Dictionary<string, string> getBookMarks(int idBook, int IdUser)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                USER_BOOKMARKS book = unit.UserBookmarksRepository.GetAll().Where(x => x.BOOKId == idBook && x.USERId == IdUser).FirstOrDefault();
                if (book == null)
                {
                    return null;
                }
                Dictionary<string, string> bookDict = new Dictionary<string, string>();
                bookDict.Add("id", book.Id.ToString());
                bookDict.Add("StatusReading", book.STATUS_READING);
                bookDict.Add("Presence", book.PRESENCE.ToString());
                bookDict.Add("Date", book.DATA_ADD.ToString());
                bookDict.Add("Marks", book.MARKS.ToString());
                return bookDict;


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
                    bookDict.Add("Realese", book.DATA_RELEASE.ToString());
                    booksList.Add(bookDict);
                }
                return booksList;
            }
        }

        public List<Dictionary<string, string>> getFeedBackBook(int id)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                List<FEEDBACK> feedback = unit.FeedbacksRepository.GetAll().Where(x => x.ID_BOOK == id).ToList();
                List<Dictionary<string, string>> feedbackList = new List<Dictionary<string, string>>();
                foreach (FEEDBACK feedback1 in feedback)
                {
                    Dictionary<string, string> feedbackDict = new Dictionary<string, string>();
                    feedbackDict.Add("id", feedback1.Id.ToString());
                    feedbackDict.Add("text", feedback1.FEEDBACK1);
                    feedbackDict.Add("date", feedback1.DATE.ToString());
                    feedbackDict.Add("username", feedback1.USER.USER_NAME);
                    feedbackDict.Add("pating", feedback1.RATING.ToString());
                    feedbackDict.Add("useravatar", feedback1.USER.USER_AVATAR);
                    
                    feedbackList.Add(feedbackDict);
                }
                return feedbackList;
            }
        }            

        public List<Dictionary<string, string>> getGenresBook(int id)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                List<GENRE> genres = unit.BookGenresRepository.GetAll().Where(x => x.BOOKId == id).Select(x => x.GENRE).ToList();
                List<Dictionary<string, string>> genresList = new List<Dictionary<string, string>>();
                foreach (GENRE genre in genres)
                {
                    Dictionary<string, string> genreDict = new Dictionary<string, string>();
                    genreDict.Add("id", genre.Id.ToString());
                    genreDict.Add("name", genre.GENRE_NAME);
                    genresList.Add(genreDict);
                }
                return genresList;
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

        public List<Dictionary<string, string>> getPaintBook(int id)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                List<PAINT> paints = unit.PaintsRepository.GetAll().Where(x => x.ID_BOOK == id).ToList();
                List<Dictionary<string, string>> paintsList = new List<Dictionary<string, string>>();
                foreach (PAINT paint in paints)
                {
                    Dictionary<string, string> paintDict = new Dictionary<string, string>();
                    paintDict.Add("id", paint.Id.ToString());
                    paintDict.Add("link", paint.LINK);
                    paintDict.Add("idArtist", paint.ID_ARTIST.ToString());
                    paintDict.Add("nameArtist", paint.ARTIST.ARTIST_NAME);
                    paintDict.Add("dataAdd", paint.DATA.ToString());
                    paintDict.Add("userAdd", paint.ID_USER_ADD.ToString());
                    paintsList.Add(paintDict);
                }
                return paintsList;
            }                
       }

        public List<Dictionary<string, string>> getPaints()
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                List<PAINT> paints = unit.PaintsRepository.GetAll();
                List<Dictionary<string, string>> paintsList = new List<Dictionary<string, string>>();
                foreach (PAINT paint in paints)
                {
                    Dictionary<string, string> paintDict = new Dictionary<string, string>();
                    paintDict.Add("id", paint.Id.ToString());
                    paintDict.Add("link", paint.LINK);
                    paintDict.Add("idBook", paint.ID_BOOK.ToString());
                    paintDict.Add("idArtist", paint.ID_ARTIST.ToString());
                    paintDict.Add("nameArtist", paint.ARTIST.ARTIST_NAME);
                    paintDict.Add("dataAdd", paint.DATA.ToString());
                    paintDict.Add("userAdd", paint.ID_USER_ADD.ToString());
                    paintsList.Add(paintDict);
                }
                return paintsList;
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

        public List<Dictionary<string, string>> getTagsBook(int id)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                List<TAG> tags = unit.BookTagsRepository.GetAll().Where(x => x.BOOKId == id).Select(x => x.TAG).ToList();
                
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

        public Dictionary<string, string> getUserInfo(int id)
        {
            using(UnitOfWork unit = new UnitOfWork())
            {
                USER user = unit.UserRepository.Get(id);
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
        }
        #endregion
        #region User

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
                unit.UserRepository.Update(user);
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
        #endregion

        public void ClearDataBase()
        {
            using(UnitOfWork unit = new UnitOfWork())
            {
                foreach (TAG i in unit.TagsRepository.GetAll().Where(x => x.BOOK_TAG.Count == 0).ToList())
                {
                    unit.TagsRepository.Remove(i.TAGId);
                    unit.Save();
                }
                foreach (AUTHOR i in unit.AuthorsRepository.GetAll().Where(x => x.BOOK_AUTHOR.Count == 0).ToList())
                {
                    unit.AuthorsRepository.Remove(i.Id);
                    unit.Save();
                }
            }
        }
    }
}
