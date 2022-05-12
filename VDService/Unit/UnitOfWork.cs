using System;
using System.Data.Entity.Validation;
using System.IO;
using System.Text;
using VDService.Model;
using VDService.Repository;

namespace VDService.Unit
{
    public class UnitOfWork : IDisposable
    {
        private DataBase context;
        private Repository<USER> userRepository;
        private Repository<AUTHORIZED> userAuthRepository;
        private Repository<BOOK> booksRepository;
        private Repository<TAG> tagsRepository;
        private Repository<GENRE> genresRepository;
        private Repository<AUTHOR> authorsRepository;
        private Repository<BOOK_AUTHOR> bookAuthorsRepository;
        private Repository<BOOK_TAG> bookTagsRepository;
        private Repository<BOOK_GENRE> bookGenresRepository;
        private Repository<PAINT> paintsRepository;
        private Repository<SUBSCRIPTION> subscriptionsRepository;
        private Repository<USER_BOOKMARKS> userBookmarksRepository;
        private Repository<FEEDBACK> feedbacksRepository;
        private Repository<ARTIST> artistsRepository;
        //Дописать остальные таблицы
        public UnitOfWork()
        {
            context = new DataBase();
        }

        public Repository<USER> UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new Repository<USER>(context);
                return userRepository;
            }
        }

        public Repository<AUTHORIZED> UserAuthRepository
        {
            get
            {
                if (userAuthRepository == null)
                    userAuthRepository = new Repository<AUTHORIZED>(context);
                return userAuthRepository;
            }
        }
        public Repository<BOOK> BooksRepository
        {
            get
            {
                if (booksRepository == null)
                    booksRepository = new Repository<BOOK>(context);
                return booksRepository;
            }
        }
        public Repository<AUTHOR> AuthorsRepository
        {
            get
            {
                if (authorsRepository == null)
                    authorsRepository = new Repository<AUTHOR>(context);
                return authorsRepository;
            }
        }
        public Repository<GENRE> GenresRepository
        {
            get
            {
                if (genresRepository == null)
                    genresRepository = new Repository<GENRE>(context);
                return genresRepository;
            }
        }
        public Repository<TAG> TagsRepository
        {
            get
            {
                if (tagsRepository == null)
                    tagsRepository = new Repository<TAG>(context);
                return tagsRepository;
            }
        }
        public Repository<BOOK_AUTHOR> BookAuthorsRepository
        {
            get
            {
                if (bookAuthorsRepository == null)
                    bookAuthorsRepository = new Repository<BOOK_AUTHOR>(context);
                return bookAuthorsRepository;
            }
        }
        public Repository<BOOK_TAG> BookTagsRepository
        {
            get
            {
                if (bookTagsRepository == null)
                    bookTagsRepository = new Repository<BOOK_TAG>(context);
                return bookTagsRepository;
            }
        }
        public Repository<BOOK_GENRE> BookGenresRepository
        {
            get
            {
                if (bookGenresRepository == null)
                    bookGenresRepository = new Repository<BOOK_GENRE>(context);
                return bookGenresRepository;
            }
        }
        public Repository<PAINT> PaintsRepository
        {
            get
            {
                if (paintsRepository == null)
                    paintsRepository = new Repository<PAINT>(context);
                return paintsRepository;
            }
        }
        public Repository<SUBSCRIPTION> SubscriptionsRepository
        {
            get
            {
                if (subscriptionsRepository == null)
                    subscriptionsRepository = new Repository<SUBSCRIPTION>(context);
                return subscriptionsRepository;
            }
        }
        public Repository<USER_BOOKMARKS> UserBookmarksRepository
        {
            get
            {
                if (userBookmarksRepository == null)
                    userBookmarksRepository = new Repository<USER_BOOKMARKS>(context);
                return userBookmarksRepository;
            }
        }
        public Repository<FEEDBACK> FeedbacksRepository
        {
            get
            {
                if (feedbacksRepository == null)
                    feedbacksRepository = new Repository<FEEDBACK>(context);
                return feedbacksRepository;
            }
        }


        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                FileStream file = new FileStream("ErorrMesenge1", FileMode.OpenOrCreate);
                string str = "null";
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    str = "\nObject: " + validationError.Entry.Entity.ToString();
                    foreach (DbValidationError error in validationError.ValidationErrors)
                    {
                        str += "\n" + error.ErrorMessage;
                    }
                }
                Exception err = new Exception(str);
                file.Write(Encoding.Default.GetBytes(str), 0, str.Length);
                throw err;
            }

        }



        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
