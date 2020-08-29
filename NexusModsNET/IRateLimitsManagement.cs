using System;
using NexusModsNET.DataModels;
using NexusModsNET.Exceptions;

namespace NexusModsNET
{
	/// <summary>
	/// Manges the API Limits.
	/// </summary>
	public interface IRateLimitsManagement
	{
		/// <summary>
		/// The current reached limits of the API.
		/// </summary>
		NexusApiLimits APILimits { get; }
		/// <summary>
		/// Gets or sets the max daily requests before throwing a <see cref="LimitsExceededException"/>
		/// <br/> The Limit defined by the API is 2500 Daily. Default is 2500.
		/// </summary>
		int CustomDailyLimit { get; set; }
		/// <summary>
		/// Gets or sets the max hourly requests before throwing a <see cref="LimitsExceededException"/>
		/// <br/> The Limit defined by the API is 100 Hourly. Default is 100.
		/// </summary>
		int CustomHourlyLimit { get; set; }
		/// <summary>
		/// Determines whether to throw an exception if a limit has been exceeded.Default is true.
		/// </summary>
		bool ThrowOnCustomLimitsExceeded { get; set; }
		/// <summary>
		/// Indicates the Daily limits has been exceeded.
		/// </summary>
		event EventHandler<LimitType> DailyLimitsExceeded;
		/// <summary>
		/// Indicates the Hourly limits has been exceeded.
		/// </summary>
		event EventHandler<LimitType> HourlyLimitsExceeded;
	}
}