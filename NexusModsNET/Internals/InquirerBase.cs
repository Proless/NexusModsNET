using System;

namespace NexusModsNET.Internals
{
	/// <summary>
	/// A base class for all Inquirer, which is used internally
	/// </summary>
	public class InquirerBase
	{
		#region Fields
		internal INexusModsClient _client;
		#endregion

		#region Properties
		/// <summary>
		/// A manger to get or manage the limits of the API.
		/// </summary>
		public IRateLimitsManagement RateLimitsManagement { get { return _client.RateLimitsManagement; } }
		#endregion

		#region Constructors
		internal InquirerBase(INexusModsClient client)
		{
			_client = client ?? throw new ArgumentNullException(nameof(client));
		}
		#endregion

		#region Helpers
		internal Uri ConstructRequestURI(string route, params string[] routeParams)
		{
			Uri output;
			string formattedRoute = string.Format(route, routeParams);
			output = new Uri(new Uri(Routes.BaseAPIURL), formattedRoute);
			return output;
		}
		#endregion
	}
}
