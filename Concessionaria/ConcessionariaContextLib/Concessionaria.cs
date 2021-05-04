using System;
using ConcessionariaEntitiesLib;
using Microsoft.EntityFrameworkCore;

namespace ConcessionariaContextLib
{
    public class Concessionaria : DbContext
    {
        public DbSet<Agencia> Agencias{get; set;}
        public DbSet<Gerente> Gerentes{get; set;}
        public DbSet<Vendedor> Vendedores{get; set;}
        public DbSet<Carro> Carros{get; set;}

        //Cria a base para a relação entre banco de dados e objetos
        public Concessionaria(DbContextOptions<Concessionaria> options) 
            : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder){

            //Modelagem da classe Agência
            modelBuilder.Entity<Agencia>()
            .Property(Agencia => Agencia.AgenciaID)
            .IsRequired();

            modelBuilder.Entity<Agencia>()
            .Property(Agencia => Agencia.NomeAgencia)
            .IsRequired()
            .HasMaxLength(40);

            modelBuilder.Entity<Agencia>()
            .Property(Agencia => Agencia.GerenteAgencia)
            .IsRequired()
            .HasMaxLength(40);

            modelBuilder.Entity<Agencia>()
            .Property(Agencia => Agencia.CidadeAgencia)
            .IsRequired()
            .HasMaxLength(40);

            //Modelagem da classe Gerente
            modelBuilder.Entity<Gerente>()
            .Property(Gerente => Gerente.GerenteID)
            .IsRequired();

            modelBuilder.Entity<Gerente>()
            .Property(Gerente => Gerente.AgenciaID)
            .IsRequired();

            modelBuilder.Entity<Gerente>()
            .Property(Gerente => Gerente.Nome)
            .IsRequired()
            .HasMaxLength(40);

            modelBuilder.Entity<Gerente>()
            .Property(Gerente => Gerente.Telefone)
            .IsRequired();

            //Modelagem da classe Vendedor
            modelBuilder.Entity<Vendedor>()
            .Property(Vendedor => Vendedor.VendedorID)
            .IsRequired();

            modelBuilder.Entity<Vendedor>()
            .Property(Vendedor => Vendedor.AgenciaID)
            .IsRequired();

            modelBuilder.Entity<Vendedor>()
            .Property(Vendedor => Vendedor.Nome)
            .IsRequired()
            .HasMaxLength(40);

            modelBuilder.Entity<Vendedor>()
            .Property(Vendedor => Vendedor.NumeroVendas)
            .IsRequired();

            //Modelagem da classe Carro
            modelBuilder.Entity<Carro>()
            .Property(Carro => Carro.CarroID)
            .IsRequired();

            modelBuilder.Entity<Carro>()
            .Property(Carro => Carro.AgenciaID)
            .IsRequired();

            modelBuilder.Entity<Carro>()
            .Property(Carro => Carro.Marca)
            .IsRequired()
            .HasMaxLength(25);

            modelBuilder.Entity<Carro>()
            .Property(Carro => Carro.Modelo)
            .IsRequired()
            .HasMaxLength(25);

            modelBuilder.Entity<Carro>()
            .Property(Carro => Carro.Ano)
            .IsRequired();


        }
    }
}
