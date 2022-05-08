using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDService.Repository;

namespace VDService.Unit
{
    public class UnitOfWork : IDisposable
    {
        private DataBase context;
        private Repository<USER> userRepository;
        private Repository<AUTHORIZED> userAuthRepository;
        private Repository<BOOK> booksRepository;
        private Repository<Task> tagsRepository;
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
