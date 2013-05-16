using System.Diagnostics;


namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	public class AccessToken
	{
		#region properties
		public string ExpiresIn { get; set; }
		public string Token { get; set; }
		public string UserId { get; set; }
		public string Type { get; set; }	// Added in V2

		public static AccessToken Empty { get { return new AccessToken(); } }
		#endregion properties

		#region overloads and overrides

		[DebuggerStepThrough()]
		public static bool operator ==(AccessToken lhs, AccessToken rhs)
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;

			return lhs.ExpiresIn == rhs.ExpiresIn &&
			       lhs.Token == rhs.Token &&
			       lhs.UserId == rhs.UserId && 
			       lhs.Type == rhs.Type;
		}

		[DebuggerStepThrough()]
		public static bool operator !=(AccessToken lhs, AccessToken rhs)
		{
			return !(lhs == rhs);
		}

		[DebuggerStepThrough()]
		public bool Equals(AccessToken token)
		{
			return this == token;
		}

		[DebuggerStepThrough()]
		public override bool Equals(object obj)
		{
			AccessToken token = obj as AccessToken;
			if (token != null)
				return Equals(token);
			
			return false;
		}

		[DebuggerStepThrough()]
		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		[DebuggerStepThrough()]
		public override string ToString()
		{
			return string.Format("Access Token for {0}: {1}", UserId, Token);
		}

		#endregion overloads and overrides
	}

	
}
