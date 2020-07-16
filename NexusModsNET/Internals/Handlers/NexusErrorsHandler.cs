using System.Net;
using System.Net.Http;
using System.Threading;
using NexusModsNET.Exceptions;

namespace NexusModsNET.Internals.Handlers
{
	internal class NexusErrorsHandler : MessageProcessingHandler
	{
		public NexusErrorsHandler() { }

		public NexusErrorsHandler(HttpMessageHandler innerHandler) : base(innerHandler) { }

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
				switch (response.StatusCode)
				{
					case HttpStatusCode.BadRequest:
						throw new BadRequestException(response.ReasonPhrase);
					case HttpStatusCode.Forbidden:
						throw new ForbiddenException(response.ReasonPhrase);
					case HttpStatusCode.Gone:
						throw new GoneException(response.ReasonPhrase);
					case HttpStatusCode.NotFound:
						throw new NotFoundException(response.ReasonPhrase);
					case HttpStatusCode.Unauthorized:
						throw new UnauthorizedException(response.ReasonPhrase);
					default:
						throw new NexusAPIException(response.ReasonPhrase);
				}
			}
		}
	}
}
