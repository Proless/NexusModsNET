namespace NexusModsNET
{
	/// <summary>
	/// 
	/// </summary>
	public static class HelperExtensions
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="limits"></param>
		/// <returns></returns>
		public static bool ApiDailyLimitExceeded(this IRateLimitsManagement limits)
		{
			return limits.APILimits?.DailyRemaining <= 0;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="limits"></param>
		/// <returns></returns>
		public static bool ApiHourlyLimitExceeded(this IRateLimitsManagement limits)
		{
			return limits.APILimits?.HourlyRemaining <= 0;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="limits"></param>
		/// <returns></returns>
		public static bool CustomHourlyLimitExceeded(this IRateLimitsManagement limits)
		{
			var customLimit = limits.APILimits?.HourlyLimit - limits.APILimits?.HourlyRemaining >= limits.CustomHourlyLimit;
			return customLimit;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="limits"></param>
		/// <returns></returns>
		public static bool CustomDailyLimitExceeded(this IRateLimitsManagement limits)
		{
			var customLimit = limits.APILimits?.DailyLimit - limits.APILimits?.DailyRemaining >= limits.CustomDailyLimit;
			return customLimit;
		}
	}
}
