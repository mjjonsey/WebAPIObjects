using System.Diagnostics;

namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	[InitialVersion(WebApiVersion.V2)]
	public class TrailingStop
	{
		public bool ByPoints { get; set; }
		public int Value { get; set; }
		public static TrailingStop Empty { get { return new TrailingStop(); } }

		#region overloads and overrides

		[DebuggerStepThrough()]
		public static bool operator ==(TrailingStop lhs, TrailingStop rhs)
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			else if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			else
				return lhs.ByPoints == rhs.ByPoints &&
					lhs.Value == rhs.Value;
		}

		[DebuggerStepThrough()]
		public static bool operator !=(TrailingStop lhs, TrailingStop rhs)
		{
			return !(lhs == rhs);
		}

		[DebuggerStepThrough()]
		public bool Equals(TrailingStop token)
		{
			return this == token;
		}

		[DebuggerStepThrough()]
		public override bool Equals(object obj)
		{
			TrailingStop token = obj as TrailingStop;
			if (token != null)
				return this.Equals(token);
			else
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
			return string.Format("{0}: {1}", ByPoints ? "By Points" : "By Percentage", Value);
		}
		
		#endregion overloads and overrides
	}
}
