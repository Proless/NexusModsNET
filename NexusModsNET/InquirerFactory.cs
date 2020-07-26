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
}
