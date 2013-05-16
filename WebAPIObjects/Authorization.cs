using System;
using System.Diagnostics;

namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	public class Login
	{
		private Login()
		{
		}

		public Login(string userName, string password)
		{
			UserName = userName;
			Password = password;
		}

		public string UserName { get; set; }
		public string Password { get; set; }
		public static Login Empty { get { return new Login(); } }

		#region overloads and overrides

		[DebuggerStepThrough()]
		public static bool operator ==(Login lhs, Login rhs)
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Password == rhs.Password &&
				   lhs.UserName == rhs.UserName;
		}

		[DebuggerStepThrough()]
		public static bool operator !=(Login lhs, Login rhs)
		{
			return !(lhs == rhs);
		}

		[DebuggerStepThrough()]
		public bool Equals(Login token)
		{
			return this == token;
		}

		[DebuggerStepThrough()]
		public override bool Equals(object obj)
		{
			return Equals(obj as Login);
		}

		[DebuggerStepThrough()]
		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		[DebuggerStepThrough()]
		public override string ToString()
		{
			return string.Format("UserName: {0} Password: {1}", UserName, Password);
		}

		#endregion overloads and overrides
	
	}
}
