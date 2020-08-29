using NexusModsNET.Exceptions;

namespace NexusModsNET
{
	/// <summary>
	/// Represents the type of the limit that caused the <see cref="LimitsExceededException"/>
	/// </summary>
	public enum LimitType
	{
		/// <summary>
		/// The official API Limits
		/// </summary>
		API,
		/// <summary>
		/// The custom Limits set using the <see cref="RateLimitsManagement"/>
		/// </summary>
		Custom
	}
}
