﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VDService
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VioletDiaryEntities : DbContext
    {
        public VioletDiaryEntities()
            : base("name=VioletDiaryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ARTIST> ARTIST { get; set; }
        public virtual DbSet<AUTHORIZED> AUTHORIZED { get; set; }
        public virtual DbSet<AUTHORS> AUTHORS { get; set; }
        public virtual DbSet<BOOKS> BOOKS { get; set; }
        public virtual DbSet<FEEDBACK> FEEDBACK { get; set; }
        public virtual DbSet<GENRE> GENRE { get; set; }
        public virtual DbSet<PAINT> PAINT { get; set; }
        public virtual DbSet<SUBSCRIPTION> SUBSCRIPTION { get; set; }
        public virtual DbSet<TAG> TAG { get; set; }
        public virtual DbSet<USER_BOOKMARKS> USER_BOOKMARKS { get; set; }
        public virtual DbSet<USERS> USERS { get; set; }
    }
}
