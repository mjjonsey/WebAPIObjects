using System.Diagnostics;

namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	public class AccountInfo
	{
		public int Key { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public string TypeDescription { get; set; }
        public static AccountInfo Empty { get { return new AccountInfo(); } }

        #region overloads and overrides

        [DebuggerStepThrough()]
        public static bool operator ==(AccountInfo lhs, AccountInfo rhs)
        {
	        if (ReferenceEquals(lhs, rhs))
                return true;
	        if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
		        return false;
	        return lhs.Key == rhs.Key && 
	               lhs.Name == rhs.Name && 
	               lhs.Type == rhs.Type && 
	               lhs.TypeDescription == rhs.TypeDescription;
        }

		[DebuggerStepThrough()]
        public static bool operator !=(AccountInfo lhs, AccountInfo rhs)
        {
            return !(lhs == rhs);
        }

        [DebuggerStepThrough()]
        public bool Equals(AccountInfo token)
        {
            return this == token;
        }

        [DebuggerStepThrough()]
        public override bool Equals(object obj)
        {
            return Equals(obj as AccountInfo);
        }

        [DebuggerStepThrough()]
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        [DebuggerStepThrough()]
        public override string ToString()
        {
            return string.Format("AccountInfo {0} {1} {2}", Name, Key, Type);
        }

        #endregion overloads and overrides
	}
}
