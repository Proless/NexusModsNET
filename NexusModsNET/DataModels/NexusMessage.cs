﻿using Newtonsoft.Json;

namespace NexusModsNET.DataModels
{
	public class NexusMessage
	{
		[JsonProperty("message")]
		public string Message { get; set; }
		[JsonProperty("status")]
		public string Status { get; set; }
	}
}
