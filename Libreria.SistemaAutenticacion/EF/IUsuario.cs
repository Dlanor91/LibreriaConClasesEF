using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaAutenticacion.EF
{
	public interface IUsuario
	{
		public int Id { get; set; }
		public string Email { get; set; }
	
		public bool Login(string email, string password);
		public bool ValidarPwd(string pwd);
		public bool ValidarEmail(string email);
		public string EncriptarPwd(string emailSinEncriptar);
	}
}
