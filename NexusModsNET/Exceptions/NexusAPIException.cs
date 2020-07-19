using System;
using System.Net;

namespace NexusModsNET.Exceptions
{
	/// <summary>
	/// A NexusMods API exception for specific and all non success StatusCodes returned from the API server
	/// </summary>
	[Serializable]
	public class NexusAPIException : Exception
	{
		/// <summary>
		/// The Http status code returned form the API
		/// </summary>
		public HttpStatusCode StatusCode { get; }
		/// <summary>
		/// A NexusMods API exception for specific and all non success StatusCodes returned from the API server
		/// </summary>
		public NexusAPIException(HttpStatusCode statusCode) { StatusCode = statusCode; }
		/// <summary>
		/// A NexusMods API exception for specific and all non success StatusCodes returned from the API server
		/// </summary>
		public NexusAPIException(string message, HttpStatusCode statusCode) : base(message) { StatusCode = statusCode; }
		/// <summary>
		/// A NexusMods API exception for specific and all non success StatusCodes returned from the API server
		/// </summary>
		public NexusAPIException(string message, HttpStatusCode statusCode, Exception inner) : base(message, inner) { StatusCode = statusCode; }
	}
}
