using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaDTO
{
    public class DTOPublicacion
    {
        public int Id { get; set; }
        public int CantidadPaginas { get; set; }

        public int Numero { get; set; }
        public int Anio { get; set; }

        public string Titulo { get; set; }

        public string NombresAutores { get; set; }
    }

}
