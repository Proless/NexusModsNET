﻿using System;

namespace NexusModsNET.DataModels
{
	public class NexusApiLimits
	{
		public int HourlyLimit { get; internal set; } = 100;
		public int HourlyRemaining { get; internal set; } = 100;
		public DateTime HourlyReset { get; internal set; }
		public int DailyLimit { get; internal set; } = 2500;
		public int DailyRemaining { get; internal set; } = 2500;
		public DateTime DailyReset { get; internal set; }
	}
}
