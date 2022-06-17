using System;
using System.Collections.Generic;
using System.Text;
using Libreria.Dominio.InterfacesEntidades;

namespace Libreria.Dominio.EntidadesNegocio
{
	public class Libro : Publicacion, IValidable
	{        
        public string ISBN { get; set; } //International Standard Book Number , 13 dígitos
		public string Titulo { get; set; }

        public bool Validar()
        {
            return true; //PENDIENTE
        }
    }
}
