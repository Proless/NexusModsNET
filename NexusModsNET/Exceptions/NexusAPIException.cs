using System;

namespace NexusModsNET.Exceptions
{
	/// <summary>
	/// A NexusMods API exception base for specific and all non success StatusCodes returned from the API server
	/// </summary>
	[Serializable]
	public class NexusAPIException : Exception
	{
		/// <summary>
		/// A NexusMods API exception base for specific and all non success StatusCodes returned from the API server
		/// </summary>
		public NexusAPIException() { }
		/// <summary>
		/// A NexusMods API exception base for specific and all non success StatusCodes returned from the API server
		/// </summary>
		public NexusAPIException(string message) : base(message) { }
		/// <summary>
		/// A NexusMods API exception base for specific and all non success StatusCodes returned from the API server
		/// </summary>
		public NexusAPIException(string message, Exception inner) : base(message, inner) { }
	}
}
