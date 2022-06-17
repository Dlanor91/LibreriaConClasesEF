using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Dominio.EntidadesNegocio
{
    public abstract class Publicacion
    {
        public DateTime FechaPublicado { get; set; }
        public int Id { get; set; }
        public int CantidadPaginas { get; set; }
        public int PrecioSugerido { get; set; }

        public IEnumerable<AutorPublicacion> AutoresPublicaciones { get; set; }
        //public IEnumerable<Autor> Autores { get; set; }
    }

}
