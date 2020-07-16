using System;

namespace NexusModsNET.DataModels
{
	public class NexusQuotaLimits
	{
		// Hourly limits
		public int HourlyLimit { get; internal set; }
		public int HourlyRemaining { get; internal set; }
		public DateTime HourlyReset { get; internal set; }
		// Daily limits
		public int DailyLimit { get; internal set; }
		public int DailyRemaining { get; internal set; }
		public DateTime DailyReset { get; internal set; }
		internal NexusQuotaLimits() { }
	}
}
