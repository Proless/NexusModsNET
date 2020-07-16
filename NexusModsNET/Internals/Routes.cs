namespace NexusModsNET.Internals
{
	internal static class Routes
	{
		/// <summary>
		/// The NexusMods.com API Base URL
		/// </summary>
		public static string BaseAPIURL => "https://api.nexusmods.com";
		/// <summary>
		/// Routes specific to the current user assigned to this API Key
		/// </summary>
		public static UserRoutes User { get; } = new UserRoutes();
		/// <summary>
		/// Retrieve game information
		/// </summary>
		public static GamesRoute Games { get; } = new GamesRoute();
		/// <summary>
		/// File specific routes (E.g. retrieving file information, retrieving download link)
		/// </summary>
		public static ModFilesRoutes ModFiles { get; } = new ModFilesRoutes();
		/// <summary>
		/// Mod specific routes (E.g. retrieving latest mods, endorsing a mod)
		/// </summary>
		public static ModsRoutes Mods { get; } = new ModsRoutes();
		/// <summary>
		/// Routes specific to retrieve information regarding colour-specific themes for games
		/// </summary>
		public static ColourSchemesRoutes ColourSchemes { get; } = new ColourSchemesRoutes();
	}

	/// <summary>
	/// Routes specific to the current user assigned to this API Key
	/// </summary>
	internal class UserRoutes
	{
		/// <summary>
		/// Checks an API key is valid and returns the user's details
		/// </summary>
		public string Validate => "/v1/users/validate.json";
		/// <summary>
		/// Returns a list of all endorsements for the current user
		/// </summary>
		public string Endorsements => "/v1/user/endorsements.json";
		/// <summary>
		/// Fetch all the mods being tracked by the current user
		/// </summary>
		public string TrackedMods_GET => "/v1/user/tracked_mods.json";
		/// <summary>
		/// Track this mod with the current user
		/// </summary>
		public string TrackedMods_TRACK => "/v1/user/tracked_mods.json";
		/// <summary>
		/// Stop tracking this mod with the current user
		/// </summary>
		public string TrackedMods_UNTRACK => "/v1/user/tracked_mods.json";

	}

	/// <summary>
	/// Routes specific to retrieve information regarding colour-specific themes for games
	/// </summary>
	internal class ColourSchemesRoutes
	{
		/// <summary>
		/// Returns list of all colour schemes, including the primary, secondary and 'darker' colours.
		/// </summary>
		public string ColourSchemes => "/v1/colourschemes.json";
	}

	/// <summary>
	/// Retrieve game information
	/// </summary>
	internal class GamesRoute
	{
		/// <summary>
		/// Returns a list of all games, optionally can also return unapproved games.
		/// </summary>
		public string Games_GETAll => "/v1/games.json";
		/// <summary>
		/// Returns a specified game, along with download count, file count and categories.
		/// </summary>
		public string Games_GETOne => "/v1/games/{0}.json";
	}

	/// <summary>
	/// File specific routes (E.g. retrieving file information, retrieving download link)
	/// </summary>
	internal class ModFilesRoutes
	{
		/// <summary>
		/// Lists all files for a specific mod
		/// </summary>
		public string Files => "/v1/games/{0}/mods/{1}/files.json";
		/// <summary>
		/// View a specified mod file, using a specified game and mod
		/// </summary>
		public string File => "/v1/games/{0}/mods/{1}/files/{2}.json";
		/// <summary>
		/// Looks up a file MD5 file hash
		/// </summary>
		public string FileHash => "/v1/games/{0}/mods/md5_search/{1}.json";
		/// <summary>
		/// Generate download link for mod file. For premium users, will return array of download links with their preferred download location in the first element.
		/// NOTE: Non-premium members must provide the key and expiry from the .nxm link provided by the website.
		/// It is recommended for clients to extract them from the NXM link before sending this request.
		/// This ensures that all non-premium members must access the website to download through the API.
		/// </summary>
		public string DownloadLink => "/v1/games/{0}/mods/{1}/files/{2}/download_link.json";
	}
	/// <summary>
	/// Mod specific routes (E.g. retrieving latest mods, endorsing a mod)
	/// </summary>
	internal class ModsRoutes
	{
		/// <summary>
		/// Returns a list of mods that have been updated in a given period, with timestamps of their last update. Cached for 5 minutes.
		/// </summary>
		public string Updated => "/v1/games/{0}/mods/updated.json";
		/// <summary>
		/// Returns list of change logs for a mod
		/// </summary>
		public string ChangeLogs => "/v1/games/{0}/mods/{1}/changelogs.json";
		/// <summary>
		/// Retrieve 10 latest added mods for a specified game
		/// </summary>
		public string LatestAdded => "/v1/games/{0}/mods/latest_added.json";
		/// <summary>
		/// Retrieve 10 latest updated mods for a specified game
		/// </summary>
		public string LatestUpdated => "/v1/games/{0}/mods/latest_updated.json";
		/// <summary>
		/// Retrieve 10 trending mods for a specified game
		/// </summary>
		public string Trending => "/v1/games/{0}/mods/trending.json";
		/// <summary>
		/// Retrieve specified mod, from a specified game. Cached for 5 minutes.
		/// </summary>
		public string Mod => "/v1/games/{0}/mods/{1}.json";
		/// <summary>
		/// Endorse a mod
		/// </summary>
		public string Endorse => "/v1/games/{0}/mods/{1}/endorse.json";
		/// <summary>
		/// Abstain from endorsing a mod
		/// </summary>
		public string Abstain => "/v1/games/{0}/mods/{1}/abstain.json";
	}

}
