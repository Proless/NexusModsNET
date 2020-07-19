using System;
using System.Net;
using NexusModsNET.Internals;

namespace NexusModsNET.Exceptions
{
	/// <summary>
	/// This exception is thrown whenever the Max-Limits set using the <see cref="QuotaManagement"/> are reached.
	/// </summary>
	public class UserLimitsExceededException : QuotaLimitsExceededException
	{
		/// <summary>
		/// This exception is thrown whenever the Max-Limits set using the <see cref="QuotaManagement"/> are reached.
		/// </summary>
		/// <param name="statusCode"></param>
		public UserLimitsExceededException(HttpStatusCode statusCode) : base(statusCode)
		{
		}
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		/// <param name="message"></param>
		/// <param name="statusCode"></param>
		public UserLimitsExceededException(string message, HttpStatusCode statusCode) : base(message, statusCode)
		{
		}
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		/// <param name="message"></param>
		/// <param name="statusCode"></param>
		/// <param name="inner"></param>
		public UserLimitsExceededException(string message, HttpStatusCode statusCode, Exception inner) : base(message, statusCode, inner)
		{
		}
	}
}
