using NexusModsNET.Inquirers;

namespace NexusModsNET
{
	/// <summary>
	/// A factory interface for creating Inquirers instances
	/// </summary>
	public interface IInquirerFactory
	{
		/// <summary>
		/// Creates a new <see cref="InfosInquirer"/> instance, which combines all available Inquirers for all API endpoints
		/// </summary>
		/// <param name="withNewClient">Determines whether to create a new NexusMods client for the new created instance of the Inquirer
		/// <br/> or reuse the same client instance created while Initializing this factory</param>
		/// <returns>A new <see cref="InfosInquirer"/> instance</returns>
		IInfosInquirer CreateInfosInquirer(bool withNewClient = false);
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		/// <param name="withNewClient">Determines whether to create a new NexusMods client for the new created instance of the Inquirer
		/// <br/> or reuse the same client instance created while Initializing this factory</param>
		/// <returns>A new <see cref="UserInquirer"/> instance</returns>
		IUserInquirer CreateUserInquirer(bool withNewClient = false);
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		/// <param name="withNewClient">Determines whether to create a new NexusMods client for the new created instance of the Inquirer
		/// <br/> or reuse the same client instance created while Initializing this factory</param>
		/// <returns>A new <see cref="GamesInquirer"/> instance</returns>
		IGamesInquirer CreateGamesInquirer(bool withNewClient = false);
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		/// <param name="withNewClient">Determines whether to create a new NexusMods client for the new created instance of the Inquirer
		/// <br/> or reuse the same client instance created while Initializing this factory</param>
		/// <returns>A new <see cref="ModsInquirer"/> instance</returns>
		IModsInquirer CreateModsInquirer(bool withNewClient = false);
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		/// <param name="withNewClient">Determines whether to create a new NexusMods client for the new created instance of the Inquirer
		/// <br/> or reuse the same client instance created while Initializing this factory</param>
		/// <returns>A new <see cref="ModFilesInquirer"/> instance</returns>
		IModFilesInquirer CreateModFilesInquirer(bool withNewClient = false);
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		/// <param name="withNewClient">Determines whether to create a new NexusMods client for the new created instance of the Inquirer
		/// <br/> or reuse the same client instance created while Initializing this factory</param>
		/// <returns>A new <see cref="ColourSchemesInquirer"/> instance</returns>
		IColourSchemesInquirer CreateColourSchemesInquirer(bool withNewClient = false);
	}
}
