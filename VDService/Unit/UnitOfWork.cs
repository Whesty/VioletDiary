using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDService.DataBase;
using VDService.Repository;

namespace VDService.Unit
{
    public class UnitOfWork : IDisposable
    {
        private Context context;
        private Repository<USERS> userRepository;
        private Repository<AUTHORIZED> userAuthRepository;
        //Дописать остальные таблицы
        public UnitOfWork()
        {
            context = new Context();
        }

        public Repository<USERS> UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new Repository<USERS>(context);
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
        public void Save()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}    
