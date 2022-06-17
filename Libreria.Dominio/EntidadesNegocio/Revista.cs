using System;
using System.Collections.Generic;
using System.Text;
using Libreria.Dominio.InterfacesEntidades;

namespace Libreria.Dominio.EntidadesNegocio
{
	public class Revista : Publicacion, IValidable
	{
		public int Numero { get; set; }
		public int Anio { get; set; }
		public string TablaContenido { get; set; }

		public bool Validar()
		{
			return true; //PENDIENTE
		}
	}
}
