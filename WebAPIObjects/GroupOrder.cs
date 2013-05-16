using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	[InitialVersion(WebApiVersion.V2)]
	public class GroupOrder
	{
		public GroupOrder() 
		{
			Orders = new List<Order>(16);
		}

		public GroupOrderType GroupType { get; set; }
		public List<Order> Orders { get; private set; }

		#region overloads and overrides

		[DebuggerStepThrough()]
		public static bool operator ==(GroupOrder lhs, GroupOrder rhs)
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.GroupType == rhs.GroupType && 
			       Utility.ListsAreEqual(lhs.Orders, rhs.Orders);
		}

		[DebuggerStepThrough()]
		public static bool operator !=(GroupOrder lhs, GroupOrder rhs)
		{
			return !(lhs == rhs);
		}

		[DebuggerStepThrough()]
		public bool Equals(GroupOrder token)
		{
			return this == token;
		}

		[DebuggerStepThrough()]
		public override bool Equals(object obj)
		{
			return Equals(obj as GroupOrder);
		}

		[DebuggerStepThrough()]
		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		[DebuggerStepThrough()]
		public override string ToString()
		{
			return string.Format("{0} Orders: {1}", GroupType.ToString(), GetOrderString());
		}

		private string GetOrderString()
		{
			StringBuilder s = new StringBuilder(255);
			foreach (Order order in Orders)
			{
				s.Append(order + ", "); 
			}
			if (s.Length > 2) s.Length -= 2; 
			return s.ToString(); 
		}

		#endregion overloads and overrides
	}
	
	// ReSharper disable InconsistentNaming
	public enum GroupOrderType 
	{
		NORMAL, 
		OCO, 
		BRK
	}
	// ReSharper restore InconsistentNaming
}
