using System;
using NexusModsNET.Inquirers;

namespace NexusModsNET
{
	/// <summary>
	/// A factory for creating Inquirers instances
	/// </summary>
	internal class InquirerFactory : IInquirerFactory
	{
		private readonly INexusModsClient _client;

		internal InquirerFactory(INexusModsClient client)
		{
			_client = client;
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		/// <param name="withNewClient"><inheritdoc/></param>
		/// <returns><inheritdoc/></returns>
		public InfosInquirer CreateInfosInquirer(bool withNewClient = false)
		{
			if (withNewClient)
			{
				return new InfosInquirer(CreateNewClient());
			}
			return new InfosInquirer(_client);

		}
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		/// <param name="withNewClient"><inheritdoc/></param>
		/// <returns><inheritdoc/></returns>
		public ColourSchemesInquirer CreateColourSchemesInquirer(bool withNewClient = false)
		{
			if (withNewClient)
			{
				return new ColourSchemesInquirer(CreateNewClient());
			}
			return new ColourSchemesInquirer(_client);
		}
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		/// <param name="withNewClient"><inheritdoc/></param>
		/// <returns><inheritdoc/></returns>
		public CustomInquirer CreateCustomInquirer(bool withNewClient = false)
		{
			if (withNewClient)
			{
				return new CustomInquirer(CreateNewClient());
			}
			return new CustomInquirer(_client);
		}
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		/// <param name="withNewClient"><inheritdoc/></param>
		/// <returns><inheritdoc/></returns>
		public GamesInquirer CreateGamesInquirer(bool withNewClient = false)
		{
			if (withNewClient)
			{
				return new GamesInquirer(CreateNewClient());
			}
			return new GamesInquirer(_client);
		}
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		/// <param name="withNewClient"><inheritdoc/></param>
		/// <returns><inheritdoc/></returns>
		public ModFilesInquirer CreateModFilesInquirer(bool withNewClient = false)
		{
			if (withNewClient)
			{
				return new ModFilesInquirer(CreateNewClient());
			}
			return new ModFilesInquirer(_client);
		}
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		/// <param name="withNewClient"><inheritdoc/></param>
		/// <returns><inheritdoc/></returns>
		public ModsInquirer CreateModsInquirer(bool withNewClient = false)
		{
			if (withNewClient)
			{
				return new ModsInquirer(CreateNewClient());
			}
			return new ModsInquirer(_client);
		}
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		/// <param name="withNewClient"><inheritdoc/></param>
		/// <returns><inheritdoc/></returns>
		public UserInquirer CreateUserInquirer(bool withNewClient = false)
		{
			if (withNewClient)
			{
				return new UserInquirer(CreateNewClient());
			}
			return new UserInquirer(_client);
		}

		private INexusModsClient CreateNewClient()
		{
			return NexusModsClient.Create(_client.APIKey, _client.ProductName, _client.ProductVersion);
		}
	}

	/// <summary>
	/// A factory for Initializing and creating Inquirers.
	/// </summary>
	public static class NexusModsFactory
	{
		/// <summary>
		/// Initializes a new <see cref="InquirerFactory"/> instance for creating Inquirer
		/// </summary>
		/// <param name="client">The <see cref="NexusModsClient"/> instance to use for initializing the Inquirer factory</param>
		/// <returns>A new <see cref="InquirerFactory"/> instance</returns>
		public static IInquirerFactory InitializeNew(INexusModsClient client)
		{
			if (client == null) { throw new ArgumentNullException(nameof(client)); }
			return new InquirerFactory(client);
		}
		/// <summary>
		/// Initializes a new <see cref="InquirerFactory"/> instance for creating Inquirer
		/// </summary>
		/// <param name="apiKey">A key specific to NexusMods.com account, which must be provided to allow usage of the API</param>
		/// <returns>A new <see cref="InquirerFactory"/> instance</returns>
		public static IInquirerFactory InitializeNew(string apiKey)
		{
			return new InquirerFactory(NexusModsClient.Create(apiKey));
		}
		/// <summary>
		/// Initializes a new <see cref="InquirerFactory"/> instance for creating Inquirer
		/// </summary>
		/// <param name="apiKey">A key specific to NexusMods.com account, which must be provided to allow usage of the API</param>
		/// <param name="productName">A product name to send with each request, this is used to construct a UserAgent string</param>
		/// <param name="productVersion">A product version to send with each request, this is used to construct a UserAgent string</param>
		/// <returns>A new <see cref="InquirerFactory"/> instance</returns>
		public static IInquirerFactory InitializeNew(string apiKey, string productName, string productVersion)
		{
			return new InquirerFactory(NexusModsClient.Create(apiKey, productName, productVersion));
		}
	}
}
