using System;

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
		public NotFoundException() { }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public NotFoundException(string message) : base(message) { }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public NotFoundException(string message, Exception inner) : base(message, inner) { }
	}
}
