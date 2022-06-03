using System;
using System.Collections.Generic;
using System.Text;
using Libreria.Dominio.EntidadesNegocio;
using Libreria.Dominio.InterfacesRepositorios;

namespace AccesoDatos.EF
{
	class RepositorioAutor : IRepositorioAutor
	{
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
	}
}
