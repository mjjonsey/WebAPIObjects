using System;
using System.Diagnostics;
using System.Text;


namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	public class OrderDuration
	{
		public DurationCode Code {get;set;}
		public DateTime? Expiration { get; set; }
		public static OrderDuration Empty { get { return new OrderDuration(DurationCode.DAY); } }

		#region ctor

		public OrderDuration(string value)
		{
			// "GTC+ - 5/10/2012"
			if (string.IsNullOrEmpty(value)) throw new ArgumentException("Null or empty value passed to OrderDuration constructor.", "value"); 
			string[] fields = value.Trim().Split(' ');
			Code = StringToDurationCode(fields[0]); 
			
			// if a date is included, a dash will be the second element in the array, the date will be 3rd
			if (fields.Length > 2)
			{
				DateTime testDate; 
				if (DateTime.TryParse(fields[2], out testDate))
				{
					Expiration = testDate;
				}
			}
		}

		public OrderDuration(DurationCode code, DateTime expiration) : this(code)
		{
			Expiration = expiration; 
		}

		public OrderDuration(DurationCode code)
		{
			Code = code;
		}

		/// <summary>
		///  Some actual Duration codes can't stored as enums: 1 Minute, DAY+, etc...
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		public static string DurationCodeToString(DurationCode code)
		{
			switch (code)
			{ 
				case DurationCode.DAYP:
					return "DAY+"; 
				case DurationCode.GTCP:
					return "GTC+"; 
				case DurationCode.GTDP:
					return "GDT+";
				case DurationCode.OneMinute:
					return "1"; 
				case DurationCode.ThreeMinute:
					return "3"; 
				case DurationCode.FiveMinute:
					return "5"; 
				default:
					return code.ToString(); 
			}
		}

		public static DurationCode StringToDurationCode(string value)
		{
			DurationCode code = DurationCode.DAY; 

			if (value.StartsWith("1"))
				code = DurationCode.OneMinute;
			else if (value.StartsWith("3"))
				code = DurationCode.ThreeMinute;
			else if (value.StartsWith("5"))
				code = DurationCode.FiveMinute;
			else
			{
				switch (value.ToUpper())
				{
					case "DAY":
						code = DurationCode.DAY;
						break;
					case "DAY+":
					case "DAYP":
						code = DurationCode.DAYP;
						break;
					case "GTC":
						code = DurationCode.GTC;
						break;
					case "GTC+":
					case "GTCP":
						code = DurationCode.GTCP;
						break;
					case "GTD":
						code = DurationCode.GTD;
						break;
					case "GTD+":
					case "GTDP":
						code = DurationCode.GTDP;
						break;
					case "IOC":
						code = DurationCode.IOC;
						break;
					case "FOK":
						code = DurationCode.FOK;
						break;
					case "OPG":
						code = DurationCode.OPG;
						break;
					case "CLO":
						code = DurationCode.CLO;
						break;
					case "ONEMINUTE":
						code = DurationCode.OneMinute;
						break;
					case "THREEMINUTE":
						code = DurationCode.ThreeMinute;
						break;
					case "FIVEMINUTE":
						code = DurationCode.FiveMinute;
						break;
				}
			}
			return code;
		}

		#endregion ctor

		#region overloads and overrides

		[DebuggerStepThrough()]
		public static bool operator ==(OrderDuration lhs, OrderDuration rhs)
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Code == rhs.Code &&
			       lhs.Expiration == rhs.Expiration;
		}

		[DebuggerStepThrough()]
		public static bool operator !=(OrderDuration lhs, OrderDuration rhs)
		{
			return !(lhs == rhs);
		}

		[DebuggerStepThrough()]
		public bool Equals(OrderDuration token)
		{
			return this == token;
		}

		[DebuggerStepThrough()]
		public override bool Equals(object obj)
		{
			return Equals(obj as OrderDuration);
		}

		[DebuggerStepThrough()]
		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		[DebuggerStepThrough()]
		public override string ToString()
		{
			StringBuilder duration = new StringBuilder(DurationCodeToString(Code), 32);
			if (Expiration.HasValue)
			{
				DateTime expiration = (DateTime)Expiration; 
				if (expiration > DateTime.MinValue && expiration < DateTime.MaxValue)
					duration.AppendFormat(" - {0}", expiration.ToShortDateString()); 
			}
			return duration.ToString();
		}

		#endregion overloads and overrides

	}

	/// <summary>
	/// DAY - Day
	/// DYP - Day plus
	/// GTC - Good till canceled
	/// GTCP - GTC plus
	/// GTD - Good through date
	/// GTDP - GTD plus
	/// IOC
	/// FOK
	/// OPG
	/// CLO
	/// 1 - 1 minute
	/// 3 - 3 minute
	/// 5 - 5 minute
	/// </summary>
	// ReSharper disable InconsistentNaming
	public enum DurationCode
	{
		DAY,
		DAYP,
		GTC,
		GTCP,
		GTD,
		GTDP,
		IOC,
		FOK,
		OPG,
		CLO,
		OneMinute,
		ThreeMinute,
		FiveMinute
	}
	// ReSharper restore InconsistentNaming
	
}
