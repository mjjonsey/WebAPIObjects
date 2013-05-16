
namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	public class SymbolInfo
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Exchange { get; set; }

		public static SymbolInfo Empty
		{
			get { return new SymbolInfo(); }
		}

		#region overloads and overrides

		public static bool operator ==(SymbolInfo lhs, SymbolInfo rhs)
		{
			if (ReferenceEquals(lhs, rhs)) return true;

			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null)) return false;

			return lhs.Name == rhs.Name &&
				   lhs.Description == rhs.Description &&
				   lhs.Exchange == rhs.Exchange;
		}

		public static bool operator !=(SymbolInfo lhs, SymbolInfo rhs)
		{
			return !(lhs == rhs);
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as SymbolInfo);
		}

		public bool Equals(SymbolInfo symbolList)
		{
			return this == symbolList;
		}

		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("Name: {0} Description: {1} Exchange: {2}", Name, Description, Exchange);
		}

		#endregion overloads and overrides
	}
}
