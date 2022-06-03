using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Dominio.EntidadesNegocio
{
	public class Libro:Publicacion
	{        
        public string ISBN { get; set; } //International Standard Book Number , 13 dígitos
		public string Titulo { get; set; }
	}
}
