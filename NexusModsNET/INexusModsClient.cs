using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NexusModsNET
{
	/// <summary>
	///  A HttpClient Interface for the nexusmods.com API.
	/// </summary>
	public interface INexusModsClient : IDisposable
	{
		/// <summary>
		/// The user's API authentication key.
		/// </summary>
		string APIKey { get; }
		/// <summary>
		/// The application name, this will be sent with each call to the Web API.
		/// </summary>
		string ProductName { get; }
		/// <summary>
		/// The application version, this will be sent with each call to the API.
		/// </summary>
		string ProductVersion { get; }
		/// <summary>
		/// A manger to get or manage the limits of the API.
		/// </summary>
		IRateLimitsManagement RateLimitsManagement { get; }
		/// <summary>
		/// The client User agent string sent with each Http request.
		/// </summary>
		string UserAgent { get; }
		/// <summary>
		/// Creates a new HttpRequestMessage
		/// </summary>
		/// <param name="method">The type of the request</param>
		/// <param name="requestURI">The request URL</param>
		/// <param name="httpContent">The Http request message content (form, etc.)</param>
		/// <param name="acceptedMediaType">The accepted response message format, default is application/json</param>
		/// <returns></returns>
		HttpRequestMessage ConstructHttpRequestMessage(Uri requestURI, HttpMethod method, HttpContent httpContent = null, string acceptedMediaType = null);
		/// <summary>
		/// Sends Http requests and deserializes the response content to the specified .NET type
		/// </summary>
		/// <typeparam name="T">The .NET type to deserialize the Json</typeparam>
		/// <param name="requestMessage">The http request message to send</param>
		/// <param name="cancellationToken">Enables cancellation of the Http request</param>
		/// <returns>The deserialized JSON response content as the specified .NET type</returns>
		Task<T> ProcessRequestAsync<T>(HttpRequestMessage requestMessage, CancellationToken cancellationToken = default);
		/// <summary>
		/// Sends Http requests and deserializes the response content to the specified .NET type
		/// </summary>
		/// <typeparam name="T">The .NET type to deserialize the Json</typeparam>
		/// <param name="requestURI">The full request URL</param>
		/// <param name="method">The type of the Http request</param>
		/// <param name="cancellationToken">Enables cancellation of the Http request</param>
		/// <param name="formData">The encoded form data to send with the Http request to the API server</param>
		/// <returns>The deserialized JSON response content as the specified .NET type</returns>
		Task<T> ProcessRequestAsync<T>(Uri requestURI, HttpMethod method, CancellationToken cancellationToken = default, HttpContent formData = null);
	}
}