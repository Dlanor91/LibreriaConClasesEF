using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria.Dominio.EntidadesNegocio.Configuraciones
{
	public class TopesTextos
	{
		[Key]
		public string NombreTope { get; set; }
		public string ValorTope { get; set; }
	}
}
