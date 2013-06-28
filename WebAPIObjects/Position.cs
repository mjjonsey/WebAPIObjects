using System;
using System.Collections.Generic;
using System.ComponentModel; 
using System.Diagnostics;

namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	public class Position
	{
		public string AccountId { get; set; }
		public decimal AccountMarketValue { get; set; }
		public decimal AccountTotalCost { get;set; }
		public decimal AccountOpenProfitLoss { get; set; }
		public decimal AskPrice { get; set; }
		public string AskPriceDisplay { get; set; }
		public AssetType AssetType { get; set; }
		public decimal AveragePrice { get; set; }
		public string AveragePriceDisplay { get; set; }
		public decimal BidPrice { get; set; }
		public string BidPriceDisplay { get; set; }
		public decimal BigPointValue { get; set; }
		public string ContractExpireDate { get; set; }
		public string ConversionRate { get; set; }
		public string Country { get; set; }
		public string Currency { get; set; }
		public string Description { get; set; }
		public decimal InitialMargin { get; set; }
		public int Key { get; set; }
		public decimal LastPrice { get; set; }
		public string LastPriceDisplay { get; set; }
		public string LongShort { get; set; }
		public decimal MaintenanceMargin { get; set; }
		public decimal MarketValue { get; set; }
		public decimal OpenProfitLoss { get; set; }
		public decimal OpenProfitLossPercent { get; set; }
		public decimal OpenProfitLossQty { get; set; }
		public int Quantity { get; set; }
		public decimal RequiredMargin { get; set; }
		public decimal SettlePrice { get; set; }
		public decimal StrikePrice { get; set; }
		public string StrikePriceDisplay { get; set; }
		public string Symbol { get; set; }
		public DateTime TimeStamp { get; set; }
		public decimal TotalCost { get; set; }
        public static Position Empty { get { return new Position(); } }
        #region overloads and overrides

        [DebuggerStepThrough()]
        public static bool operator ==(Position lhs, Position rhs)
        {
            if (ReferenceEquals(lhs, rhs))
                return true;
	        if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
		        return false;
	        return lhs.AccountId == rhs.AccountId &&
	               lhs.AccountMarketValue == rhs.AccountMarketValue && 
	               lhs.AccountTotalCost == rhs.AccountTotalCost && 
	               lhs.AccountOpenProfitLoss == rhs.AccountOpenProfitLoss && 
	               lhs.AskPrice == rhs.AskPrice && 
	               lhs.AskPriceDisplay == rhs.AskPriceDisplay && 
	               lhs.AssetType == rhs.AssetType && 
	               lhs.AveragePrice == rhs.AveragePrice && 
	               lhs.AveragePriceDisplay == rhs.AveragePriceDisplay && 
	               lhs.BidPrice == rhs.BidPrice && 
	               lhs.BidPriceDisplay == rhs.BidPriceDisplay && 
	               lhs.BigPointValue == rhs.BigPointValue && 
	               lhs.ContractExpireDate == rhs.ContractExpireDate && 
	               lhs.ConversionRate == rhs.ConversionRate && 
	               lhs.Country == rhs.Country && 
	               lhs.Currency == rhs.Currency && 
	               lhs.Description == rhs.Description && 
	               lhs.InitialMargin == rhs.InitialMargin && 
	               lhs.Key == rhs.Key && 
	               lhs.LastPrice == rhs.LastPrice && 
	               lhs.LastPriceDisplay == rhs.LastPriceDisplay && 
	               lhs.LongShort == rhs.LongShort && 
	               lhs.MaintenanceMargin == rhs.MaintenanceMargin && 
	               lhs.MarketValue == rhs.MarketValue && 
	               lhs.OpenProfitLoss == rhs.OpenProfitLoss && 
	               lhs.OpenProfitLossPercent == rhs.OpenProfitLossPercent && 
	               lhs.OpenProfitLossQty == rhs.OpenProfitLossQty && 
	               lhs.Quantity == rhs.Quantity && 
	               lhs.RequiredMargin == rhs.RequiredMargin && 
	               lhs.SettlePrice == rhs.SettlePrice && 
	               lhs.StrikePrice == rhs.StrikePrice && 
	               lhs.StrikePriceDisplay == rhs.StrikePriceDisplay && 
	               lhs.Symbol == rhs.Symbol && 
	               lhs.TimeStamp == rhs.TimeStamp && 
	               lhs.TotalCost == rhs.TotalCost;
        }

        [DebuggerStepThrough()]
        public static bool operator !=(Position lhs, Position rhs)
        {
            return !(lhs == rhs);
        }

        [DebuggerStepThrough()]
        public bool Equals(Position token)
        {
            return this == token;
        }

        [DebuggerStepThrough()]
        public override bool Equals(object obj)
        {
            return Equals(obj as Position);
        }

        [DebuggerStepThrough()]
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        [DebuggerStepThrough()]
        public override string ToString()
        {
            return string.Format("Position for Account {0} {1} {2} Bid: {3} Ask: {4}", AccountId, Symbol, Quantity, BidPrice, AskPrice);
        }

        #endregion overloads and overrides

	}

	/// <summary>
	/// Sort by tradedate, most recent first
	/// </summary>
	public class PositionDateComparer : IComparer<Position>
	{
		private ListSortDirection sortOrder;

		public PositionDateComparer(ListSortDirection sortOrder)
		{
			this.sortOrder = sortOrder; 
		}

		public int Compare(Position x, Position y)
		{
			switch(sortOrder)
			{
				case ListSortDirection.Ascending: 
					return x.TimeStamp.CompareTo(y.TimeStamp); 
				default:
					return y.TimeStamp.CompareTo(x.TimeStamp); 
			}
		}
	}

	public class PositionSymbolComparer : IComparer<Position>
	{

		public int Compare(Position x, Position y)
		{
			if (ReferenceEquals(x, null) && ReferenceEquals(y, null)) return 0;
			if (ReferenceEquals(x, null)) return -1;
			if (ReferenceEquals(y, null)) return 1;

			return String.Compare(x.Symbol, y.Symbol, StringComparison.Ordinal); 
		}
	}
}
