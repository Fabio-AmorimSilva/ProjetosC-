using System;
using ImobiliariaEntities;
using Microsoft.EntityFrameworkCore;

namespace ImobiliariaContext
{
    public class Imobiliaria : DbContext
    {

        public DbSet<Agencia> Agencias {get; set;}
        public DbSet<Corretor> Corretores {get; set;}
        public DbSet<Dono> Donos{get; set;}
        public DbSet<Imovel> Imoveis{get; set;}

        public Imobiliaria(DbContextOptions<Imobiliaria> options) : base(options){

        }

        protected void OnModelCreate(ModelBuilder modelBuilder){

            base.OnModelCreating(modelBuilder);

            //Agencia Model
            modelBuilder.Entity<Agencia>()
            .Property(ai => ai.id)
            .IsRequired();

            modelBuilder.Entity<Agencia>()
            .Property(an => an.nome)
            .IsRequired()
            .HasMaxLength(40);

            modelBuilder.Entity<Agencia>()
            .Property(ac => ac.cidade)
            .IsRequired()
            .HasMaxLength(40);

            modelBuilder.Entity<Agencia>()
            .Property(aiC => aiC.idCorretores)
            .IsRequired();

            modelBuilder.Entity<Agencia>()
            .Property(ai => ai.idImoveis)
            .IsRequired();

            //Corretor Model
            modelBuilder.Entity<Corretor>()
            .Property(ci => ci.id)
            .IsRequired();

            modelBuilder.Entity<Corretor>()
            .Property(cia => cia.idAgencia)
            .IsRequired();

            modelBuilder.Entity<Corretor>()
            .Property(cn => cn.nome)
            .IsRequired()
            .HasMaxLength(40);

            modelBuilder.Entity<Corretor>()
            .Property(cid => cid.idade)
            .IsRequired();

            modelBuilder.Entity<Corretor>()
            .Property(cv => cv.vendas)
            .IsRequired();

            //Dono Model
            modelBuilder.Entity<Dono>()
            .Property(di => di.id)
            .IsRequired();

            modelBuilder.Entity<Dono>()
            .Property(dn => dn.nome)
            .IsRequired()
            .HasMaxLength(40);

            modelBuilder.Entity<Dono>()
            .Property(did => did.idade)
            .IsRequired();

            modelBuilder.Entity<Dono>()
            .Property(dim => dim.imovel)
            .IsRequired()
            .HasMaxLength(40);

            modelBuilder.Entity<Imovel>()
            .Property(i => i.id)
            .IsRequired();

            modelBuilder.Entity<Imovel>()
            .Property(ia => ia.idAgencia)
            .IsRequired();

            modelBuilder.Entity<Imovel>()
            .Property(id => id.idDono)
            .IsRequired();

            modelBuilder.Entity<Imovel>()
            .Property(iend => iend.endereco)
            .IsRequired()
            .HasMaxLength(40);

            modelBuilder.Entity<Imovel>()
            .Property(ip => ip.preco)
            .IsRequired();

        }
        
    }
}
