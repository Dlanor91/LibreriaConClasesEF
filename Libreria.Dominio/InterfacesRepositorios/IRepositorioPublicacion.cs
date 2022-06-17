using System;
using System.Collections.Generic;
using System.Text;
using Libreria.Dominio.EntidadesNegocio;

namespace Libreria.Dominio.InterfacesRepositorios
{
    public interface IRepositorioPublicacion : IRepositorio<Publicacion>
    {
        IEnumerable<Publicacion> ObtenerlasPublicacionesDelAutor(int idAutor);
    }
}
