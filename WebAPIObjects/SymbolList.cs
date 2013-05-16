
namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	public class SymbolList
	{
		public string Id { get; set; }
		public string RootCategory { get; set; }
		public string Category { get; set; }
		public string SubCategory { get; set; }
		public string Name { get; set; }
		public string Path { get; set; }
		public static SymbolList Empty
		{
			get { return new SymbolList(); }
		}

		#region overloads and overrides

		public static bool operator ==(SymbolList lhs, SymbolList rhs)
		{
			if (ReferenceEquals(lhs, rhs)) return true;

			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null)) return false;

			return lhs.Id == rhs.Id &&
				   lhs.RootCategory == rhs.RootCategory &&
				   lhs.Category == rhs.Category &&
				   lhs.SubCategory == rhs.SubCategory &&
				   lhs.Name == rhs.Name &&
				   lhs.Path == rhs.Path;
		}

		public static bool operator !=(SymbolList lhs, SymbolList rhs)
		{
			return !(lhs == rhs);
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as SymbolList);
		}

		public bool Equals(SymbolList symbolList)
		{
			return this == symbolList;
		}

		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("Id: {0} RootCategory: {1} Category: {2} SubCategory: {3} Name: {4} Path: {5}", Id, RootCategory, Category, SubCategory, Name, Path);
		}

		#endregion overloads and overrides

	}
}
