using System;
using System.Collections.Generic;
using System.Text;
using Libreria.Dominio.EntidadesNegocio;

namespace Libreria.Dominio.InterfacesRepositorios
{
	public interface IRepositorioAutor
		:IRepositorio<Autor>
	{
		public IEnumerable<Autor> GetAutoresNacionalidad(string nacionalidad);
		public IEnumerable<Autor> GetAutoresNombreIncluye(string textoBuscado);

		public IEnumerable<Autor> GetAutoresConPublicacionesConMasDe(int paginas);

		public IEnumerable<Autor> GetAutoresQuePublicaronEnRevistas();

		public IEnumerable<Publicacion> GetPublicacionesDeAutor(int id);

		public IEnumerable<Libro> GetLibrosConVariosAutores();

		public IEnumerable<Revista> GetRevistasConAutoresDeLibros();

		public IEnumerable<Autor> GetAutoresQueSolamentePublicaronLibros();

    }
}
