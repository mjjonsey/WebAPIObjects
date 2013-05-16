using System.Diagnostics;

namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	public class ClosedPosition
	{
		public Currency Currency { get; set; }
		public string Profit { get; set; }
		public string Symbol { get; set; }
        public static ClosedPosition Empty { get { return new ClosedPosition(); } }

        #region overloads and overrides

        [DebuggerStepThrough()]
        public static bool operator ==(ClosedPosition lhs, ClosedPosition rhs)
        {
	        if (ReferenceEquals(lhs, rhs))
                return true;
	        if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
		        return false;
	        return lhs.Currency == rhs.Currency && 
	               lhs.Profit == rhs.Profit && 
	               lhs.Symbol == rhs.Symbol;
        }

		[DebuggerStepThrough()]
        public static bool operator !=(ClosedPosition lhs, ClosedPosition rhs)
        {
            return !(lhs == rhs);
        }

        [DebuggerStepThrough()]
        public bool Equals(ClosedPosition token)
        {
            return this == token;
        }

        [DebuggerStepThrough()]
        public override bool Equals(object obj)
        {
            return Equals(obj as ClosedPosition);
        }

        [DebuggerStepThrough()]
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        [DebuggerStepThrough()]
        public override string ToString()
        {
            return string.Format("Closed Position {0} Profit: {1} {2}", Symbol, Profit, Currency.ToString());
        }

        #endregion overloads and overrides
	}
}
