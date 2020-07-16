using System;

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
		public GoneException() { }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public GoneException(string message) : base(message) { }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public GoneException(string message, Exception inner) : base(message, inner) { }
	}
}
