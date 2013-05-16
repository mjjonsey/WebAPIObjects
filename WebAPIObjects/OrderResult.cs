using System.Diagnostics;

namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	public class OrderResult
	{
		public string Message { get; set; }
		public int OrderId { get; set; }
		public OrderResultStatus OrderStatus { get; set; }
		public static OrderResult Empty { get { return new OrderResult(); } }

		#region overloads and overrides

		[DebuggerStepThrough()]
		public static bool operator ==(OrderResult lhs, OrderResult rhs)
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Message == rhs.Message &&
				   lhs.OrderId == rhs.OrderId && 
				   lhs.OrderStatus == rhs.OrderStatus;
		}

		[DebuggerStepThrough()]
		public static bool operator !=(OrderResult lhs, OrderResult rhs)
		{
			return !(lhs == rhs);
		}

		[DebuggerStepThrough()]
		public bool Equals(OrderResult token)
		{
			return this == token;
		}

		[DebuggerStepThrough()]
		public override bool Equals(object obj)
		{
			return Equals(obj as OrderResult);
		}

		[DebuggerStepThrough()]
		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		[DebuggerStepThrough()]
		public override string ToString()
		{
			return string.Format("Order {0} {1}: {2}",  OrderId, OrderStatus.ToString(), Message);
		}

		#endregion overloads and overrides

	}

	public enum OrderResultStatus
	{
		Failed,
		Ok
	}
}
