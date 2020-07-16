using System;

namespace NexusModsNET.Exceptions
{
	/// <summary>
	/// <inheritdoc/>
	/// </summary>
	[Serializable]
	public class UnauthorizedException : NexusAPIException
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public UnauthorizedException() { }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public UnauthorizedException(string message) : base(message) { }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public UnauthorizedException(string message, Exception inner) : base(message, inner) { }
	}
}
