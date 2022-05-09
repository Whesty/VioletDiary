using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace VDService
{
    public partial class DataBase : DbContext
    {
        public DataBase()
            : base("DBConnection")
        {
        }

        public virtual DbSet<ARTIST> ARTISTs { get; set; }
        public virtual DbSet<AUTHORIZED> AUTHORIZEDs { get; set; }
        public virtual DbSet<AUTHOR> AUTHORS { get; set; }
        public virtual DbSet<BOOK_AUTHOR> BOOK_AUTHOR { get; set; }
        public virtual DbSet<BOOK_GENRE> BOOK_GENRE { get; set; }
        public virtual DbSet<BOOK_TAG> BOOK_TAG { get; set; }
        public virtual DbSet<BOOK> BOOKS { get; set; }
        public virtual DbSet<FEEDBACK> FEEDBACKs { get; set; }
        public virtual DbSet<GENRE> GENREs { get; set; }
        public virtual DbSet<PAINT> PAINTs { get; set; }
        public virtual DbSet<SUBSCRIPTION> SUBSCRIPTIONs { get; set; }
        public virtual DbSet<TAG> TAGs { get; set; }
        public virtual DbSet<USER_BOOKMARKS> USER_BOOKMARKS { get; set; }
        public virtual DbSet<USER> USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ARTIST>()
                .HasMany(e => e.PAINTs)
                .WithRequired(e => e.ARTIST)
                .HasForeignKey(e => e.ID_ARTIST)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AUTHORIZED>()
                .HasMany(e => e.USERS)
                .WithRequired(e => e.AUTHORIZED)
                .HasForeignKey(e => e.ID_AUTHORIZED)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AUTHOR>()
                .Property(e => e.COUNTRY)
                .IsFixedLength();

            modelBuilder.Entity<AUTHOR>()
                .HasMany(e => e.BOOK_AUTHOR)
                .WithRequired(e => e.AUTHOR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AUTHOR>()
                .HasMany(e => e.SUBSCRIPTIONs)
                .WithRequired(e => e.AUTHOR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BOOK>()
                .HasMany(e => e.BOOK_AUTHOR)
                .WithRequired(e => e.BOOK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BOOK>()
                .HasMany(e => e.BOOK_GENRE)
                .WithRequired(e => e.BOOK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BOOK>()
                .HasMany(e => e.BOOK_TAG)
                .WithRequired(e => e.BOOK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BOOK>()
                .HasMany(e => e.FEEDBACKs)
                .WithRequired(e => e.BOOK)
                .HasForeignKey(e => e.ID_BOOK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BOOK>()
                .HasMany(e => e.PAINTs)
                .WithRequired(e => e.BOOK)
                .HasForeignKey(e => e.ID_BOOK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BOOK>()
                .HasMany(e => e.USER_BOOKMARKS)
                .WithRequired(e => e.BOOK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GENRE>()
                .HasMany(e => e.BOOK_GENRE)
                .WithRequired(e => e.GENRE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAG>()
                .HasMany(e => e.BOOK_TAG)
                .WithRequired(e => e.TAG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.BOOKS)
                .WithRequired(e => e.USER)
                .HasForeignKey(e => e.ID_USER_ADD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.FEEDBACKs)
                .WithRequired(e => e.USER)
                .HasForeignKey(e => e.ID_USER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.PAINTs)
                .WithRequired(e => e.USER)
                .HasForeignKey(e => e.ID_USER_ADD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.SUBSCRIPTIONs)
                .WithRequired(e => e.USER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.USER_BOOKMARKS)
                .WithRequired(e => e.USER)
                .WillCascadeOnDelete(false);
        }
    }
}
