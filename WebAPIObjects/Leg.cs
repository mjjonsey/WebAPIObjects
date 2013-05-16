using System.Diagnostics;

namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	public class Leg
	{
		public decimal Ask { get; set; }
		public bool AskSpecified { get; set; }
		public string BaseSymbol { get; set; }
		public decimal Bid { get; set; }
		public bool BidSpecified { get; set; }
		public decimal ExecPrice { get; set; }
		public bool ExecPriceSpecified { get; set; }
		public int ExecQuantity { get; set; }
		public bool ExecQuantitySpecified { get; set; }
		public string ExpireDate { get; set; }
		public int Leaves { get; set; }
		public bool LeavesSpecified { get; set; }
		public int LegNumber { get; set; }
		public bool LegNumberSpecified { get; set; }
		public decimal LimitPrice { get; set; }
		public bool LimitPriceSpecified { get; set; }
		public string LimitPriceDisplay { get; set; }
		public int Month { get; set; }
		public bool MonthSpecified { get; set; }
		public string OpenOrClose { get; set; }
		public int OrderId { get; set; }
		public bool OrderIdSpecified { get; set; }
		public OrderType OrderType { get; set; }
		public bool OrderTypeSpecified { get; set; }
		public string OrderTypeDescription { get; set; }
		public decimal PointValue { get; set; }
		public bool PointValueSpecified { get; set; }
		public decimal PriceUsedForBuyingPower { get; set; }
		public bool PriceUsedForBuyingPowerSpecified { get; set; }
		public string PutOrCall { get; set; }
		public int Quantity { get; set; }
		public bool QuantitySpecified { get; set; }
		public string Side { get; set; }
		public decimal StopPrice { get; set; }
		public bool StopPriceSpecified { get; set; }
		public string StopPriceDisplay { get; set; }
		public decimal StrikePrice { get; set; }
		public bool StrikePriceSpecified { get; set; }
		public string Symbol { get; set; }
		public string TimeExecuted { get; set; }
		public int Year { get; set; }
		public bool YearSpecified { get; set; }
        public static Leg Empty { get { return new Leg(); } }

        #region overloads and overrides

        [DebuggerStepThrough()]
        public static bool operator ==(Leg lhs, Leg rhs)
        {
	        if (ReferenceEquals(lhs, rhs))
                return true;
	        if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
		        return false;
	        return lhs.Ask == rhs.Ask && 
	               lhs.AskSpecified == rhs.AskSpecified && 
	               lhs.BaseSymbol == rhs.BaseSymbol && 
	               lhs.Bid == rhs.Bid && 
	               lhs.BidSpecified == rhs.BidSpecified && 
	               lhs.ExecPrice == rhs.ExecPrice && 
	               lhs.ExecPriceSpecified == rhs.ExecPriceSpecified && 
	               lhs.ExecQuantity == rhs.ExecQuantity && 
	               lhs.ExecQuantitySpecified == rhs.ExecQuantitySpecified && 
	               lhs.ExpireDate == rhs.ExpireDate && 
	               lhs.Leaves == rhs.Leaves && 
	               lhs.LeavesSpecified == rhs.LeavesSpecified && 
	               lhs.LegNumber == rhs.LegNumber && 
	               lhs.LegNumberSpecified == rhs.LegNumberSpecified && 
	               lhs.LimitPrice == rhs.LimitPrice && 
	               lhs.LimitPriceDisplay == rhs.LimitPriceDisplay && 
	               lhs.LimitPriceSpecified == rhs.LimitPriceSpecified && 
	               lhs.Month == rhs.Month && 
	               lhs.MonthSpecified == rhs.MonthSpecified && 
	               lhs.OpenOrClose == rhs.OpenOrClose && 
	               lhs.OrderId == rhs.OrderId && 
	               lhs.OrderIdSpecified == rhs.OrderIdSpecified && 
	               lhs.OrderType == rhs.OrderType &&
	               lhs.OrderTypeDescription == rhs.OrderTypeDescription && 
	               lhs.OrderTypeSpecified == rhs.OrderTypeSpecified && 
	               lhs.PointValue == rhs.PointValue && 
	               lhs.PointValueSpecified == rhs.PointValueSpecified && 
	               lhs.PriceUsedForBuyingPower == rhs.PriceUsedForBuyingPower && 
	               lhs.PriceUsedForBuyingPowerSpecified == rhs.PriceUsedForBuyingPowerSpecified && 
	               lhs.PutOrCall == rhs.PutOrCall && 
	               lhs.Quantity == rhs.Quantity && 
	               lhs.QuantitySpecified == rhs.QuantitySpecified && 
	               lhs.Side == rhs.Side && 
	               lhs.StopPrice == rhs.StopPrice && 
	               lhs.StopPriceDisplay == rhs.StopPriceDisplay && 
	               lhs.StopPriceSpecified == rhs.StopPriceSpecified && 
	               lhs.StrikePrice == rhs.StrikePrice && 
	               lhs.StrikePriceSpecified == rhs.StrikePriceSpecified && 
	               lhs.Symbol == rhs.Symbol && 
	               lhs.TimeExecuted == rhs.TimeExecuted && 
	               lhs.Year == rhs.Year && 
	               lhs.YearSpecified == rhs.YearSpecified;
        }

		[DebuggerStepThrough()]
        public static bool operator !=(Leg lhs, Leg rhs)
        {
            return !(lhs == rhs);
        }

        [DebuggerStepThrough()]
        public bool Equals(Leg token)
        {
            return this == token;
        }

        [DebuggerStepThrough()]
        public override bool Equals(object obj)
        {
			return Equals(obj as Leg);
        }

        [DebuggerStepThrough()]
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        [DebuggerStepThrough()]
        public override string ToString()
        {
            return string.Format("Order {0} Leg {1} {2} Bid:{3} Ask:{4} ", OrderId, Symbol, Quantity, Bid, Ask);
        }

        #endregion overloads and overrides

	}
}
