using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using NexusModsNET.Exceptions;

namespace NexusModsNET.Internals.Handlers
{
	internal class ApiLimitsHandler : MessageProcessingHandler
	{
		#region Fields
		private readonly Action<HttpResponseMessage> _responseCallback;
		private readonly IRateLimitsManagement _apiLimitsManagement;
		#endregion

		#region Constructors
		/// <summary>
		/// A <see cref="MessageProcessingHandler"/> to handle the get the API Limits from each response
		/// </summary>
		/// <param name="responseCallback">A <see cref="Action{T}"/> delegate to process a response message and get the API Limits from the Headers</param>
		/// <param name="rateLimitsManagement">A class where the custom defined limits will be read before each call request is sent</param>
		internal ApiLimitsHandler(Action<HttpResponseMessage> responseCallback, IRateLimitsManagement rateLimitsManagement)
		{
			_responseCallback = responseCallback;
			_apiLimitsManagement = rateLimitsManagement;
		}
		/// <summary>
		/// A <see cref="MessageProcessingHandler"/> to handle the get the API Limits from each response
		/// </summary>
		/// <param name="handler">The inner handler which is responsible for processing the HTTP response messages</param>
		/// <param name="responseCallback">A <see cref="Action{T}"/> delegate to process a response message and get the API Limits from the Headers</param>
		/// <param name="rateLimitsManagement">A class where the custom defined limits will be read before each call request is sent</param>
		internal ApiLimitsHandler(HttpMessageHandler handler, Action<HttpResponseMessage> responseCallback, IRateLimitsManagement rateLimitsManagement) : base(handler)
		{
			_responseCallback = responseCallback;
			_apiLimitsManagement = rateLimitsManagement;
		}
		#endregion

		#region Methods
		protected override HttpRequestMessage ProcessRequest(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (_apiLimitsManagement.ThrowOnCustomLimitsExceeded)
			{
				if (_apiLimitsManagement.CustomDailyLimitExceeded() && _apiLimitsManagement.CustomHourlyLimitExceeded())
				{
					throw new LimitsExceededException((HttpStatusCode)429, LimitType.Custom);
				}
				else
				{
					return request;
				}
			}
			else
			{
				return request;
			}
		}
		protected override HttpResponseMessage ProcessResponse(HttpResponseMessage response, CancellationToken cancellationToken)
		{
			_responseCallback(response);
			return response;
		}
		#endregion
	}
}
