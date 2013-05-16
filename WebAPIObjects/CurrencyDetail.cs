using System.Diagnostics;

namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	public class AccountCurrencyDetail
	{
		public Currency Currency { get; set; }
		public decimal ToAccountConversionRate { get; set; }
		public decimal BODCashBalance { get; set; }
		public decimal BODAccountCashBalance { get; set; }
		public decimal RealTimeCashBalance { get; set; }
		public decimal RealTimeAccountCashBalance { get; set; }
		public decimal Commission { get; set; }
		public decimal RealTimeUnrealizedProfitLoss { get; set; }
		public decimal RealTimeAccountUnrealizedProfitLoss { get; set; }
		public decimal RealTimeRealizedProfitLoss { get; set; }
		public decimal RealTimeAccountRealizedProfitLoss { get; set; }
        public static AccountCurrencyDetail Empty { get { return new AccountCurrencyDetail(); } }

        #region overloads and overrides

        [DebuggerStepThrough()]
        public static bool operator ==(AccountCurrencyDetail lhs, AccountCurrencyDetail rhs)
        {
	        if (ReferenceEquals(lhs, rhs))
                return true;
	        if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
		        return false;
	        return lhs.BODAccountCashBalance == rhs.BODAccountCashBalance && 
	               lhs.BODCashBalance == rhs.BODCashBalance && 
	               lhs.Commission == rhs.Commission && 
	               lhs.Currency == rhs.Currency && 
	               lhs.RealTimeAccountCashBalance == rhs.RealTimeAccountCashBalance && 
	               lhs.RealTimeAccountRealizedProfitLoss == rhs.RealTimeAccountRealizedProfitLoss && 
	               lhs.RealTimeAccountUnrealizedProfitLoss == rhs.RealTimeAccountUnrealizedProfitLoss && 
	               lhs.RealTimeCashBalance == rhs.RealTimeCashBalance && 
	               lhs.RealTimeRealizedProfitLoss == rhs.RealTimeRealizedProfitLoss && 
	               lhs.RealTimeUnrealizedProfitLoss == rhs.RealTimeUnrealizedProfitLoss && 
	               lhs.ToAccountConversionRate == rhs.ToAccountConversionRate;
        }

		[DebuggerStepThrough()]
        public static bool operator !=(AccountCurrencyDetail lhs, AccountCurrencyDetail rhs)
        {
            return !(lhs == rhs);
        }

        [DebuggerStepThrough()]
        public bool Equals(AccountCurrencyDetail token)
        {
            return this == token;
        }

        [DebuggerStepThrough()]
        public override bool Equals(object obj)
        {
            return Equals(obj as AccountCurrencyDetail);
        }

        [DebuggerStepThrough()]
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        [DebuggerStepThrough()]
        public override string ToString()
        {
            return string.Format("Currency Detail: {1} {0}", Currency, BODAccountCashBalance);
        }

        #endregion overloads and overrides


	}

	public class FuturesAccountCurrencyDetail : AccountCurrencyDetail
	{
		public decimal BODSecurities { get; set; }
		public decimal BODAccountSecurities { get; set; }
		public decimal BODOpenTradeEquity { get; set; }
		public decimal TodayRealTimeUnrealizedProfitLoss { get; set; }
		public decimal OpenOrderInitMargin { get; set; }
		public decimal AccountOpenOrderInitMargin { get; set; }
		public decimal RealTimeInitMargin { get; set; }
		public decimal RealTimeAccountInitMargin { get; set; }
		public decimal RealTimeMaintenanceMargin { get; set; }
		public decimal RealTimeAccountMaintenanceMargin { get; set; }
        public static new FuturesAccountCurrencyDetail Empty { get { return new FuturesAccountCurrencyDetail(); } }

        #region overloads and overrides

        [DebuggerStepThrough()]
        public static bool operator ==(FuturesAccountCurrencyDetail lhs, FuturesAccountCurrencyDetail rhs)
        {
            if (ReferenceEquals(lhs, rhs))
                return true;
	        if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
		        return false;
	        return
		        /*Base fields: */
		        lhs == (AccountCurrencyDetail)rhs && 
		        /*Futures fields: */
		        lhs.BODSecurities == rhs.BODSecurities &&
		        lhs.BODAccountSecurities == rhs.BODAccountSecurities &&
		        lhs.BODOpenTradeEquity == rhs.BODOpenTradeEquity &&
		        lhs.TodayRealTimeUnrealizedProfitLoss == rhs.TodayRealTimeUnrealizedProfitLoss &&
		        lhs.OpenOrderInitMargin == rhs.OpenOrderInitMargin &&
		        lhs.AccountOpenOrderInitMargin == rhs.AccountOpenOrderInitMargin &&
		        lhs.RealTimeInitMargin == rhs.RealTimeInitMargin &&
		        lhs.RealTimeAccountInitMargin == rhs.RealTimeAccountInitMargin &&
		        lhs.RealTimeMaintenanceMargin == rhs.RealTimeMaintenanceMargin &&
		        lhs.RealTimeAccountMaintenanceMargin == rhs.RealTimeAccountMaintenanceMargin;
        }

        [DebuggerStepThrough()]
        public static bool operator !=(FuturesAccountCurrencyDetail lhs, FuturesAccountCurrencyDetail rhs)
        {
            return !(lhs == rhs);
        }

        [DebuggerStepThrough()]
        public bool Equals(FuturesAccountCurrencyDetail token)
        {
            return this == token;
        }

        [DebuggerStepThrough()]
        public override bool Equals(object obj)
        {
            return Equals(obj as FuturesAccountCurrencyDetail);
        }

        [DebuggerStepThrough()]
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        [DebuggerStepThrough()]
        public override string ToString()
        {
            return string.Format("Futures Currency Detail: {1} {0}", Currency, BODAccountCashBalance);
        }

        #endregion overloads and overrides
	}

	public class ForexAccountCurrencyDetail
	{
		public decimal BODMarginRequirement { get; set; }
		public decimal BODAccountMarginRequirement { get; set; }
        public static ForexAccountCurrencyDetail Empty { get { return new ForexAccountCurrencyDetail(); } }

        #region overloads and overrides

        [DebuggerStepThrough()]
        public static bool operator ==(ForexAccountCurrencyDetail lhs, ForexAccountCurrencyDetail rhs)
        {
            if (ReferenceEquals(lhs, rhs))
                return true;
	        if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
		        return false;
	        return lhs.BODAccountMarginRequirement == rhs.BODAccountMarginRequirement && 
	               lhs.BODMarginRequirement == rhs.BODMarginRequirement;
        }

        [DebuggerStepThrough()]
        public static bool operator !=(ForexAccountCurrencyDetail lhs, ForexAccountCurrencyDetail rhs)
        {
            return !(lhs == rhs);
        }

        [DebuggerStepThrough()]
        public bool Equals(ForexAccountCurrencyDetail token)
        {
            return this == token;
        }

        [DebuggerStepThrough()]
        public override bool Equals(object obj)
        {
			return Equals(obj as ForexAccountCurrencyDetail);
        }

        [DebuggerStepThrough()]
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        [DebuggerStepThrough()]
        public override string ToString()
        {
            return string.Format("Forex Currency Detail - Account Margin Requirement: {0} Margin Reqirement: {1}", BODAccountMarginRequirement, BODMarginRequirement);
        }

        #endregion overloads and overrides
	}
}
