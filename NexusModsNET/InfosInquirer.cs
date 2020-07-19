using NexusModsNET.Inquirers;
using NexusModsNET.Internals;

namespace NexusModsNET
{
	/// <summary>
	/// Combines all other Inquirers for all available endpoints
	/// </summary>
	public class InfosInquirer : InquirerBase
	{
		#region Properties
		/// <summary>
		/// Routes specific to the current user assigned to this API Key
		/// </summary>
		public UserInquirer User { get; }
		/// <summary>
		/// Routes specific to retrieve information regarding supported games
		/// </summary>
		public GamesInquirer Games { get; }
		/// <summary>
		/// Mod specific routes (E.g. retrieving latest mods, endorsing a mod)
		/// </summary>
		public ModsInquirer Mods { get; }
		/// <summary>
		/// File specific routes (E.g. retrieving file information, retrieving download link)
		/// </summary>
		public ModFilesInquirer ModFiles { get; }
		/// <summary>
		/// Routes specific to retrieve information regarding colour-specific themes for games
		/// </summary>
		public ColourSchemesInquirer ColourSchemes { get; }
		#endregion

		/// <summary>
		/// Provides the set of different other Inquirers for all available endpoints
		/// </summary>
		/// <param name="client">The NexusMods client to use for this endpoint</param>
		public InfosInquirer(INexusModsClient client) : base(client)
		{
			// Initialize inquirers
			User = new UserInquirer(client);
			Games = new GamesInquirer(client);
			Mods = new ModsInquirer(client);
			ModFiles = new ModFilesInquirer(client);
			ColourSchemes = new ColourSchemesInquirer(client);
		}
	}
}
