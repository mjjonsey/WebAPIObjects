using System;
using System.Diagnostics;

namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	[Serializable]
	public class SymbolBarData : IntradayBarData
	{
		public string Symbol { get; set; }

		#region overloads and overrides

		public static bool operator ==(SymbolBarData lhs, SymbolBarData rhs)
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Symbol == rhs.Symbol &&
				   lhs == ((IntradayBarData)rhs);
		}

		public static bool operator !=(SymbolBarData lhs, SymbolBarData rhs)
		{
			return !(lhs == rhs);
		}

		public bool Equals(SymbolBarData token)
		{
			return this == token;
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as SymbolBarData);
		}

		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("Symbol: {0} {1}", Symbol, base.ToString());
		}

		#endregion overloads and overrides

	}

	[Serializable]
	public class IntradayBarData
	{
		public decimal Close { get; set; }
		public int DownTicks { get; set; }
		public int DownVolume { get; set; }
		public decimal High { get; set; }
		public decimal Low { get; set; }
		public decimal Open { get; set; }
		public DateTime TimeStamp { get; set; }
		public int TotalTicks { get; set; }
		public int TotalVolume { get; set; }
		public int UnchangedTicks { get; set; }
		public int UnchangedVolume { get; set; }
		public int UpTicks { get; set; }
		public int UpVolume { get; set; }
		public int Status { get; set; }
        public static IntradayBarData Empty { get { return new IntradayBarData(); } }

        #region overloads and overrides

        [DebuggerStepThrough()]
        public static bool operator ==(IntradayBarData lhs, IntradayBarData rhs)
        {
	        if (ReferenceEquals(lhs, rhs))
                return true;
	        if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
		        return false;
	        return lhs.Close == rhs.Close && 
	               lhs.DownTicks == rhs.DownTicks && 
	               lhs.DownVolume == rhs.DownVolume && 
	               lhs.High == rhs.High && 
	               lhs.Low == rhs.Low && 
	               lhs.Open == rhs.Open && 
	               lhs.Status == rhs.Status && 
	               lhs.TimeStamp == rhs.TimeStamp && 
	               lhs.TotalTicks == rhs.TotalTicks && 
	               lhs.TotalVolume == rhs.TotalVolume && 
	               lhs.UnchangedTicks == rhs.UnchangedTicks && 
	               lhs.UnchangedVolume == rhs.UnchangedVolume && 
	               lhs.UpTicks == rhs.UpTicks && 
	               lhs.UpVolume == rhs.UpVolume;
        }

		[DebuggerStepThrough()]
        public static bool operator !=(IntradayBarData lhs, IntradayBarData rhs)
        {
            return !(lhs == rhs);
        }

        [DebuggerStepThrough()]
        public bool Equals(IntradayBarData token)
        {
            return this == token;
        }

        [DebuggerStepThrough()]
        public override bool Equals(object obj)
        {
            return Equals(obj as IntradayBarData);
        }

        [DebuggerStepThrough()]
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        [DebuggerStepThrough()]
        public override string ToString()
        {
            return string.Format("Open: {0} Close: {1} High:{2} Low:{3} Ticks: {4} TimeStamp: {5} {6}", Open, Close, High, Low, TotalTicks, TimeStamp.ToShortDateString(), TimeStamp.ToLongTimeString());
        }

        #endregion overloads and overrides
	}
}
