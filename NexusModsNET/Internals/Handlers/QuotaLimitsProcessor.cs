using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using NexusModsNET.Exceptions;

namespace NexusModsNET.Internals.Handlers
{
	internal class QuotaLimitsHandler : MessageProcessingHandler
	{
		#region Fields
		private readonly Action<HttpResponseMessage> _responseCallback;
		private readonly QuotaManagement _quotaManagement;
		#endregion

		#region Constructors
		/// <summary>
		/// A <see cref="MessageProcessingHandler"/> to handle the get the API Limits from each response
		/// </summary>
		/// <param name="responseCallback">A <see cref="Action{T}"/> delegate to process a response message and get the API Limits from the Headers</param>
		/// <param name="quotaManagement">A class where a custom defined limits will be checked before each call request is sent</param>
		internal QuotaLimitsHandler(Action<HttpResponseMessage> responseCallback, QuotaManagement quotaManagement) : base()
		{
			_responseCallback = responseCallback;
			_quotaManagement = quotaManagement;
		}
		/// <summary>
		/// A <see cref="MessageProcessingHandler"/> to handle the get the API Limits from each response
		/// </summary>
		/// <param name="handler">The inner handler which is responsible for processing the HTTP response messages</param>
		/// <param name="responseCallback">A <see cref="Action{T}"/> delegate to process a response message and get the API Limits from the Headers</param>
		/// <param name="quotaManagement">A class where a custom defined limits will be checked before each call request is sent</param>
		internal QuotaLimitsHandler(HttpMessageHandler handler, Action<HttpResponseMessage> responseCallback, QuotaManagement quotaManagement) : base(handler)
		{
			_responseCallback = responseCallback;
			_quotaManagement = quotaManagement;
		}

		#endregion

		#region Methods
		protected override HttpRequestMessage ProcessRequest(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (_quotaManagement.LimitsExceeded())
			{
				throw new QuotaLimitsExceededException((HttpStatusCode)429, LimitType.Custom);
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
