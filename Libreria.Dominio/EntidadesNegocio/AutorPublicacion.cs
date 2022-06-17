using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria.Dominio.EntidadesNegocio
{
    public class AutorPublicacion
    {
        public int Id { get; set; }
        public Autor Autor { get; set; }
        public Publicacion Publicacion { get; set; }
        
        //[ForeignKey("Autor")]
        public int AutorId { get; set; }

        //[ForeignKey("Publicacion")]
        public int PublicacionId { get; set; }
    }
}
