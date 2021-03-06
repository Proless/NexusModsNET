﻿using System;
using System.Net;

namespace NexusModsNET.Exceptions
{
	/// <summary>
	/// <inheritdoc/>
	/// </summary>
	[Serializable]
	public class ForbiddenException : NexusAPIException
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public ForbiddenException(HttpStatusCode statusCode) : base(statusCode) { }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public ForbiddenException(string message, HttpStatusCode statusCode) : base(message, statusCode) { }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public ForbiddenException(string message, HttpStatusCode statusCode, Exception inner) : base(message, statusCode, inner) { }
	}
}
