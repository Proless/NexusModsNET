using System;

namespace NexusModsNET.Exceptions
{
	/// <summary>
	/// This Exception is thrown whenever a Limit has been exceeded
	/// </summary>
	[Serializable]
	public class QuotaLimitsExceededException : NexusAPIException
	{
		/// <summary>
		/// This Exception is thrown whenever a Limit has been exceeded
		/// </summary>
		public QuotaLimitsExceededException() { }
		/// <summary>
		/// This Exception is thrown whenever a Limit has been exceeded
		/// </summary>
		public QuotaLimitsExceededException(string message) : base(message) { }
		/// <summary>
		/// This Exception is thrown whenever a Limit has been exceeded
		/// </summary>
		public QuotaLimitsExceededException(string message, Exception inner) : base(message, inner) { }
	}
}
