using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria.Dominio.EntidadesNegocio.Configuraciones
{
	/// <summary>
	/// Guarda valores para distintas configuraciones del sistema, por ejemplo nombre de la empresa, misión, visión, etc.
	/// </summary>
	public class InformacionSistema
	{
		[Key]
		public string NombreConfiguracion { get; set; }
		public string ValorConfiguracion { get; set; }
	}
}
