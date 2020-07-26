using System;

namespace NexusModsNET
{
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
		public static IInquirerFactory New(INexusModsClient client)
		{
			if (client == null) { throw new ArgumentNullException(nameof(client)); }
			return new InquirerFactory(client);
		}
		/// <summary>
		/// Initializes a new <see cref="InquirerFactory"/> instance for creating Inquirer
		/// </summary>
		/// <param name="apiKey">A key specific to NexusMods.com account, which must be provided to allow usage of the API</param>
		/// <returns>A new <see cref="InquirerFactory"/> instance</returns>
		public static IInquirerFactory New(string apiKey)
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
		public static IInquirerFactory New(string apiKey, string productName, string productVersion)
		{
			return new InquirerFactory(NexusModsClient.Create(apiKey, productName, productVersion));
		}
	}
}
