using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NexusModsNET.DataModels;
using NexusModsNET.Internals;

namespace NexusModsNET.Inquirers
{
	/// <summary>
	/// Routes specific to the current user assigned to this API Key
	/// </summary>
	public class UserInquirer : InquirerBase, IUserInquirer
	{
		/// <summary>
		/// Routes specific to the current user assigned to this API Key
		/// </summary>
		/// <param name="client">The NexusMods client to use for this endpoint</param>
		public UserInquirer(INexusModsClient client) : base(client) { }

		/// <summary>
		/// Checks an API key is valid and returns the user's details
		/// </summary>
		/// <param name="cancellationToken">Enables cancellation of the Http request</param>
		/// <returns></returns>
		public Task<NexusUser> GetUserAsync(CancellationToken cancellationToken = default)
		{
			var requestUri = ConstructRequestURI(Routes.User.Validate);
			return _client.ProcessRequestAsync<NexusUser>(requestUri, HttpMethod.Get, cancellationToken);
		}

		/// <summary>
		/// Returns a list of all endorsements for the current user
		/// </summary>
		/// <param name="cancellationToken">Enables cancellation of the Http request</param>
		/// <returns></returns>
		public Task<IEnumerable<NexusUserEndorsement>> GetEndorsementsAsync(CancellationToken cancellationToken = default)
		{
			var requestUri = ConstructRequestURI(Routes.User.Endorsements);
			return _client.ProcessRequestAsync<IEnumerable<NexusUserEndorsement>>(requestUri, HttpMethod.Get, cancellationToken);
		}

		/// <summary>
		/// Fetch all the mods being tracked by the current user
		/// </summary>
		/// <param name="cancellationToken">Enables cancellation of the Http request</param>
		/// <returns></returns>
		public Task<IEnumerable<NexusUserTrackedMod>> GetTrackedModsAsync(CancellationToken cancellationToken = default)
		{
			var requestUri = ConstructRequestURI(Routes.User.TrackedMods_GET);
			return _client.ProcessRequestAsync<IEnumerable<NexusUserTrackedMod>>(requestUri, HttpMethod.Get, cancellationToken);
		}

		/// <summary>
		/// Track a specified mod with the current user
		/// </summary>
		/// <param name="game_domain">The game domain name</param>
		/// <param name="modId">The mod Id</param>
		/// <param name="cancellationToken">Enables cancellation of the Http request</param>
		/// <returns></returns>
		public Task<NexusMessage> TrackModAsync(string game_domain, long modId, CancellationToken cancellationToken = default)
		{
			var requestUri = ConstructRequestURI(Routes.User.TrackedMods_TRACK).AddQuery("domain_name", game_domain);

			var formData = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("mod_id", modId.ToString()) });

			return _client.ProcessRequestAsync<NexusMessage>(requestUri, HttpMethod.Post, cancellationToken, formData);
		}

		/// <summary>
		/// Stop tracking this mod with the current user
		/// </summary>
		/// <param name="game_domain">The game domain name</param>
		/// <param name="modId">The mod Id</param>
		/// <param name="cancellationToken">Enables cancellation of the Http request</param>
		/// <returns></returns>
		public Task<NexusMessage> UnTrackModAsync(string game_domain, long modId, CancellationToken cancellationToken = default)
		{
			var requestUri = ConstructRequestURI(Routes.User.TrackedMods_UNTRACK).AddQuery("domain_name", game_domain);

			var formData = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("mod_id", modId.ToString()) });

			return _client.ProcessRequestAsync<NexusMessage>(requestUri, HttpMethod.Delete, cancellationToken, formData);
		}
	}
}
