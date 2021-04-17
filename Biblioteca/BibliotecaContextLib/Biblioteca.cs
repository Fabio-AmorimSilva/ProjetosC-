using System;
using BibliotecaEntitiesLib;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaContextLib
{
    //Gerenciar a conexão com o banco de dados
    public class Biblioteca : DbContext
    {
        //Mapeamento das tabelas no banco de dados
        public DbSet<Books> Books{get; set;}
        public DbSet<Author> Authors{get; set;}

        public Biblioteca(DbContextOptions<Biblioteca> options)
        : base(options){

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){

            base.OnModelCreating(modelBuilder);

            //Books Model
            modelBuilder.Entity<Books>()
            .Property(bisbn => bisbn.ISBN)
            .IsRequired();

            modelBuilder.Entity<Books>()
            .Property(bt => bt.Title)
            .IsRequired()
            .HasMaxLength(40);

            modelBuilder.Entity<Books>()
            .Property(ba => ba.Author)
            .IsRequired()
            .HasMaxLength(40);

            modelBuilder.Entity<Books>()
            .Property(bg => bg.Genre)
            .IsRequired()
            .HasMaxLength(20);

            modelBuilder.Entity<Books>()
            .Property(by => by.Year)
            .IsRequired();

            modelBuilder.Entity<Author>()
            .Property(an => an.Name)
            .IsRequired()
            .HasMaxLength(40);

            modelBuilder.Entity<Author>()
            .Property(ab => ab.Books)
            .IsRequired()
            .HasMaxLength(40);

            modelBuilder.Entity<Author>()
            .Property(ac => ac.Country)
            .IsRequired()
            .HasMaxLength(20);
            
        }
        
    }
}
