using System;
using System.Net;

namespace NexusModsNET.Exceptions
{
	/// <summary>
	/// <inheritdoc/>
	/// </summary>
	[Serializable]
	public class BadRequestException : NexusAPIException
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public BadRequestException(HttpStatusCode statusCode) : base(statusCode) { }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public BadRequestException(string message, HttpStatusCode statusCode) : base(message, statusCode) { }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public BadRequestException(string message, HttpStatusCode statusCode, Exception inner) : base(message, statusCode, inner) { }
	}
}
