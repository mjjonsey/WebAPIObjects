using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;


namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	public abstract class OrderBase
	{
		public string AccountKey { get; set; }
		public int OrderId { get; set; }
		public OrderType OrderType { get; set; }
		public Route Route { get; set; }
		public OrderDuration Duration { get; set; }
		public OrderState Status { get; set; }
		public string Symbol { get; set; }
		public int Quantity { get; set; }
		public decimal LimitPrice { get; set; }
		public decimal StopPrice { get; set; }
		public TradeAction TradeAction { get; set; }

		protected OrderBase() 
		{
			Duration = new OrderDuration(DurationCode.DAY);
		}

		#region overloads and overrides

		[DebuggerStepThrough()]
		public static bool operator ==(OrderBase lhs, OrderBase rhs)
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.OrderId == rhs.OrderId && 
			       lhs.Route == rhs.Route && 
			       lhs.Duration == rhs.Duration && 
			       lhs.Symbol == rhs.Symbol && 
			       lhs.Quantity == rhs.Quantity && 
			       lhs.LimitPrice == rhs.LimitPrice && 
			       lhs.StopPrice == rhs.StopPrice;
		}

		[DebuggerStepThrough()]
		public static bool operator !=(OrderBase lhs, OrderBase rhs)
		{
			return !(lhs == rhs);
		}

		[DebuggerStepThrough()]
		public bool Equals(OrderBase token)
		{
			return this == token;
		}

		[DebuggerStepThrough()]
		public override bool Equals(object obj)
		{
			return Equals(obj as OrderBase);
		}

		[DebuggerStepThrough()]
		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		[DebuggerStepThrough()]
		public override string ToString()
		{
			StringBuilder orderString = new StringBuilder(255);
			orderString.AppendFormat("Order {0} ", OrderId > 0 ? OrderId.ToString() : "(No Order Id)");
			return string.Format("Order {0}: {1} {2}", orderString, Quantity, Symbol);
		}

		#endregion overloads and overrides
	}

	[InitialVersion(WebApiVersion.V2)]
	public class Order : OrderBase
	{
		public AssetType AssetType { get; set; }
		public DateTime GTDDate { get; set; }
		public TrailingStop AdvancedOptions { get; set; }
		// ReSharper disable InconsistentNaming
		public List<GroupOrder> OSOs { get; private set; }
		// ReSharper restore InconsistentNaming
		public static Order Empty { get { return new Order(); } }

		public Order() 
		{
			OSOs = new List<GroupOrder>(16);
			AdvancedOptions = new TrailingStop(); 
		}

		#region overloads and overrides

		[DebuggerStepThrough()]
		public static bool operator ==(Order lhs, Order rhs)
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs == (OrderBase)rhs &&
			       lhs.AssetType == rhs.AssetType && 
			       lhs.OrderType == rhs.OrderType && 
			       lhs.AccountKey == rhs.AccountKey && 
			       lhs.GTDDate == rhs.GTDDate && 
			       lhs.TradeAction == rhs.TradeAction && 
			       lhs.AdvancedOptions == rhs.AdvancedOptions && 
			       Utility.ListsAreEqual(lhs.OSOs, rhs.OSOs);
		}

		[DebuggerStepThrough()]
		public static bool operator !=(Order lhs, Order rhs)
		{
			return !(lhs == rhs);
		}

		[DebuggerStepThrough()]
		public bool Equals(Order token)
		{
			return this == token;
		}

		[DebuggerStepThrough()]
		public override bool Equals(object obj)
		{
			return Equals(obj as Order);
		}

		[DebuggerStepThrough()]
		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		[DebuggerStepThrough()]
		public override string ToString()
		{
			return base.ToString();
		}

		#endregion overloads and overrides
	}

	[InitialVersion(WebApiVersion.V1)]
	public class OrderDetail : OrderBase
	{
		public string AccountAlias { get; set; }
		public string AdvancedOptions { get; set; }
		public AssetType AssetType { get; set; }
		public decimal CommissionFee { get; set; }
		public bool CommissionFeeSpecified { get; set; }
		public string ContractExpireDate { get; set; }
		public decimal ConversionRate { get; set; }
		public bool ConversionRateSpecified { get; set; }
		public string Country { get; set; }
		public Currency Denomination { get; set; }
		public int ExecuteQuantity { get; set; }
		public bool ExecuteQuantitySpecified { get; set; }
		public string FilledCanceled { get; set; }
		public string FilledPriceText { get; set; }
		public string GroupName { get; set; }

		public List<Leg> Legs { get; private set; }

		public string LimitPriceText { get; set; }
		public bool OrderIdSpecified { get; set; }
		public int Originator { get; set; }
		public bool OriginatorSpecified { get; set; }
		public bool QuantitySpecified { get; set; }
		public int QuantityLeft { get; set; }
		public bool QuantityLeftSpecified { get; set; }
		public string RejectReason { get; set; }
		public string Spread { get; set; }
		
		public string StatusDescription { get; set; }
		public string StopPriceText { get; set; }
		public string TimeStamp { get; set; }
		public string TriggeredBy { get; set; }
		
		public static OrderDetail Empty { get { return new OrderDetail(); } }

		public OrderDetail()
		{
			Legs = new List<Leg>(10);
		}

		#region overloads and overrides

		[DebuggerStepThrough()]
		public static explicit operator Order(OrderDetail detail)
		{
			Order order = new Order {AccountKey = detail.AccountKey, AssetType = detail.AssetType, Duration = detail.Duration};
			DateTime testDate; 
			if (DateTime.TryParse(detail.ContractExpireDate, out testDate))
				order.GTDDate = testDate;

			order.LimitPrice = detail.LimitPrice;
			order.OrderId = detail.OrderId;
			order.OrderType = detail.OrderType;
			order.Quantity = detail.Quantity;
			order.Route = detail.Route;
			order.Status = detail.Status;
			order.StopPrice = detail.StopPrice;
			order.Symbol = detail.Symbol;
			order.TradeAction = detail.TradeAction; 
			return order;
		}

		[DebuggerStepThrough()]
		public static bool operator ==(OrderDetail lhs, OrderDetail rhs)
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return Utility.ListsAreEqual(lhs.Legs, rhs.Legs) &&
			       lhs == (OrderBase)rhs && 
			       lhs.AccountAlias == rhs.AccountAlias &&
			       lhs.AccountKey == rhs.AccountKey &&
			       lhs.AdvancedOptions == rhs.AdvancedOptions &&
			       lhs.AssetType == rhs.AssetType &&
			       lhs.CommissionFee == rhs.CommissionFee &&
			       lhs.CommissionFeeSpecified == rhs.CommissionFeeSpecified &&
			       lhs.ContractExpireDate == rhs.ContractExpireDate &&
			       lhs.ConversionRate == rhs.ConversionRate &&
			       lhs.ConversionRateSpecified == rhs.ConversionRateSpecified &&
			       lhs.Country == rhs.Country &&
			       lhs.Denomination == rhs.Denomination &&
			       lhs.ExecuteQuantity == rhs.ExecuteQuantity &&
			       lhs.ExecuteQuantitySpecified == rhs.ExecuteQuantitySpecified &&
			       lhs.FilledCanceled == rhs.FilledCanceled &&
			       lhs.FilledPriceText == rhs.FilledPriceText &&
			       lhs.GroupName == rhs.GroupName &&
			       lhs.LimitPriceText == rhs.LimitPriceText &&
			       lhs.OrderIdSpecified == rhs.OrderIdSpecified &&
			       lhs.Originator == rhs.Originator &&
			       lhs.OriginatorSpecified == rhs.OriginatorSpecified &&
			       lhs.QuantityLeft == rhs.QuantityLeft &&
			       lhs.QuantityLeftSpecified == rhs.QuantityLeftSpecified &&
			       lhs.QuantitySpecified == rhs.QuantitySpecified &&
			       lhs.RejectReason == rhs.RejectReason &&
			       lhs.Spread == rhs.Spread &&
			       lhs.Status == rhs.Status &&
			       lhs.StatusDescription == rhs.StatusDescription &&
			       lhs.StopPriceText == rhs.StopPriceText &&
			       lhs.Symbol == rhs.Symbol &&
			       lhs.TimeStamp == rhs.TimeStamp &&
			       lhs.TriggeredBy == rhs.TriggeredBy &&
			       lhs.OrderType == rhs.OrderType;
		}

		[DebuggerStepThrough()]
		public static bool operator !=(OrderDetail lhs, OrderDetail rhs)
		{
			return !(lhs == rhs);
		}

		[DebuggerStepThrough()]
		public bool Equals(OrderDetail token)
		{
			return this == token;
		}

		[DebuggerStepThrough()]
		public override bool Equals(object obj)
		{
			return Equals(obj as OrderDetail);
		}

		[DebuggerStepThrough()]
		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		[DebuggerStepThrough()]
		public override string ToString()
		{
			return base.ToString();
		}

		#endregion overloads and overrides

	}

	[InitialVersion(WebApiVersion.V1)]
	public class OrderRequest : OrderBase
	{
		public AssetType AssetType { get; set; }
		public DateTime GTDDate { get; set; }
		public static OrderRequest Empty { get { return new OrderRequest(); } }

		#region methods

		public bool IsValid(out string message)
		{
			message = string.Empty;
			StringBuilder output = new StringBuilder(255);
			bool valid = true;
			// validate duration for asset type
			switch (AssetType)
			{
				case AssetType.OP:
					if (Duration.Code != DurationCode.DAY && Duration.Code != DurationCode.GTC && Duration.Code != DurationCode.GTD &&
						Duration.Code != DurationCode.IOC && Duration.Code != DurationCode.FOK && Duration.Code != DurationCode.OPG)
					{
						output.Append(string.Format("Invalid Duration for AssetType {0}: {1}.{2}", AssetType.ToString(), Duration, Environment.NewLine));
						valid = false;
					}
					break;
				case AssetType.FX:
					if (Duration.Code != DurationCode.DAY && Duration.Code != DurationCode.GTC && Duration.Code != DurationCode.GTD &&
						Duration.Code != DurationCode.IOC && Duration.Code != DurationCode.FOK && Duration.Code != DurationCode.OneMinute &&
						Duration.Code != DurationCode.ThreeMinute && Duration.Code != DurationCode.FiveMinute)
					{
						output.Append(string.Format("Invalid Duration for AssetType {0}: {1}.{2}", AssetType.ToString(), Duration, Environment.NewLine));
						valid = false;
					}
					break;
				case AssetType.FU:
					if (Duration.Code != DurationCode.DAY && Duration.Code != DurationCode.GTC && Duration.Code != DurationCode.GTD &&
						Duration.Code != DurationCode.IOC && Duration.Code != DurationCode.FOK)
					{
						output.Append(string.Format("Invalid Duration for AssetType {0}: {1}.{2}", AssetType.ToString(), Duration, Environment.NewLine));
						valid = false;
					}
					break;
			}

			// validate date
			if (GTDDate > DateTime.MinValue)
			{
				if (GTDDate < DateTime.Now)
				{
					output.Append("GTDDate must be in the future" + Environment.NewLine);
					valid = false;
				}
			}
			else if (Duration.Code == DurationCode.GTD)
			{
				output.Append("GTDDate required for GTD orders." + Environment.NewLine);
				valid = false;
			}

			// valididate limit price: required for limit and stop limit orders
			if ((OrderType == OrderType.Limit || OrderType == OrderType.StopLimit) && LimitPrice <= 0)
			{
				output.Append("Limit price must be greater than 0." + Environment.NewLine);
				valid = false;
			}

			// validate quantity
			if (Quantity <= 0)
			{
				output.AppendFormat("Invalid Quantity of {0}.{1}", Quantity, Environment.NewLine);
				valid = false;
			}

			// TODO: could validate route but bypassing for now since this is not required

			// validate stop price: must be included for stop orders. 
			if ((OrderType == OrderType.StopLimit || OrderType == OrderType.StopMarket) && StopPrice <= 0)
			{
				output.Append("StopPrice is required for Stop orders." + Environment.NewLine);
				valid = false;
			}

			// verify valid trade action for asset class
			string errorMessage = string.Format("{0} is an invalid TradeAction for AssetType {1}.{2}", TradeAction.ToString(), AssetType, Environment.NewLine);
			switch (TradeAction)
			{
				case TradeAction.Buy:
				case TradeAction.Sell:
					if (AssetType == AssetType.OP)
					{
						output.Append(errorMessage);
						valid = false;
					}
					break;
				case TradeAction.BuyToCover:
				case TradeAction.SellShort:
					if (AssetType != AssetType.EQ)
					{
						output.Append(errorMessage);
						valid = false;
					}
					break;
				case TradeAction.BuyToOpen:
				case TradeAction.BuyToClose:
				case TradeAction.SellToOpen:
				case TradeAction.SellToClose:
					if (AssetType != AssetType.OP)
					{
						output.Append(errorMessage);
						valid = false;
					}
					break;
			}

			if (!valid) message = output.ToString();
			return valid;

		}

		public static OrderRequest GetMarketOrderRequest(int accountKey, AssetType assetType, int quantity, string symbol, TradeAction tradeAction)
		{
			return GetOrderRequest(accountKey, assetType, new OrderDuration(DurationCode.DAY), DateTime.MinValue, 0, 0, OrderType.Market, quantity, symbol, tradeAction);
		}

		public static OrderRequest GetOrderRequest(int accountKey, AssetType assetType, OrderDuration duration, DateTime gtdDate, decimal limitPrice, decimal stopPrice, OrderType orderType, int quantity, string symbol, TradeAction tradeAction)
		{

			OrderRequest order = new OrderRequest
				{
				AccountKey = accountKey.ToString(),
				AssetType = assetType,
				Duration = duration,
				GTDDate = gtdDate,
				LimitPrice = limitPrice,
				OrderId = 0,
				OrderType = orderType,
				Quantity = quantity,
				Route = Route.Intelligent,
				StopPrice = stopPrice,
				Symbol = symbol,
				TradeAction = tradeAction
			};

			return order;

		}

		#endregion methods

		#region overloads and overrides

		[DebuggerStepThrough()]
		public static bool operator ==(OrderRequest lhs, OrderRequest rhs)
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs == (OrderBase)rhs && 
			       lhs.AccountKey == rhs.AccountKey &&
			       lhs.AssetType == rhs.AssetType &&
			       lhs.GTDDate == rhs.GTDDate &&
			       lhs.OrderType == rhs.OrderType &&
			       lhs.TradeAction == rhs.TradeAction;
		}

		[DebuggerStepThrough()]
		public static bool operator !=(OrderRequest lhs, OrderRequest rhs)
		{
			return !(lhs == rhs);
		}

		[DebuggerStepThrough()]
		public bool Equals(OrderRequest token)
		{
			return this == token;
		}

		[DebuggerStepThrough()]
		public override bool Equals(object obj)
		{
			return Equals(obj as OrderRequest);
		}

		[DebuggerStepThrough()]
		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		[DebuggerStepThrough()]
		public override string ToString()
		{
			return base.ToString();
		}

		#endregion overloads and overrides

	}

	
}
