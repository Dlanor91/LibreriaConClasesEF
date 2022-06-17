using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Libreria.Dominio.EntidadesNegocio;
using AccesoDatos.EF;

namespace Libreria.AccesoDatos.EF
{
	public class LibreriaContext:DbContext
	{
		public DbSet<Autor> Autores{ get; set; }
		public DbSet<Publicacion> Publicaciones { get; set; }
		public DbSet<Revista> Revistas { get; set; }
		public DbSet<Libro> Libros { get; set; }
		
		public LibreriaContext(DbContextOptions<LibreriaContext> options)
			:base(options)
		{			
		}

		//para que el id sea deambas key
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			
			modelBuilder.Entity<Autor>().HasMany(a => a.AutoresPublicaciones).WithOne(ap => ap.Autor);
			modelBuilder.Entity<Publicacion>().HasMany(p => p.AutoresPublicaciones).WithOne(ap => ap.Publicacion);

			modelBuilder.Entity<AutorPublicacion>().HasKey(ap => new { ap.AutorId, ap.PublicacionId});

			modelBuilder.Entity<AutorPublicacion>().Property(ap => ap.Id).ValueGeneratedOnAdd();//cada vez que se ingresa se genera el valor como identity


			base.OnModelCreating(modelBuilder);	
        }

    }
}
