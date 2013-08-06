using System.Diagnostics;

namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	public class Error
	{
		public string StatusCode { get; set; }
		public string Message { get; set; }
        public static Error Empty { get { return new Error(); } }

        #region overloads and overrides

        [DebuggerStepThrough()]
        public static bool operator ==(Error lhs, Error rhs)
        {
	        if (ReferenceEquals(lhs, rhs))
                return true;
	        if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
		        return false;
	        return lhs.Message == rhs.Message && 
	               lhs.StatusCode == rhs.StatusCode;
        }

		[DebuggerStepThrough()]
        public static bool operator !=(Error lhs, Error rhs)
        {
            return !(lhs == rhs);
        }

        [DebuggerStepThrough()]
        public bool Equals(Error token)
        {
            return this == token;
        }

        [DebuggerStepThrough()]
        public override bool Equals(object obj)
        {
            return Equals(obj as Error);
        }

        [DebuggerStepThrough()]
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        [DebuggerStepThrough()]
        public override string ToString()
        {
            return string.Format("{0} {1}", StatusCode, Message);
        }

        #endregion overloads and overrides
	}
}
