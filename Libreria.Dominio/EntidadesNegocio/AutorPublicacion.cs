using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria.Dominio.EntidadesNegocio
{
    public class AutorPublicacion
    {
        public int Id { get; set; }
        public Autor Autor { get; set; }
        public Publicacion Publicacion { get; set; }

        //agrego pro por los id de las key
        [ForeignKey("Autor")]
        public int AutorId { get; set; } 
        [ForeignKey("Publicacion")]
        public int PublicacionId { get; set; }
    }
}
