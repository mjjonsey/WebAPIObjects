using System.Collections.Generic;
using System.Diagnostics;


namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	// TODO: Consider changing the name of this to AccountBalance
	public class Account
	{
		public static Account Empty { get { return new Account(); } }
// ReSharper disable InconsistentNaming
		public decimal BODEquity { get; set; }
// ReSharper restore InconsistentNaming
// ReSharper disable InconsistentNaming
		public decimal BODNetCash { get; set; }
// ReSharper restore InconsistentNaming
		public int Key { get; set; }
		public decimal MarketValue { get; set; }
		public string Name { get; set; }
		public decimal RealTimeBuyingPower { get; set; }
		public decimal RealTimeEquity { get; set; }
		public decimal RealTimeAccountBalance { get; set; }
		public decimal RealTimeRealizedProfitLoss { get; set; }
		public decimal RealTimeUnrealizedGains { get; set; }
		public decimal RealTimeUnrealizedProfitLoss { get; set; }
		public string Status { get; set; }
		public string StatusDescription { get; set; }
		public string Type { get; set; }
		public string TypeDescription { get; set; }
		public string UnclearedDeposit { get; set; }

		public List<ClosedPosition> ClosedPositions { get; private set; }

		public Account()
		{
			ClosedPositions = new List<ClosedPosition>(255);
		}      

        #region overloads and overrides

        [DebuggerStepThrough()]
        public static bool operator ==(Account lhs, Account rhs)
        {
	        if (ReferenceEquals(lhs, rhs))
                return true;
	        if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
		        return false;

	        return lhs.BODEquity == rhs.BODEquity &&
	               lhs.BODNetCash == rhs.BODNetCash &&
	               Utility.ListsAreEqual(lhs.ClosedPositions, rhs.ClosedPositions) &&
	               lhs.Key == rhs.Key &&
	               lhs.MarketValue == rhs.MarketValue &&
	               lhs.Name == rhs.Name &&
	               lhs.RealTimeAccountBalance == rhs.RealTimeAccountBalance &&
	               lhs.RealTimeBuyingPower == rhs.RealTimeBuyingPower &&
	               lhs.RealTimeEquity == rhs.RealTimeEquity &&
	               lhs.RealTimeRealizedProfitLoss == rhs.RealTimeRealizedProfitLoss &&
	               lhs.RealTimeUnrealizedGains == rhs.RealTimeUnrealizedGains &&
	               lhs.RealTimeUnrealizedProfitLoss == rhs.RealTimeUnrealizedProfitLoss &&
	               lhs.Status == rhs.Status &&
	               lhs.StatusDescription == rhs.StatusDescription &&
	               lhs.Type == rhs.Type &&
	               lhs.TypeDescription == rhs.TypeDescription &&
	               lhs.UnclearedDeposit == rhs.UnclearedDeposit;
        }

		[DebuggerStepThrough()]
        public static bool operator !=(Account lhs, Account rhs)
        {
            return !(lhs == rhs);
        }

        [DebuggerStepThrough()]
        public bool Equals(Account token)
        {
            return this == token;
        }

        [DebuggerStepThrough()]
        public override bool Equals(object obj)
        {
	        Account token = obj as Account;
	        return Equals(token);
        }

		[DebuggerStepThrough()]
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        [DebuggerStepThrough()]
        public override string ToString()
        {
            return string.Format("Account {0}", Key);
        }
        
        #endregion overloads and overrides
    }

	public class ForexAccount : Account
	{
// ReSharper disable InconsistentNaming
		public decimal BODMarginRequirement { get; set; }
// ReSharper restore InconsistentNaming
		public Currency Currency { get; set; }
		public List<ForexAccountCurrencyDetail> CurrencyDetails { get; private set; }
		public decimal RealTimeMarginRequirement { get; set; }
        public static new ForexAccount Empty { get { return new ForexAccount(); } }

		public ForexAccount()
		{
			CurrencyDetails = new List<ForexAccountCurrencyDetail>(255);
		}

        #region overloads and overrides

        //[DebuggerStepThrough()]
        public static bool operator ==(ForexAccount lhs, ForexAccount rhs)
        {
	        if (ReferenceEquals(lhs, rhs))
                return true;
	        if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
		        return false;

	        return  lhs == (Account)rhs && 
	                lhs.BODMarginRequirement == rhs.BODMarginRequirement &&
	                lhs.Currency == rhs.Currency &&
	                Utility.ListsAreEqual(lhs.CurrencyDetails, rhs.CurrencyDetails) && 
	                lhs.RealTimeMarginRequirement == rhs.RealTimeMarginRequirement;
        }

		[DebuggerStepThrough()]
        public static bool operator !=(ForexAccount lhs, ForexAccount rhs)
        {
            return !(lhs == rhs);
        }

        [DebuggerStepThrough()]
        public bool Equals(ForexAccount token)
        {
            return this == token;
        }

        [DebuggerStepThrough()]
        public override bool Equals(object obj)
        {
            ForexAccount token = obj as ForexAccount;
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
            return string.Format("Forex Account {0}", Key);
        }

        #endregion overloads and overrides
	}

	public class EquityAccount : Account
	{
		//public string __type { get; set; }
		//public string Alias { get; set; }
		public decimal BODDayTradingMarginableEquitiesBuyingPower { get; set; }
		public decimal BODOptionBuyingPower { get; set; }
		public decimal BODOptionValue { get; set; }
		public decimal BODOvernightBuyingPower { get; set; }
		public bool CanDayTrade { get; set; }
		public decimal Commission { get; set; }
		public decimal Brokerage { get; set; }
		public int DayTrades { get; set; }
		public bool DayTradingQualified { get; set; }
		public int OptionApprovalLevel { get; set; }
		public bool PatternDayTrader { get; set; }
		public decimal RealTimeCostOfPositions { get; set; }
		public decimal RealTimeDayTradingMarginableEquitiesBuyingPower { get; set; }
		public decimal RealTimeOptionBuyingPower { get; set; }
		public decimal RealTimeOvernightBuyingPower { get; set; }
		public decimal RealTimeOptionValue { get; set; }
		public decimal UnsettledFund { get; set; }
        public static new EquityAccount Empty { get { return new EquityAccount(); } }

        #region overloads and overrides

        [DebuggerStepThrough()]
        public static bool operator ==(EquityAccount lhs, EquityAccount rhs)
        {
	        if (ReferenceEquals(lhs, rhs))
                return true;
	        if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
		        return false;
	        return lhs == (Account)rhs && 
	               lhs.BODDayTradingMarginableEquitiesBuyingPower == rhs.BODDayTradingMarginableEquitiesBuyingPower &&
	               lhs.BODOptionBuyingPower == rhs.BODOptionBuyingPower && 
	               lhs.BODOptionValue == rhs.BODOptionValue && 
	               lhs.BODOvernightBuyingPower == rhs.BODOvernightBuyingPower && 
	               lhs.Brokerage == rhs.Brokerage && 
	               lhs.CanDayTrade == rhs.CanDayTrade && 
	               lhs.Commission == rhs.Commission && 
	               lhs.DayTrades == rhs.DayTrades && 
	               lhs.DayTradingQualified == rhs.DayTradingQualified && 
	               lhs.OptionApprovalLevel == rhs.OptionApprovalLevel && 
	               lhs.PatternDayTrader == rhs.PatternDayTrader &&
	               lhs.RealTimeCostOfPositions == rhs.RealTimeCostOfPositions && 
	               lhs.RealTimeDayTradingMarginableEquitiesBuyingPower == rhs.RealTimeDayTradingMarginableEquitiesBuyingPower &&
	               lhs.RealTimeOptionBuyingPower == rhs.RealTimeOptionBuyingPower && 
	               lhs.RealTimeOptionValue == rhs.RealTimeOptionValue && 
	               lhs.RealTimeOvernightBuyingPower == rhs.RealTimeOvernightBuyingPower && 
	               lhs.UnsettledFund == rhs.UnsettledFund;
        }

		[DebuggerStepThrough()]
        public static bool operator !=(EquityAccount lhs, EquityAccount rhs)
        {
            return !(lhs == rhs);
        }

        [DebuggerStepThrough()]
        public bool Equals(EquityAccount token)
        {
            return this == token;
        }

        [DebuggerStepThrough()]
        public override bool Equals(object obj)
        {
            EquityAccount token = obj as EquityAccount;
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
            return string.Format("EquityAccount Account {0}", Key);
        }

        #endregion overloads and overrides

	}

	public class FuturesAccount : Account
	{
		public decimal BODOpenTradeEquity { get; set; }
		public decimal Commission { get; set; }
		public Currency Currency { get; set; }
		public List<FuturesAccountCurrencyDetail> CurrencyDetails { get; set; }
		public decimal OpenOrderMargin { get; set; }
		public decimal RealTimeInitialMargin { get; set; }
		public decimal RealTimeMaintenanceMargin { get; set; }
		public decimal RealTimeTradeEquity { get; set; }
		public decimal SecurityOnDeposit { get; set; }
		public decimal TodayRealTimeTradeEquity { get; set; }
        public static new FuturesAccount Empty { get { return new FuturesAccount(); } }

		public FuturesAccount()
		{
			CurrencyDetails = new List<FuturesAccountCurrencyDetail>(10);
		}

        #region overloads and overrides

        [DebuggerStepThrough()]
        public static bool operator ==(FuturesAccount lhs, FuturesAccount rhs)
        {
	        if (ReferenceEquals(lhs, rhs))
                return true;
	        if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
		        return false;
	        return lhs == (Account)rhs && 
	               lhs.BODOpenTradeEquity == rhs.BODOpenTradeEquity &&
	               lhs.Commission == rhs.Commission && 
	               lhs.Currency == rhs.Currency && 
	               Utility.ListsAreEqual(lhs.CurrencyDetails, rhs.CurrencyDetails) && 
	               lhs.OpenOrderMargin == rhs.OpenOrderMargin &&
	               lhs.RealTimeInitialMargin == rhs.RealTimeInitialMargin && 
	               lhs.RealTimeMaintenanceMargin == rhs.RealTimeMaintenanceMargin &&
	               lhs.RealTimeTradeEquity == rhs.RealTimeTradeEquity &&
	               lhs.SecurityOnDeposit == rhs.SecurityOnDeposit && 
	               lhs.TodayRealTimeTradeEquity == rhs.TodayRealTimeTradeEquity;
        }

		[DebuggerStepThrough()]
        public static bool operator !=(FuturesAccount lhs, FuturesAccount rhs)
        {
            return !(lhs == rhs);
        }

        [DebuggerStepThrough()]
        public bool Equals(FuturesAccount token)
        {
            return this == token;
        }

        [DebuggerStepThrough()]
        public override bool Equals(object obj)
        {
            FuturesAccount token = obj as FuturesAccount;
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
            return string.Format("FuturesAccount {0}", Key);
        }

        #endregion overloads and overrides
	}

}
