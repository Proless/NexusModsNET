using System;
using System.Net;

namespace NexusModsNET.Exceptions
{
	/// <summary>
	/// <inheritdoc/>
	/// </summary>
	[Serializable]
	public class GoneException : NexusAPIException
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public GoneException(HttpStatusCode statusCode) : base(statusCode) { }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public GoneException(string message, HttpStatusCode statusCode) : base(message, statusCode) { }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public GoneException(string message, HttpStatusCode statusCode, Exception inner) : base(message, statusCode, inner) { }
	}
}
