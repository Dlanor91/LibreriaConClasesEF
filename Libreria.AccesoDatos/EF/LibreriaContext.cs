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
	}
}
