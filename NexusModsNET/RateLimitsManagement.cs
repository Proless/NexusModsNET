using System;
using NexusModsNET.DataModels;

namespace NexusModsNET
{
	/// <summary>
	/// Manges the API Limits
	/// </summary>
	public class RateLimitsManagement : IRateLimitsManagement
	{
		#region Fields
		private int _customDailyLimit;
		private int _customHourlyLimit;
		NexusApiLimits _apiLimits;
		#endregion

		#region Events
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public event EventHandler<LimitType> DailyLimitsExceeded;
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public event EventHandler<LimitType> HourlyLimitsExceeded;
		#endregion

		#region Properties
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public NexusApiLimits APILimits
		{
			get => _apiLimits;
			internal set
			{
				_apiLimits = value ?? _apiLimits;
				CheckLimitsAndRaiseIfExceeded();
			}
		}
		/// <summary>
		/// <inheritdoc/>
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
		/// <inheritdoc/>
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
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public bool ThrowOnCustomLimitsExceeded { get; set; } = true;
		#endregion

		#region Constructors
		/// <summary>
		/// Instantiate a new instance of the <see cref="RateLimitsManagement"/>
		/// </summary>
		public RateLimitsManagement()
		{
			APILimits = new NexusApiLimits();
			CustomDailyLimit = 2500;
			CustomHourlyLimit = 100;
		}
		#endregion

		#region Helpers
		private void CheckLimitsAndRaiseIfExceeded()
		{
			if (this.ApiHourlyLimitExceeded())
			{
				HourlyLimitsExceeded?.Invoke(this, LimitType.API);
				return;
			}

			if (this.CustomHourlyLimitExceeded())
			{
				HourlyLimitsExceeded?.Invoke(this, LimitType.Custom);
				return;
			}

			if (this.ApiDailyLimitExceeded())
			{
				DailyLimitsExceeded?.Invoke(this, LimitType.API);
				return;
			}

			if (this.CustomDailyLimitExceeded())
			{
				DailyLimitsExceeded?.Invoke(this, LimitType.Custom);
				return;
			}
		}
		#endregion
	}
}


