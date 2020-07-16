using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NexusModsNET.Internals;

namespace NexusModsNET.Inquirers
{
	/// <summary>
	/// A custom inquirer which can be used for custom endpoints.
	/// </summary>
	public class CustomInquirer : InquirerBase
	{
		/// <summary>
		/// A custom inquirer which can be used for custom endpoints.
		/// </summary>
		/// <param name="client">The NexusMods client to use for requests</param>
		public CustomInquirer(NexusModsAPIClient client) : base(client) { }

		/// <summary>
		/// Sends Http requests and deserializes the response content to the specified .NET type
		/// </summary>
		/// <typeparam name="T">The .NET type to deserialize the returned JSON</typeparam>
		/// <param name="uri">The request URL</param>
		/// <param name="httpMethod">The type of the request</param>
		/// <param name="acceptedMediaType">The accepted response message format, default is application/json</param>
		/// <param name="cancellationToken">Enables cancellation of the Http request</param>
		/// <param name="httpContent">The Http request message content (form, etc.)</param>
		/// <returns>Returns the deserialized JSON response as the specified .NET type</returns>
		public Task<T> SendAsync<T>(Uri uri, HttpMethod httpMethod, string acceptedMediaType = "application/json", CancellationToken cancellationToken = default, HttpContent httpContent = null)
		{
			var httpRequestMessage = _client.ConstructHttpRequestMessage(httpMethod, uri, httpContent, acceptedMediaType);
			return _client.ProcessRequestAsync<T>(httpRequestMessage, cancellationToken);
		}
	}
}
