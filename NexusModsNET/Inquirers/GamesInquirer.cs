using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NexusModsNET.DataModels;
using NexusModsNET.Internals;

namespace NexusModsNET.Inquirers
{
	/// <summary>
	/// Routes specific to retrieve information regarding supported games
	/// </summary>
	public class GamesInquirer : InquirerBase
	{
		/// <summary>
		/// Routes specific to retrieve information regarding supported games
		/// </summary>
		/// <param name="client">The NexusMods client to use for this endpoint</param>
		public GamesInquirer(INexusModsClient client) : base(client) { }

		/// <summary>
		/// Returns an <see cref="IEnumerable{T}"/> of all games, optionally can also return unapproved games
		/// </summary>
		/// <param name="include_unapproved">Determines whether to include unapproved games or not</param>
		/// <param name="cancellationToken">Enables cancellation of the Http request</param>
		/// <returns></returns>
		public Task<IEnumerable<NexusGame>> GetGamesAsync(bool include_unapproved = false, CancellationToken cancellationToken = default)
		{
			var requestUri = ConstructRequestURI(Routes.Games.Games_GETAll).AddQuery("include_unapproved", include_unapproved.ToString().ToLower());
			return _client.ProcessRequestAsync<IEnumerable<NexusGame>>(requestUri, HttpMethod.Get, cancellationToken);
		}

		/// <summary>
		/// Returns a specified game, along with download count, file count and categories.
		/// </summary>
		/// <param name="game_domain">The game domain name</param>
		/// <param name="cancellationToken">Enables cancellation of the Http request</param>
		/// <returns></returns>
		public Task<NexusGame> GetGameAsync(string game_domain, CancellationToken cancellationToken = default)
		{
			var requestUri = ConstructRequestURI(Routes.Games.Games_GETOne, game_domain);
			return _client.ProcessRequestAsync<NexusGame>(requestUri, HttpMethod.Get, cancellationToken);
		}
	}
}
