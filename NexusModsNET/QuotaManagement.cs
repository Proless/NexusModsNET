using NexusModsNET.DataModels;
using NexusModsNET.Exceptions;

namespace NexusModsNET.Internals
{
	/// <summary>
	/// Manges the API Limits
	/// </summary>
	public class QuotaManagement
	{
		private int _maxDailyLimit;
		private int _maxHourlyLimit;
		#region Fields

		#endregion

		#region Properties
		/// <summary>
		/// The limits defined by the NexusMods API.
		/// </summary>
		public NexusQuotaLimits APILimits { get; internal set; }
		/// <summary>
		/// Gets or sets the max possible daily requests before throwing a <see cref="QuotaLimitsExceededException"/>
		/// <br/> The Limit defined by the API is 2500 Daily.
		/// </summary>
		public int MaxDailyLimit
		{
			get => _maxDailyLimit;
			set
			{
				if (value > 2500 || value < 0)
				{
					_maxDailyLimit = 2500;
				}
				else
				{
					_maxDailyLimit = value;
				}

			}
		}
		/// <summary>
		/// Gets or sets the max possible hourly requests before throwing a <see cref="QuotaLimitsExceededException"/>
		/// <br/> The Limit defined by the API is 100 Hourly.
		/// </summary>
		public int MaxHourlyLimit
		{
			get => _maxHourlyLimit;
			set
			{
				if (value > 100 || value < 0)
				{
					_maxHourlyLimit = 100;
				}
				else
				{
					_maxHourlyLimit = value;
				}
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Manges the API Limits.
		/// </summary>
		public QuotaManagement()
		{
			MaxDailyLimit = 100;
			MaxHourlyLimit = 2500;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Determines whether the API and custom Limits have been exceeded and no request can be made to the API server
		/// </summary>
		/// <returns></returns>
		public bool LimitsExceeded()
		{
			return DailyLimitsExceeded() && HourlyLimitsExceeded();
		}
		private bool DailyLimitsExceeded()
		{
			var customLimit = APILimits?.DailyLimit - APILimits?.DailyRemaining >= MaxDailyLimit;
			var apiLimit = APILimits?.DailyRemaining <= 0;
			return customLimit || apiLimit;
		}
		private bool HourlyLimitsExceeded()
		{
			var customLimit = APILimits?.HourlyLimit - APILimits?.HourlyRemaining >= MaxHourlyLimit;
			var apiLimit = APILimits?.HourlyRemaining <= 0;
			return customLimit || apiLimit;
		}

		#endregion
	}
}


