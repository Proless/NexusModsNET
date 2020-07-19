using System;
using System.Net;

namespace NexusModsNET.Exceptions
{
	/// <summary>
	/// <inheritdoc/>
	/// </summary>
	[Serializable]
	public class NotFoundException : NexusAPIException
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public NotFoundException(HttpStatusCode statusCode) : base(statusCode) { }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public NotFoundException(string message, HttpStatusCode statusCode) : base(message, statusCode) { }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public NotFoundException(string message, HttpStatusCode statusCode, Exception inner) : base(message, statusCode, inner) { }
	}
}
