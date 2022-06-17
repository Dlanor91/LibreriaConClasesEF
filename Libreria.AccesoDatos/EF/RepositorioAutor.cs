using System;
using System.Collections.Generic;
using System.Text;
using Libreria.Dominio.EntidadesNegocio;
using Libreria.Dominio.InterfacesRepositorios;
using Libreria.AccesoDatos.EF;
using System.Linq;

namespace AccesoDatos.EF
{
	class RepositorioAutor : IRepositorioAutor
	{

        public LibreriaContext Contexto { get; set; }

        public RepositorioAutor(LibreriaContext ctx)
        {
			Contexto = ctx;
        }

        public bool Add(Autor nuevoAutor)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Autor> FindAll()
		{
			throw new NotImplementedException();
		}

		public Autor FindById(object Clave)
		{
			throw new NotImplementedException();
		}

       

        public IEnumerable<Autor> GetAutoresNacionalidad(string nacionalidad)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Autor> GetAutoresNombreIncluye(string textoBuscado)
		{
			throw new NotImplementedException();
		}

		public bool Remove(object Clave)
		{
			throw new NotImplementedException();
		}

		public bool Update(Autor autor)
		{
			throw new NotImplementedException();
		}


		public IEnumerable<Autor> GetAutoresConPublicacionesConMasDe(int paginas)
		{
            return Contexto.Autores.Where(autor => autor.AutoresPublicaciones
                                                        .Any(ap => ap.Publicacion.CantidadPaginas > paginas))
                                   .ToList();

            //EMPEZANDO POR PUBLICACIONES
			//return Contexto.Publicaciones
							//.Where(pub => pub.CantidadPaginas > paginas)
							//.SelectMany(pub => pub.AutoresPublicaciones.Select(ap => ap.Autor))
							//.ToList();
		}

		public IEnumerable<Autor> GetAutoresQuePublicaronEnRevistas()
        {
            return Contexto.Autores.Where(autor => autor.AutoresPublicaciones
														.Any(ap => ap.Publicacion is Revista))
									.ToList();

			//EMPEZANDO POR PUBLICACIONES:
			//return Contexto.Publicaciones
			//				.OfType<Revista>()
			//				.SelectMany(rev => rev.AutoresPublicaciones.Select(ap => ap.Autor))
			//				.ToList();
		}

        public IEnumerable<Publicacion> GetPublicacionesDeAutor(int id)
        {
			//CONTEMPLA LA CO-AUTORÍA
			return Contexto.Publicaciones.Where(pub => pub.AutoresPublicaciones
														  .Any(ap => ap.Autor.Id == id))
										 .ToList();

			//NO CONTEMPLA LA CO-AUTORÍA:
			//return Contexto.Publicaciones.Where(pub => pub.AutoresPublicaciones
			//											  .Any(ap => ap.Autor.Id == id) && pub.AutoresPublicaciones.Count() == 1)
			//							 .ToList();


			//COMENZANDO POR AUTORES:
			//return Contexto.Autores.Where(autor => autor.Id == id)
			//						.SelectMany(autor => autor.AutoresPublicaciones.Select(ap => ap.Publicacion))
			//						.ToList();

        }

        public IEnumerable<Libro> GetLibrosConVariosAutores()
        {
			return Contexto.Libros
							.Where(libro => libro.AutoresPublicaciones.Count() > 1)
							//.OrderByDescending(libro => libro.CantidadPaginas) //SI FUERA ORDENADO
							//.ThenBy(libro => libro.FechaPublicado) //CRITERIO COMPUESTO
							.ToList();

			//return Contexto.Publicaciones
			//				.Where(pub => pub.AutoresPublicaciones.Count() > 1)
			//				.OfType<Libro>();

			//return Contexto.Publicaciones
			//				.Where(pub => pub.AutoresPublicaciones.Count() > 1).Where(pub => pub is Libro)
			//				.Select(pub => (Libro)pub);

			//COMENZANDO POR AUTORES:
			//return Contexto.Autores
			//				.SelectMany(autor => autor.AutoresPublicaciones.Select(ap => ap.Publicacion))
			//				.Where(pub => pub.AutoresPublicaciones.Count() > 1)
			//				.OfType<Libro>()
			//				.Distinct()							
			//				.ToList();
		}

        public IEnumerable<Revista> GetRevistasConAutoresDeLibros()
        {
			return Contexto.Revistas
							.Where(rev => rev.AutoresPublicaciones
											 .Any(ap => ap.Autor.AutoresPublicaciones
																.Any(ap => ap.Publicacion is Libro)))
							.ToList();

			//EMPEZANDO POR AUTORES:
			//return Contexto.Autores.Where(autor => autor.AutoresPublicaciones.Any(ap => ap.Publicacion is Libro))
			//						.SelectMany(autor => autor.AutoresPublicaciones.Select(ap => ap.Publicacion).OfType<Revista>())
			//						.Distinct()
			//						.ToList();
        }


		//DE YAPA PARA VER ALL
        public IEnumerable<Autor> GetAutoresQueSolamentePublicaronLibros()
        {
			return Contexto.Autores
							.Where(autor => autor.AutoresPublicaciones.All(ap => ap.Publicacion is Libro))
							.ToList();
        }
    }
}
