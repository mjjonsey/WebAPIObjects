using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	public enum AssetType
	{
		EQ,
		OP,
		FU,
		FX, 
		IX, 
		UK
	}

	
	public enum BarIntervalUnit
	{	Tick, 
		Second, 
		Minute, 
		Daily, 
		Weekly, 
		Monthly
	}

	[Flags]
	public enum Level2Book
	{
		All = 127, //ARCA + BATS + BATY + BOSX + BTRD + EDGA + EDGX
		ARCA = 1, 
		BATS = 2, 
		BATY = 4, 
		BOSX = 8, 
		BTRD = 16, 
		EDGA = 32, 
		EDGX = 64
	}

	public enum Level2Status
	{
		Update, 
		Closed, 
		Removed, 
		New, 
		ECN, 
		Stale, 
		ECN_BOOK
	}

	public enum WebAPIEnvironment
	{ 
		SIM, 
		Live
	}

	/// <summary>
	/// OPN, ACK, UCN = Open Orders
	/// FLL, FLP = Filled Orders
	/// FPR = Partially Filled Orders
	/// OUT = Canceled Orders
	/// REJ, TSC = Rejected Orders
	/// EXP = Expired Orders
	/// BRO = Broken Orders
	/// CAN = Exch. Canceled Orders
	/// LAT = Too Late Orders
	/// DON = Queued Orders
	/// </summary>
	public enum OrderState
	{
		OPN, ACK, UCN,
		FLL, FLP,
		FPR,
		OUT,
		REJ, TSC,
		EXP,
		BRO,
		CAN,
		LAT,
		DON
	}

	public enum OrderType
	{
		Limit,
		Market,
		StopLimit,
		StopMarket,
		Invalid,
	}

	public enum PriceType
	{ 
		Bid, 
		Ask
	}

	public enum Route
	{
		/*EQ*/
		Intelligent,
		AMEX,
		ARCA,
		AUTO,
		BATS,
		BTRD,
		CTDL,
		EDGA,
		EDGX,
		GFLO,
		NITE,
		NQBX,
		NSDQ,
		NYSE,
		/*OP*/
		AMOP,
		BOX,
		CBOE,
		ISE,
		NYOP,
		PHLX,
		XNDQ
	}

	/// <summary>
	/// buy - EQ, FU, FX
	/// sell - EQ, FU, FX
	/// buytocover - EQ
	/// sellshort - EQ
	/// buytoopen - OP
	/// buytoclose - OP
	/// selltoopen - OP
	/// selltoclose - OP
	/// </summary>
	public enum TradeAction
	{
		Buy,
		Sell,
		BuyToCover,
		SellShort,
		BuyToOpen,
		BuyToClose,
		SellToOpen,
		SellToClose
	}
}
