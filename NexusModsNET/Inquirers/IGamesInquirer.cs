using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NexusModsNET.DataModels;

namespace NexusModsNET.Inquirers
{
	/// <summary>
	/// Routes specific to retrieve information regarding supported games
	/// </summary>
	public interface IGamesInquirer
	{
		/// <summary>
		/// Returns a specified game, along with download count, file count and categories.
		/// </summary>
		/// <param name="game_domain">The game domain name</param>
		/// <param name="cancellationToken">Enables cancellation of the Http request</param>
		Task<NexusGame> GetGameAsync(string game_domain, CancellationToken cancellationToken = default);
		/// <summary>
		/// Returns an <see cref="IEnumerable{T}"/> of all games, optionally can also return unapproved games
		/// </summary>
		/// <param name="include_unapproved">Determines whether to include unapproved games or not</param>
		/// <param name="cancellationToken">Enables cancellation of the Http request</param>
		Task<IEnumerable<NexusGame>> GetGamesAsync(bool include_unapproved = false, CancellationToken cancellationToken = default);
	}
}