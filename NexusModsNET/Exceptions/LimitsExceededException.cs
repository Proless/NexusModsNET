using System;
using System.Net;

namespace NexusModsNET.Exceptions
{
	/// <summary>
	/// This Exception is thrown whenever a Limit has been exceeded
	/// </summary>
	[Serializable]
	public class LimitsExceededException : NexusAPIException
	{
		/// <summary>
		/// The type of the limits that were exceeded.
		/// </summary>
		public LimitType LimitType { get; }
		/// <summary>
		/// This Exception is thrown whenever a Limit has been exceeded
		/// </summary>
		public LimitsExceededException(HttpStatusCode statusCode, LimitType limitType) : base(statusCode)
		{
			LimitType = limitType;
		}
		/// <summary>
		/// This Exception is thrown whenever a Limit has been exceeded
		/// </summary>
		public LimitsExceededException(string message, HttpStatusCode statusCode, LimitType limitType) : base(message, statusCode)
		{
			LimitType = limitType;
		}
	}
}
