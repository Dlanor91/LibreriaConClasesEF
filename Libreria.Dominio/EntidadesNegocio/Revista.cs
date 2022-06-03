using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Dominio.EntidadesNegocio
{
	public class Revista:Publicacion
	{
		public int Numero { get; set; }
		public int Anio { get; set; }
		public string TablaContenido { get; set; }
	}
}
