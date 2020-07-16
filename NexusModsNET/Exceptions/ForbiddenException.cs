using System;

namespace NexusModsNET.Exceptions
{
	/// <summary>
	/// <inheritdoc/>
	/// </summary>
	[Serializable]
	public class ForbiddenException : NexusAPIException
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public ForbiddenException() { }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public ForbiddenException(string message) : base(message) { }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public ForbiddenException(string message, Exception inner) : base(message, inner) { }
	}
}
