using System;
using System.Net;

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
		public QuotaLimitsExceededException(HttpStatusCode statusCode) : base(statusCode) { }
		/// <summary>
		/// This Exception is thrown whenever a Limit has been exceeded
		/// </summary>
		public QuotaLimitsExceededException(string message, HttpStatusCode statusCode) : base(message, statusCode) { }
		/// <summary>
		/// This Exception is thrown whenever a Limit has been exceeded
		/// </summary>
		public QuotaLimitsExceededException(string message, HttpStatusCode statusCode, Exception inner) : base(message, statusCode, inner) { }
	}
}
