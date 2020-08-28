using NexusModsNET.DataModels;
using NexusModsNET.Exceptions;

namespace NexusModsNET
{
	/// <summary>
	/// Manges the API Limits
	/// </summary>
	public class QuotaManagement
	{
		#region Fields
		private int _customDailyLimit;
		private int _customHourlyLimit;
		#endregion

		#region Properties
		/// <summary>
		/// The current reached limits of the API.
		/// </summary>
		public NexusQuotaLimits APILimits { get; internal set; }
		/// <summary>
		/// Gets or sets the max possible daily requests before throwing a <see cref="QuotaLimitsExceededException"/>
		/// <br/> The Limit defined by the API is 2500 Daily.
		/// </summary>
		public int CustomDailyLimit
		{
			get => _customDailyLimit;
			set
			{
				if (value > 2500 || value < 0)
				{
					_customDailyLimit = 2500;
				}
				else
				{
					_customDailyLimit = value;
				}

			}
		}
		/// <summary>
		/// Gets or sets the max possible hourly requests before throwing a <see cref="QuotaLimitsExceededException"/>
		/// <br/> The Limit defined by the API is 100 Hourly.
		/// </summary>
		public int CustomHourlyLimit
		{
			get => _customHourlyLimit;
			set
			{
				if (value > 100 || value < 0)
				{
					_customHourlyLimit = 100;
				}
				else
				{
					_customHourlyLimit = value;
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
			CustomDailyLimit = 100;
			CustomHourlyLimit = 2500;
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
			var customLimit = APILimits?.DailyLimit - APILimits?.DailyRemaining >= CustomDailyLimit;
			var apiLimit = APILimits?.DailyRemaining <= 0;
			return customLimit || apiLimit;
		}
		private bool HourlyLimitsExceeded()
		{
			var customLimit = APILimits?.HourlyLimit - APILimits?.HourlyRemaining >= CustomHourlyLimit;
			var apiLimit = APILimits?.HourlyRemaining <= 0;
			return customLimit || apiLimit;
		}

		#endregion
	}
}


