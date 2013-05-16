using System.Diagnostics;

namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	/// <summary>
	/// Base class for return value of all calls to Order/Confirm
	/// </summary>
	public abstract class OrderConfirmation
	{
		public string SummaryMessage { get; set; }
		public decimal EstimatedPrice { get; set; }

		#region overloads and overrides

		[DebuggerStepThrough()]
		public static bool operator ==(OrderConfirmation lhs, OrderConfirmation rhs)
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.SummaryMessage == rhs.SummaryMessage &&
				   lhs.EstimatedPrice == rhs.EstimatedPrice ;
		}

		[DebuggerStepThrough()]
		public static bool operator !=(OrderConfirmation lhs, OrderConfirmation rhs)
		{
			return !(lhs == rhs);
		}

		[DebuggerStepThrough()]
		public bool Equals(OrderConfirmation token)
		{
			return this == token;
		}

		[DebuggerStepThrough()]
		public override bool Equals(object obj)
		{
			return Equals(obj as OrderConfirmation);
		}

		[DebuggerStepThrough()]
		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		[DebuggerStepThrough()]
		public override string ToString()
		{
			return SummaryMessage;
		}

		#endregion overloads and overrides
	}

	/// <summary>
	/// Base class for calls to Order/Confirm for AssetClasses except Forex
	/// </summary>
	public abstract class NonForexConfirmation : OrderConfirmation
	{
		public string Route { get; set; }
		public string Duration { get; set; }
		public string Account { get; set; }
		public decimal EstimatedCost { get; set; }
		public string EstimatedPriceDisplay { get; set; }
		public decimal EstimatedCommission { get; set; }
		public string EstimatedCommissionDisplay { get; set; }

		#region overloads and overrides

		[DebuggerStepThrough()]
		public static bool operator ==(NonForexConfirmation lhs, NonForexConfirmation rhs)
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs == (OrderConfirmation)rhs &&
				   lhs.Account == rhs.Account &&
				   lhs.Duration == rhs.Duration &&
				   lhs.EstimatedCommission == rhs.EstimatedCommission &&
				   lhs.EstimatedCommissionDisplay == rhs.EstimatedCommissionDisplay &&
				   lhs.EstimatedCost == rhs.EstimatedCost &&
				   lhs.EstimatedPriceDisplay == rhs.EstimatedPriceDisplay &&
				   lhs.Route == rhs.Route;
		}

		[DebuggerStepThrough()]
		public static bool operator !=(NonForexConfirmation lhs, NonForexConfirmation rhs)
		{
			return !(lhs == rhs);
		}

		[DebuggerStepThrough()]
		public bool Equals(NonForexConfirmation token)
		{
			return this == token;
		}

		[DebuggerStepThrough()]
		public override bool Equals(object obj)
		{
			return Equals(obj as NonForexConfirmation);
		}

		[DebuggerStepThrough()]
		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}


		#endregion overloads and overrides

	}

	public class EquityOrderConfirmation : NonForexConfirmation
	{
		public string EstimatedCostDisplay { get; set; }
		public static OrderConfirmation Empty { get { return new EquityOrderConfirmation(); } }

		#region overloads and overrides

		[DebuggerStepThrough()]
		public static bool operator ==(EquityOrderConfirmation lhs, EquityOrderConfirmation rhs)
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs == (NonForexConfirmation)rhs &&
				   lhs.EstimatedCostDisplay == rhs.EstimatedCostDisplay;
		}

		[DebuggerStepThrough()]
		public static bool operator !=(EquityOrderConfirmation lhs, EquityOrderConfirmation rhs)
		{
			return !(lhs == rhs);
		}

		[DebuggerStepThrough()]
		public bool Equals(EquityOrderConfirmation token)
		{
			return this == token;
		}

		[DebuggerStepThrough()]
		public override bool Equals(object obj)
		{
			return Equals(obj as EquityOrderConfirmation);
		}

		[DebuggerStepThrough()]
		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		[DebuggerStepThrough()]
		public override string ToString()
		{
			return string.Format("{0} Estimated Cost Display: {1}", base.ToString(), EstimatedCostDisplay);
		}

		#endregion overloads and overrides

	}

	public class FuturesOrderConfirmation : NonForexConfirmation
	{
		public string ProductCurrency { get; set; } 
		public string AccountCurrency { get; set; }
		public string InitialMarginDisplay { get; set; }
		public static FuturesOrderConfirmation Empty { get { return new FuturesOrderConfirmation(); } }

		#region overloads and overrides

		[DebuggerStepThrough()]
		public static bool operator ==(FuturesOrderConfirmation lhs, FuturesOrderConfirmation rhs)
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs == (NonForexConfirmation)rhs &&
				   lhs.ProductCurrency == rhs.ProductCurrency && 
				   lhs.AccountCurrency == rhs.AccountCurrency && 
				   lhs.InitialMarginDisplay == rhs.InitialMarginDisplay;
		}

		[DebuggerStepThrough()]
		public static bool operator !=(FuturesOrderConfirmation lhs, FuturesOrderConfirmation rhs)
		{
			return !(lhs == rhs);
		}

		[DebuggerStepThrough()]
		public bool Equals(FuturesOrderConfirmation token)
		{
			return this == token;
		}

		[DebuggerStepThrough()]
		public override bool Equals(object obj)
		{
			return Equals(obj as FuturesOrderConfirmation);
		}

		[DebuggerStepThrough()]
		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		[DebuggerStepThrough()]
		public override string ToString()
		{
			return string.Format("{0} ProductCurrency: {1} AccountCurrency: {2} InitialMarginDisplay: {3}", base.ToString(), ProductCurrency, AccountCurrency, InitialMarginDisplay);
		}

		#endregion overloads and overrides

	}

	/// <summary>
	/// ForexOrderConfirmation doesn't share any fields with the other types of confirmation so it does not inherit from the base class
	/// </summary>
	public class ForexOrderConfirmation : OrderConfirmation
	{
		public string BaseCurrency { get; set; } 
		public string CounterCurrency { get; set; }
		public string InitialMarginDisplay { get; set; }
		
		public static ForexOrderConfirmation Empty { get { return new ForexOrderConfirmation(); } }

		#region overloads and overrides

		[DebuggerStepThrough()]
		public static bool operator ==(ForexOrderConfirmation lhs, ForexOrderConfirmation rhs)
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs == (OrderConfirmation)rhs && 
				   lhs.BaseCurrency == rhs.BaseCurrency && 
				   lhs.CounterCurrency == rhs.CounterCurrency && 
				   lhs.InitialMarginDisplay == rhs.InitialMarginDisplay;
		}

		[DebuggerStepThrough()]
		public static bool operator !=(ForexOrderConfirmation lhs, ForexOrderConfirmation rhs)
		{
			return !(lhs == rhs);
		}

		[DebuggerStepThrough()]
		public bool Equals(ForexOrderConfirmation token)
		{
			return this == token;
		}

		[DebuggerStepThrough()]
		public override bool Equals(object obj)
		{
			return Equals(obj as ForexOrderConfirmation);
		}

		[DebuggerStepThrough()]
		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		[DebuggerStepThrough()]
		public override string ToString()
		{
			return string.Format("{0} BaseCurrency: {1} CounterCurrency: {2} InitialMarginDisplay: {3} ", base.ToString(), BaseCurrency, CounterCurrency, InitialMarginDisplay);
		} 

		#endregion overloads and overrides

	}
}
