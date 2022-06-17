using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Libreria.AccesoDatos.EF;
using Libreria.Dominio.EntidadesNegocio;
using Libreria.Dominio.InterfacesRepositorios;

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
			return Contexto.Autores.ToList();
		}

		public Autor FindById(object Clave)
		{
			throw new NotImplementedException();
		}

        public IEnumerable<Autor> GetAutoresConPublicacionesMasQue(int paginas)
        {
            return Contexto.Autores.Where(autor => autor.AutoresPublicaciones
                                                        .Any(ap => ap.Publicacion.CantidadPaginas > paginas))
                                   .ToList();


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

        public IEnumerable<Autor> GetAutoresQuePublicaronEnRevistas()
        {
			return Contexto.Autores.Where(autor => autor.AutoresPublicaciones
														.Any(ap => ap.Publicacion is Revista))
								   .ToList();
		}

        public IEnumerable<Libro> GetLibrosConVariosAutores()
        {
			return Contexto.Publicaciones
						   .Where(pub => pub.AutoresPublicaciones.Count() > 1)
						   .OfType<Libro>();
        }

        public IEnumerable<Publicacion> GetPublicacionesDeAutor(int id)
        {
			return Contexto.Publicaciones.Where(pub => pub.AutoresPublicaciones
														  .Any(ap => ap.Autor.Id == id) && pub.AutoresPublicaciones.Count() >1)
										  .ToList();
        }

        public IEnumerable<Revista> GetRevistasConAutoresDeLibro()
        {
			return Contexto.Revistas
						   .Where(rev => rev.AutoresPublicaciones
											 .Any(ap => ap.Autor.AutoresPublicaciones
																.Any(ap => ap.Publicacion is Libro)))
						   .ToList();
        }

        public IEnumerable<Autor> GetAutoresQueSolamentePublicaronLibros()
        {
			return Contexto.Autores
						   .Where(autor => autor.AutoresPublicaciones.All(ap => ap.Publicacion is Libro))
						   .ToList();
        }
    }
}
