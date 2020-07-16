using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NexusModsNET.DataModels;
using NexusModsNET.Internals;

namespace NexusModsNET.Inquirers
{
	/// <summary>
	/// Mod specific routes (E.g. retrieving latest mods, endorsing a mod)
	/// </summary>
	public class ModsInquirer : InquirerBase
	{
		/// <summary>
		/// Mod specific routes (E.g. retrieving latest mods, endorsing a mod)
		/// </summary>
		/// <param name="client">The NexusMods client to use for this endpoint</param>
		public ModsInquirer(NexusModsAPIClient client) : base(client) { }

		/// <summary>
		/// Returns an <see cref="IEnumerable{T}"/> of mods that have been updated in a given period, with timestamps of their last update.
		/// </summary>
		/// <param name="game_domain">The game domain name</param>
		/// <param name="period">The time period!</param>
		/// <param name="cancellationToken">Enables cancellation of the Http request</param>
		/// <returns></returns>
		public Task<IEnumerable<NexusModUpdate>> GetUpdatedMods(string game_domain, NexusTimePeriod period, CancellationToken cancellationToken = default)
		{
			var requestUri = ConstructRequestURI(Routes.Mods.Updated, game_domain).AddQuery("period", period.GetTimePeriod());
			return _client.ProcessRequestAsync<IEnumerable<NexusModUpdate>>(requestUri, HttpMethod.Get, cancellationToken);
		}

		/// <summary>
		/// Returns a Dictionary of all change logs for a mod
		/// </summary>
		/// <param name="game_domain">The game domain name</param>
		/// <param name="modId">The mod Id</param>
		/// <param name="cancellationToken">Enables cancellation of the Http request</param>
		/// <returns></returns>
		public Task<Dictionary<string, IEnumerable<string>>> GetModChangelogs(string game_domain, long modId, CancellationToken cancellationToken = default)
		{
			var requestUri = ConstructRequestURI(Routes.Mods.ChangeLogs, game_domain, modId.ToString());

			return _client.ProcessRequestAsync<Dictionary<string, IEnumerable<string>>>(requestUri, HttpMethod.Get, cancellationToken);
		}

		/// <summary>
		/// Returns an <see cref="IEnumerable{T}"/> of the 10 latest added mods for a specified game
		/// </summary>
		/// <param name="game_domain">The game domain name</param>
		/// <param name="cancellationToken">Enables cancellation of the Http request</param>
		/// <returns></returns>
		public Task<IEnumerable<NexusMod>> GetLatestAddedMods(string game_domain, CancellationToken cancellationToken = default)
		{
			var requestUri = ConstructRequestURI(Routes.Mods.LatestAdded, game_domain);
			return _client.ProcessRequestAsync<IEnumerable<NexusMod>>(requestUri, HttpMethod.Get, cancellationToken);
		}

		/// <summary>
		/// Returns an <see cref="IEnumerable{T}"/> of the 10 latest updated mods for a specified game
		/// </summary>
		/// <param name="game_domain">The game domain name</param>
		/// <param name="cancellationToken">Enables cancellation of the Http request</param>
		/// <returns></returns>
		public Task<IEnumerable<NexusMod>> GetLatestUpdatedMods(string game_domain, CancellationToken cancellationToken = default)
		{
			var requestUri = ConstructRequestURI(Routes.Mods.LatestUpdated, game_domain);
			return _client.ProcessRequestAsync<IEnumerable<NexusMod>>(requestUri, HttpMethod.Get, cancellationToken);
		}

		/// <summary>
		/// Returns an <see cref="IEnumerable{T}"/> of the 10 trending mods for a specified game
		/// </summary>
		/// <param name="game_domain">The game domain name</param>
		/// <param name="cancellationToken">Enables cancellation of the Http request</param>
		/// <returns></returns>
		public Task<IEnumerable<NexusMod>> GetLatestTrendingMods(string game_domain, CancellationToken cancellationToken = default)
		{
			var requestUri = ConstructRequestURI(Routes.Mods.Trending, game_domain);
			return _client.ProcessRequestAsync<IEnumerable<NexusMod>>(requestUri, HttpMethod.Get, cancellationToken);
		}

		/// <summary>
		/// Returns a specified mod, from a specified game
		/// </summary>
		/// <param name="game_domain">The game domain name</param>
		/// <param name="modId">The mod Id to retrieve</param>
		/// <param name="cancellationToken">Enables cancellation of the Http request</param>
		/// <returns></returns>
		public Task<NexusMod> GetMod(string game_domain, long modId, CancellationToken cancellationToken = default)
		{
			var requestUri = ConstructRequestURI(Routes.Mods.Mod, game_domain, modId.ToString());
			return _client.ProcessRequestAsync<NexusMod>(requestUri, HttpMethod.Get, cancellationToken);
		}

		/// <summary>
		/// Endorse a specified mod version
		/// </summary>
		/// <param name="game_domain">The game domain name</param>
		/// <param name="modId">The mod Id to retrieve</param>
		/// <param name="version">The mod version to endorse</param>
		/// <param name="cancellationToken">Enables cancellation of the Http request</param>
		/// <returns></returns>
		public Task<NexusMessage> Endorse(string game_domain, long modId, string version, CancellationToken cancellationToken = default)
		{
			var requestUri = ConstructRequestURI(Routes.Mods.Endorse, game_domain, modId.ToString());

			var formData = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("version", version) });

			return _client.ProcessRequestAsync<NexusMessage>(requestUri, HttpMethod.Post, cancellationToken, formData);
		}

		/// <summary>
		/// Abstain from endorsing a specified mod version
		/// </summary>
		/// <param name="game_domain">The game domain name</param>
		/// <param name="modId">The mod Id to retrieve</param>
		/// <param name="version">The mod version to abstain from endorsing</param>
		/// <param name="cancellationToken">Enables cancellation of the Http request</param>
		/// <returns></returns>
		public Task<NexusMessage> Abstain(string game_domain, long modId, string version, CancellationToken cancellationToken = default)
		{
			var requestUri = ConstructRequestURI(Routes.Mods.Abstain, game_domain, modId.ToString());

			var formData = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("version", version) });

			return _client.ProcessRequestAsync<NexusMessage>(requestUri, HttpMethod.Post, cancellationToken, formData);
		}
	}
}
