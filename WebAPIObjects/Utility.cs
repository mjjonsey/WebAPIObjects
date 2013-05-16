using System.Collections.Generic;
using System.Linq;

namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	public class Utility
	{
		internal static bool ListsAreEqual<T>(List<T> lhs, List<T> rhs) 
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			if (lhs.Count != rhs.Count)
				return false;

			return !lhs.Where((t, i) => !t.Equals(rhs[i])).Any();
		}
	}
}
