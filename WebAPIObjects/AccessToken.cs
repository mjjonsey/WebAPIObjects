using System;
using System.Diagnostics;
//using System.Threading; 
using System.Timers;

namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	public class AccessToken
	{
		#region ctor

		public AccessToken()
		{
			//_timer = new Timer(Timer_Tick, null, 1000, 1000);
			_timer = new Timer { AutoReset = true, Interval = 1000, Enabled = true };
			_timer.Elapsed += Timer_Tick;





		}

		#endregion ctor

		#region event
		public event EventHandler ExpirationWarning;

		protected void OnExpirationWarning(object sender, EventArgs args)
		{
			if (ExpirationWarning != null)
			{
				ExpirationWarning(sender, args);

			}
		}

		private void Timer_Tick(object sender, ElapsedEventArgs args)
		{
			if (_expirationDate > DateTime.MinValue && _expirationDate.Subtract(DateTime.Now).TotalSeconds <= 120 && !_hasExpirationWarningFired)
			{
				_hasExpirationWarningFired = true;
				OnExpirationWarning(this, EventArgs.Empty);
			}
		}

		#endregion event

		#region properties
		private bool _hasExpirationWarningFired;
		private readonly Timer _timer;
		private DateTime _expirationDate = DateTime.MinValue;

		public DateTime ExpirationDate
		{
			get { return _expirationDate; }

		}

		public int ExpiresIn
		{
			get
			{
				if (_expirationDate == DateTime.MinValue) return 0;

				return (int)_expirationDate.Subtract(DateTime.Now).TotalSeconds;
			}
			set
			{
				_expirationDate = DateTime.Now.AddSeconds(value);
				_hasExpirationWarningFired = false;
			}
		}
		public string Token { get; set; }
		public string UserId { get; set; }
		public string Type { get; set; }	// Added in V2

		public static AccessToken Empty { get { return new AccessToken(); } }
		#endregion properties

		#region overloads and overrides

		[DebuggerStepThrough()]
		public static bool operator ==(AccessToken lhs, AccessToken rhs)
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;

			return lhs.ExpiresIn == rhs.ExpiresIn &&
				   lhs.Token == rhs.Token &&
				   lhs.UserId == rhs.UserId &&
				   lhs.Type == rhs.Type;
		}

		[DebuggerStepThrough()]
		public static bool operator !=(AccessToken lhs, AccessToken rhs)
		{
			return !(lhs == rhs);
		}

		[DebuggerStepThrough()]
		public bool Equals(AccessToken token)
		{
			return this == token;
		}

		[DebuggerStepThrough()]
		public override bool Equals(object obj)
		{
			AccessToken token = obj as AccessToken;
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
			return string.Format("Access Token for {0}: {1}", UserId, Token);
		}

		#endregion overloads and overrides
	}


}

