using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VDService.DataBase
{
    public class Context: DbContext
    {
        public DbSet<USERS> Users { get; set; }
        public DbSet<AUTHORIZED> Authorizeds { get; set; }
        //Дописать остальные таблицы по шаблону
        public Context() : base("DefaultConnection") { }
    }
}
