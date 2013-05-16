using System;
using System.Diagnostics;


namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	public class Quote
	{
		/*
		 * DisplayTypes:
		 0: "Automatic" Not used 
		1: "0 Decimals" => 1 
		2: "1 Decimals" => .1 
		3: "2 Decimals" => .01 
		4: "3 Decimals" => .001 
		5: "4 Decimals" => .0001 
		6: "5 Decimals" => .00001 
		7: "Simplest Fraction" 
		8: "1/2-Halves" => .5 
		9: "1/4-Fourths" => .25 
		10: "1/8-Eights" => .125 
		11: "1/16-Sixteenths" => .0625 
		12: "1/32-ThirtySeconds" => .03125 
		13: "1/64-SixtyFourths" => .015625 
		14: "1/128-OneTwentyEigths" => .0078125 
		15: "1/256-TwoFiftySixths" => .003906250 
		16: "10ths and Quarters" => .025 
		17: "32nds and Halves" => .015625 
		18: "32nds and Quarters" => .0078125 
		19: "32nds and Eights" => .00390625 
		20: "32nds and Tenths" => .003125 
		21: "64ths and Halves" => .0078125 
		22: "64ths and Tenths" => .0015625 
		23: "6 Decimals" => .000001 
		 */

		public decimal Ask { get; set; }
		public string AskPriceDisplay { get; set; }
		//public bool AskSpecified { get; set; }
		public int AskSize { get; set; }
		//public bool AskSizeSpecified { get; set; }
		public AssetType AssetType { get; set; }
		public decimal Bid { get; set; }
		public string BidPriceDisplay { get; set; }
		//public bool BidSpecified { get; set; }
		public int BidSize { get; set; }
		//public bool BidSizeSpecified { get; set; }
		public decimal Close { get; set; }
		public string ClosePriceDisplay { get; set; }
		public string CountryCode { get; set; }
		public string Currency { get; set; }
		public int DailyOpenInterest { get; set; }
		public string Description { get; set; }
		public int DisplayType { get; set; }
		//public bool DisplayTypeSpecified { get; set; }
		public string Error { get; set; }
		public string Exchange { get; set; }
		public bool FractionalDisplay { get; set; }
		//public bool FractionalDisplaySpecified { get; set; }
		public decimal High { get; set; }
		public bool HighSpecified { get; set; }
		public decimal High52Week { get; set; }
		public string High52WeekPriceDisplay { get; set; }
		public string HighPriceDisplay { get; set; }
		//public bool High52WeekSpecified { get; set; }
		public decimal Last { get; set; }
		public string LastPriceDisplay { get; set; }
		//public bool LastSpecified { get; set; }
		public decimal Low { get; set; }
		//public bool LowSpecified { get; set; }
		public decimal Low52Week { get; set; }
		public string Low52WeekPriceDisplay { get; set; }
		public string LowPriceDisplay { get; set; }
		//public bool Low52WeekSpecified { get; set; }
		public decimal MinMove { get; set; }
		//public bool MinMoveSpecified { get; set; }
		public string NameExt { get; set; }
		public decimal NetChange { get; set; }
		public double NetChangePct { get; set; }
		public decimal Open { get; set; }
		public string OpenPriceDisplay { get; set; }
		//public bool OpenSpecified { get; set; }
		public decimal PointValue { get; set; }
		//public bool PointValueSpecified { get; set; }
		public decimal PreviousClose { get; set; }
		//public bool PreviousCloseSpecified { get; set; }
		public string PreviousClosePriceDisplay { get; set; }
		public int PreviousVolume { get; set; }
		//public bool PreviousVolumeSpecified { get; set; }
		public decimal? StrikePrice { get; set; }
		//public bool StrikePriceSpecified { get; set; }
		public string StrikePriceDisplay { get; set; }
		public string Symbol { get; set; } //   
		public string SymbolRoot { get; set; } 
		public int Volume { get; set; }
		//public bool VolumeSpecified { get; set; }
		public static Quote Empty { get { return new Quote(); } }
		#region overloads and overrides

		[DebuggerStepThrough()]
		public static bool operator ==(Quote lhs, Quote rhs)
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Ask == rhs.Ask &&
			       //lhs.AskSizeSpecified == rhs.AskSizeSpecified &&
			       lhs.AskSize == rhs.AskSize &&
			       lhs.AskPriceDisplay == rhs.AskPriceDisplay &&
			       //lhs.AskSpecified == rhs.AskSpecified &&
			       lhs.AssetType == rhs.AssetType &&
			       lhs.Bid == rhs.Bid &&
			       lhs.BidPriceDisplay == rhs.BidPriceDisplay &&
			       lhs.BidSize == rhs.BidSize &&
			       //lhs.BidSizeSpecified == rhs.BidSizeSpecified &&
			       //lhs.BidSpecified == rhs.BidSpecified &&
			       lhs.Close == rhs.Close &&
			       lhs.ClosePriceDisplay == rhs.ClosePriceDisplay &&
			       lhs.CountryCode == rhs.CountryCode &&
			       lhs.Currency == rhs.Currency &&
			       lhs.DailyOpenInterest == rhs.DailyOpenInterest &&
			       lhs.Description == rhs.Description &&
			       lhs.DisplayType == rhs.DisplayType &&
			       //lhs.DisplayTypeSpecified == rhs.DisplayTypeSpecified &&  
			       lhs.Error == rhs.Error &&
			       lhs.Exchange == rhs.Exchange &&
			       lhs.FractionalDisplay == rhs.FractionalDisplay &&
			       //lhs.FractionalDisplaySpecified == rhs.FractionalDisplaySpecified &&
			       lhs.High == rhs.High &&
			       lhs.High52Week == rhs.High52Week &&
			       lhs.High52WeekPriceDisplay == rhs.High52WeekPriceDisplay &&
			       //lhs.High52WeekSpecified == rhs.High52WeekSpecified &&
			       lhs.HighPriceDisplay == rhs.HighPriceDisplay &&
			       lhs.HighSpecified == rhs.HighSpecified &&
			       lhs.Last == rhs.Last &&
			       lhs.LastPriceDisplay == rhs.LastPriceDisplay &&
			       //lhs.LastSpecified == rhs.LastSpecified &&
			       lhs.Low == rhs.Low &&
			       lhs.Low52Week == rhs.Low52Week &&
			       lhs.Low52WeekPriceDisplay == rhs.Low52WeekPriceDisplay &&
			       //lhs.Low52WeekSpecified == rhs.Low52WeekSpecified &&
			       lhs.LowPriceDisplay == rhs.LowPriceDisplay &&
			       //lhs.LowSpecified == rhs.LowSpecified &&
			       lhs.MinMove == rhs.MinMove &&
			       //lhs.MinMoveSpecified == rhs.MinMoveSpecified &&
			       lhs.NameExt == rhs.NameExt &&
			       lhs.NetChange == rhs.NetChange &&
			       Math.Abs(lhs.NetChangePct - rhs.NetChangePct) < .001 &&
			       lhs.Open == rhs.Open &&
			       lhs.OpenPriceDisplay == rhs.OpenPriceDisplay &&
			       //lhs.OpenSpecified == rhs.OpenSpecified &&
			       lhs.PointValue == rhs.PointValue &&
			       //lhs.PointValueSpecified == rhs.PointValueSpecified &&
			       lhs.PreviousClose == rhs.PreviousClose &&
			       lhs.PreviousClosePriceDisplay == rhs.PreviousClosePriceDisplay &&
			       //lhs.PreviousCloseSpecified == rhs.PreviousCloseSpecified &&
			       lhs.PreviousVolume == rhs.PreviousVolume &&
			       //lhs.PreviousVolumeSpecified == rhs.PreviousVolumeSpecified &&
			       lhs.StrikePrice == rhs.StrikePrice &&
			       lhs.StrikePriceDisplay == rhs.StrikePriceDisplay &&
			       //lhs.StrikePriceSpecified == rhs.StrikePriceSpecified &&
			       lhs.Symbol == rhs.Symbol &&
			       lhs.SymbolRoot == rhs.SymbolRoot &&
			       lhs.Volume == rhs.Volume;
			//lhs.VolumeSpecified == rhs.VolumeSpecified;
		}

		[DebuggerStepThrough()]
		public static bool operator !=(Quote lhs, Quote rhs)
		{
			return !(lhs == rhs);
		}

		[DebuggerStepThrough()]
		public bool Equals(Quote token)
		{
			return this == token;
		}

		[DebuggerStepThrough()]
		public override bool Equals(object obj)
		{
			return Equals(obj as Quote);
		}

		[DebuggerStepThrough()]
		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		[DebuggerStepThrough()]
		public override string ToString()
		{
			return string.Format("{0}({7}) Bid: {1} Ask: {2} Last: {3} Open: {4} Close: {5} PreviousClose: {6}", Symbol, BidPriceDisplay, AskPriceDisplay, LastPriceDisplay, OpenPriceDisplay, ClosePriceDisplay, PreviousClosePriceDisplay, Exchange);
		}

		#endregion overloads and overrides

	}
	
}
