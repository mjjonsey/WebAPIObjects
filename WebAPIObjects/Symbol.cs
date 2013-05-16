using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	public class Symbol
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Exchange { get; set; }
		public string Category { get; set; }
		public CountryCode Country { get; set; }
		public string Root { get; set; }
		public OptionType OptionType { get; set; }
		public FutureType FutureType { get; set; }
		public DateTime? ExpirationDate { get; set; }
		public decimal StrikePrice { get; set; }
		public string Error { get; set; }
		public Currency Currency { get; set; }

		public static Symbol Empty { get { return new Symbol(); } }
		#region overloads and overrides

		[DebuggerStepThrough()]
		public static bool operator ==(Symbol lhs, Symbol rhs)
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Category == rhs.Category &&
				   lhs.Country == rhs.Country &&
				   lhs.Currency == rhs.Currency &&
				   lhs.Description == rhs.Description &&
				   lhs.Error == rhs.Error &&
				   lhs.Exchange == rhs.Exchange &&
				   lhs.ExpirationDate == rhs.ExpirationDate &&
				   lhs.Name == rhs.Name &&
				   lhs.Root == rhs.Root &&
				   lhs.StrikePrice == rhs.StrikePrice &&
				   lhs.OptionType == rhs.OptionType &&
				   lhs.FutureType == rhs.FutureType;
		}

		[DebuggerStepThrough()]
		public static bool operator !=(Symbol lhs, Symbol rhs)
		{
			return !(lhs == rhs);
		}

		[DebuggerStepThrough()]
		public bool Equals(Symbol token)
		{
			return this == token;
		}

		[DebuggerStepThrough()]
		public override bool Equals(object obj)
		{
			Symbol token = obj as Symbol;
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
			return string.Format("{0}: {1} ({2})", Name, Description, Exchange);
		}

		#endregion overloads and overrides

	}

	/// <summary>
	/// Comparer for sorting options. Options sort by call/put (calls first), then expiration, then strike
	/// </summary>
	public class OptionComparer : IComparer<Symbol>
	{
		/// <summary>
		/// Options sort by call/put (calls first), then expiration, then strike
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public int Compare(Symbol x, Symbol y)
		{
			int result = x.OptionType.CompareTo(y.OptionType);
			if (result == 0)
			{
				if (x.ExpirationDate.HasValue && y.ExpirationDate.HasValue)
					result = ((DateTime)x.ExpirationDate).CompareTo((DateTime)y.ExpirationDate);
				else
				{
					result = x.ExpirationDate.HasValue ? 1 : -1;
				}
			}
			if (result == 0) result = x.StrikePrice.CompareTo(y.StrikePrice);

			return result;
		}
	}
}
