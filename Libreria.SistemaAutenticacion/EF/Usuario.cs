using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace SistemaAutenticacion.EF
{
	class Usuario : IUsuario
	{
		public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string Email { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		private string Password {   get => throw new NotImplementedException();   set => throw new NotImplementedException(); }
		private string	PasswordEncriptada { get; set; }
		public Usuario(string email, string password)
		{
			Email = email;
			Password = password;
		}
		public string EncriptarPwd(string emailSinEncriptar)
		{
			throw new NotImplementedException();
		}

		public bool Login(string email, string password)
		{
			throw new NotImplementedException();
		}

		public bool ValidarEmail(string email)
		{
			throw new NotImplementedException();
		}

		public bool ValidarPwd(string pwd)
		{
			throw new NotImplementedException();
		}
	}
}
