using System;

namespace NexusModsNET.Internals
{
	public class InquirerBase
	{
		#region Fields
		internal NexusModsAPIClient _client;
		#endregion

		#region Properties
		#endregion

		#region Constructors
		internal InquirerBase(NexusModsAPIClient client)
		{
			_client = client;
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
