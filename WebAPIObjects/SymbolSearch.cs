using System;
using System.Text;

namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	public static class SymbolSearch 
	{
		private static AssetClass GetAssetType(SearchCategory category)
		{
			if (category.ToString().EndsWith("Option")) 
				return AssetClass.Option; 
			
			if(category == SearchCategory.Future || category == SearchCategory.FutureRoot)
				return AssetClass.Future; 

			if (category == SearchCategory.Forex)
				return AssetClass.Forex; 

			return AssetClass.Equity;
		}

		private static void Append(StringBuilder existing, string value) 
		{
			if (existing.Length > 0) existing.Append("&"); 
			existing.Append(value); 
		}

		public static string GetEquitySearchCriteria(SearchCategory category = SearchCategory.None, CountryCode country = CountryCode.ALL, string name = "", 
			string description = "", bool includeNoLongerTrading = false) 
		{
			if (GetAssetType(category) != AssetClass.Equity) throw new ArgumentException("Invalid SearchCategory for Equity search: " + category.ToString(), "category"); 

			StringBuilder criteria = new StringBuilder();
			if (category != SearchCategory.None) Append(criteria, "c=" + category.ToString());
			if (name != string.Empty) Append(criteria, "n=" + name); 
			if (description != string.Empty) Append(criteria, "desc=" + description); 
			if (includeNoLongerTrading) Append(criteria, "Flg=true"); 
			if (country != CountryCode.ALL) Append(criteria, string.Format("cnt={0}", country)); 

			return criteria.ToString(); 
		}

		/// <summary>
		/// Private method which exposes all possible parameters, with default values for the optional ones.
		/// </summary>
		/// <param name="category">Category=StockOption, IndexOption, FutureOption or CurrencyOption</param>
		/// <param name="symbolRoot">Symbol root. Required Field, the symbol the option is a derivative of, this search will not return options based on a partial root.</param>
		/// <param name="strikeCount">Number of strikes prices above and below the underlying price. Defaults to 3. Ignored if strike price high and low are passed.</param>
		/// <param name="strikePriceLow">Strike price low</param>
		/// <param name="strikePriceHigh">Strike price high</param>
		/// <param name="dateCount">Number of expiration dates. Default value 3. Ignored if expiration dates high and low are passed.</param>
		/// <param name="expirationDateLow">Expiration date low</param>
		/// <param name="expirationDateHigh">Expiration date high</param>
		/// <param name="optionType">Option type (Both, Call, Put) Default: Both</param>
		/// <param name="futureType">Future type (Electronic, Pit) Default: Electronic</param>
		/// <param name="symbolType">SymbolType (Both, Composite, Regional) Default: Composite</param>
		/// <param name="country">Country code (US, DE, CA) Default: US</param>
		/// <returns></returns>
		public static string GetOptionSearchCriteria(SearchCategory category, string symbolRoot,
			uint strikeCount = 3, decimal strikePriceLow = 0, decimal strikePriceHigh = decimal.MaxValue, 
			uint dateCount = 3, DateTime? expirationDateLow = null, DateTime? expirationDateHigh = null,
			OptionType optionType = OptionType.Both, 
			FutureType futureType = FutureType.Electronic, SymbolType symbolType = SymbolType.Composite, CountryCode country = CountryCode.US) 
		{
			if (string.IsNullOrEmpty(symbolRoot)) throw new ArgumentException("symbolRoot is required.", "symbolRoot"); 
			if (GetAssetType(category) != AssetClass.Option) throw new ArgumentException("SearchCategory must be StockOption, IndexOption, FutureOption or CurrencyOption", "category"); 
			if (strikePriceLow < 0) throw new ArgumentOutOfRangeException("strikePriceLow", "Argument cannot be less than 0."); 
			if (strikePriceHigh < 0) throw new ArgumentOutOfRangeException("strikePriceHigh", "Argument cannot be less than 0."); 
			if ((expirationDateLow.HasValue && !expirationDateHigh.HasValue) || (expirationDateHigh.HasValue && !expirationDateLow.HasValue)) throw new ArgumentException("If either expiration date parameter is passed, both must be passed.");
			if (expirationDateHigh.HasValue && expirationDateLow.HasValue && expirationDateHigh < expirationDateLow) throw new ArgumentOutOfRangeException("expirationDateHigh", "expirationDateHigh cannot be before expirationDateLow."); 
			

			StringBuilder criteria = new StringBuilder(255); 
			Append(criteria, "c=" + category.ToString());
			Append(criteria, "R=" + symbolRoot); 
			// strike price range takes precidence over strike count
			if (strikePriceLow > 0 && strikePriceHigh < decimal.MaxValue)
			{
				Append(criteria, "Spl=" + strikePriceLow);
				Append(criteria, "Sph=" + strikePriceHigh);
			}
			else if (strikeCount != 3)
				Append(criteria, "Stk=" + strikeCount); 
			
			// daterange takes precidence over datacount
			if (expirationDateLow.HasValue)
			{
				Append(criteria, "Edl=" + ((DateTime)expirationDateLow).ToString("MM-dd-yyyy"));
				Append(criteria, "Edh=" + ((DateTime)expirationDateHigh).ToString("MM-dd-yyyy")); 
			}
			else if (dateCount != 3) 
				Append(criteria, "Exd=" + dateCount); 

			if (optionType != OptionType.Both) Append(criteria, "OT=" + optionType.ToString()); 
			if (futureType != FutureType.Electronic) Append(criteria, "FT=" + futureType.ToString()); 
			if (symbolType != SymbolType.Composite) Append(criteria, "ST=" + symbolType.ToString()); 
			if (country != CountryCode.US) Append(criteria, "Cnt=" + country.ToString()); 

			return criteria.ToString(); 
		}

		public static string GetForexSearchCriteria(string name = "", string description = "") 
		{
			// category is always forex.. no need for additional param
			StringBuilder criteria = new StringBuilder(255); 
			criteria.Append("c=forex");
			if (name != string.Empty) Append(criteria, "n=" + name); 
			if (description != string.Empty) Append(criteria, "desc=" + description); 

			return criteria.ToString(); 
		}

		public static string GetFutureSearchCriteria(string description = "", string root = "", FutureType futureType = FutureType.Electronic, 
			Currency currency = Currency.USD, bool includeExpired = false, CountryCode country = CountryCode.ALL)
		{
			StringBuilder criteria = new StringBuilder(255); 
			Append(criteria, "c=" + SearchCategory.Future.ToString());
			if (description != string.Empty) Append(criteria, "desc=" + description); 
			if (root != string.Empty) Append(criteria, "r=" + root); 
			if (futureType != FutureType.Electronic) Append(criteria, "FT=" + futureType.ToString()); 
			if (currency != Currency.USD) Append(criteria, "Cur=" + currency.ToString()); 
			if (includeExpired) Append(criteria, "Exp=true");
			if (country != CountryCode.ALL) Append(criteria, "Cnt=" + country.ToString()); 

			return criteria.ToString(); 
		}
	}

	internal enum AssetClass
	{
		Equity, 
		Option, 
		Future, 
		Forex
	}

	public enum SearchCategory
	{
		None,
		Future, 
		FutureOption,
		Stock, 
		StockOption, 
		Index, 
		CurrencyOption, 
		MutualFund, 
		MoneyMarketFund, 
		IndexOption, 
		Bond, 
		Forex,
		FutureRoot
	}

	// ReSharper disable InconsistentNaming
	public enum CountryCode
	{ 
		ALL, 
		US, 
		DE, 
		CA, 
		JP
	}
	// ReSharper restore InconsistentNaming

	public enum OptionType
	{
		Both = 1, 
		Call = 3, 
		Put = 2, 
		NA = 0
	}

	public enum FutureType
	{
		None,
		Electronic, 
		Pit,
		Combined
	}

	public enum SymbolType
	{
		Both, 
		Composite, 
		Regional
	}
}
