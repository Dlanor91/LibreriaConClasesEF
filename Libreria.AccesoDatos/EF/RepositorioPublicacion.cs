using Libreria.Dominio.EntidadesNegocio;
using Libreria.Dominio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;
using Libreria.Dominio.InterfacesEntidades;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Libreria.AccesoDatos.EF
{
    public class RepositorioPublicacion : IRepositorioPublicacion
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioPublicacion(LibreriaContext ctx)
        {
            Contexto = ctx;
        }

        public bool Add(Publicacion obj)
        {
            Contexto.Publicaciones.Add(obj);
            return Contexto.SaveChanges()>1;
        }

        public IEnumerable<Publicacion> FindAll()
        {
            throw new NotImplementedException();
        }

        public Publicacion FindById(object Clave)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Publicacion> ObtenerlasPublicacionesDelAutor(int idAutor)
        {
            return Contexto.Publicaciones
                           .Include(p => p.AutoresPublicaciones)
                           .ThenInclude(ap => ap.Autor)
                           .Where(p => p.AutoresPublicaciones.Any(ap => ap.AutorId == idAutor))
                           .ToList();
        }

        public bool Remove(object Clave)
        {
            throw new NotImplementedException();
        }

        public bool Update(Publicacion obj)
        {
            throw new NotImplementedException();
        }
    }
}
