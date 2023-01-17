using System;

namespace NexusModsNET.Internals
{
	/// <summary>
	/// A base class for all Inquirer, which is used internally
	/// </summary>
	public class InquirerBase : IDisposable
	{
		#region Fields
		internal readonly INexusModsClient Client;
		#endregion

		#region Properties
		/// <summary>
		/// A manger to get or manage the limits of the API.
		/// </summary>
		public IRateLimitsManagement RateLimitsManagement { get { return Client.RateLimitsManagement; } }
		#endregion

		#region Constructors
		internal InquirerBase(INexusModsClient client)
		{
			Client = client ?? throw new ArgumentNullException(nameof(client));
		}
		#endregion

		#region Helpers
		internal Uri ConstructRequestUri(string route, params string[] routeParams)
		{
			var formattedRoute = string.Format(route, routeParams);
			var output = new Uri(new Uri(Routes.BaseAPIURL), formattedRoute);
			return output;
		}
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public void Dispose()
		{
			Client.Dispose();
		}
		#endregion
	}
}
