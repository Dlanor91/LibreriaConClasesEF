using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Libreria.Dominio.EntidadesNegocio;
using AccesoDatos.EF;

namespace Libreria.AccesoDatos.EF
{
	public class LibreriaContext : DbContext
	{
		public DbSet<Autor> Autores{ get; set; }
		public DbSet<Publicacion> Publicaciones { get; set; }
		public DbSet<Revista> Revistas { get; set; }
		public DbSet<Libro> Libros { get; set; }
		
		public LibreriaContext(DbContextOptions<LibreriaContext> options)
			:base(options)
		{			
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			//FLUENT API PARA CONFIGURAR COSAS

			//modelBuilder.Entity<Autor>().HasMany<AutorPublicacion>().WithOne(ap => ap.Autor);
			//modelBuilder.Entity<Publicacion>().HasMany<AutorPublicacion>().WithOne(ap => ap.Publicacion);
			
			//LO ANTERIOR SE CAMBIÓ POR ESTO PARA CORREGIR LAS FK DUPLICADAS EN LA TABLA AUTORPUBLICACION:
			modelBuilder.Entity<Autor>().HasMany(a => a.AutoresPublicaciones).WithOne(ap => ap.Autor);
			modelBuilder.Entity<Publicacion>().HasMany(p => p.AutoresPublicaciones).WithOne(ap => ap.Publicacion);

			modelBuilder.Entity<AutorPublicacion>().HasKey(ap => new { ap.AutorId, ap.PublicacionId });
			modelBuilder.Entity<AutorPublicacion>().Property(ap => ap.Id).ValueGeneratedOnAdd();

			//modelBuilder.Entity<Libro>().HasAlternateKey(l => l.ISBN); //ES UNIQUE ISBN
			
			//ALTERNATIVA A LO ANTERIOR:
			modelBuilder.Entity<Libro>().HasIndex(l => l.ISBN).IsUnique();

			base.OnModelCreating(modelBuilder);
        }
    }
}
