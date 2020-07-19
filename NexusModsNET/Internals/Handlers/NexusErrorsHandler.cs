using System.Net;
using System.Net.Http;
using System.Threading;
using NexusModsNET.DataModels;
using NexusModsNET.Exceptions;

namespace NexusModsNET.Internals.Handlers
{
	internal class NexusErrorsHandler : MessageProcessingHandler
	{
		internal NexusErrorsHandler() { }

		internal NexusErrorsHandler(HttpMessageHandler innerHandler) : base(innerHandler) { }

		protected override HttpRequestMessage ProcessRequest(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			return request;
		}

		protected override HttpResponseMessage ProcessResponse(HttpResponseMessage response, CancellationToken cancellationToken)
		{
			if (response.IsSuccessStatusCode)
			{
				return response;
			}
			else
			{
				var responseMessage = response.Content.DeserializeContent<NexusMessage>().Result;
				switch (response.StatusCode)
				{
					case HttpStatusCode.Forbidden:
						throw new ForbiddenException(responseMessage.Message, response.StatusCode);
					case HttpStatusCode.Unauthorized:
						throw new UnauthorizedException(responseMessage.Message, response.StatusCode);
					case (HttpStatusCode)429:
						throw new QuotaLimitsExceededException(responseMessage.Message, response.StatusCode);
					default:
						throw new NexusAPIException(responseMessage.Message, response.StatusCode);
				}
			}
		}
	}
}
