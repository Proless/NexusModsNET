using System;

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
		public BadRequestException() { }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public BadRequestException(string message) : base(message) { }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public BadRequestException(string message, Exception inner) : base(message, inner) { }
	}
}
