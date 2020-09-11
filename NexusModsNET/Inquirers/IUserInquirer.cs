using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NexusModsNET.DataModels;

namespace NexusModsNET.Inquirers
{
	/// <summary>
	/// Routes specific to the current user assigned to this API Key
	/// </summary>
	public interface IUserInquirer : IDisposable
	{
		/// <summary>
		/// Returns a list of all endorsements for the current user
		/// </summary>
		/// <param name="cancellationToken">Enables cancellation of the Http request</param>
		/// <returns></returns>
		Task<IEnumerable<NexusUserEndorsement>> GetEndorsementsAsync(CancellationToken cancellationToken = default);
		/// <summary>
		/// Fetch all the mods being tracked by the current user
		/// </summary>
		/// <param name="cancellationToken">Enables cancellation of the Http request</param>
		/// <returns></returns>
		Task<IEnumerable<NexusUserTrackedMod>> GetTrackedModsAsync(CancellationToken cancellationToken = default);
		/// <summary>
		/// Checks an API key is valid and returns the user's details
		/// </summary>
		/// <param name="cancellationToken">Enables cancellation of the Http request</param>
		/// <returns></returns>
		Task<NexusUser> GetUserAsync(CancellationToken cancellationToken = default);
		/// <summary>
		/// Track a specified mod with the current user
		/// </summary>
		/// <param name="game_domain">The game domain name</param>
		/// <param name="modId">The mod Id</param>
		/// <param name="cancellationToken">Enables cancellation of the Http request</param>
		/// <returns></returns>
		Task<NexusMessage> TrackModAsync(string game_domain, long modId, CancellationToken cancellationToken = default);
		/// <summary>
		/// Stop tracking this mod with the current user
		/// </summary>
		/// <param name="game_domain">The game domain name</param>
		/// <param name="modId">The mod Id</param>
		/// <param name="cancellationToken">Enables cancellation of the Http request</param>
		/// <returns></returns>
		Task<NexusMessage> UnTrackModAsync(string game_domain, long modId, CancellationToken cancellationToken = default);
	}
}