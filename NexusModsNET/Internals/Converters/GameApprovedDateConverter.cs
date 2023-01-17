using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NexusModsNET.Internals.Converters
{
	internal class GameApprovedDateConverter : UnixDateTimeConverter
	{
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.Value is long date)
			{
				if (date < 2)
				{
					return null;
				}
			}
			return base.ReadJson(reader, objectType, existingValue, serializer);
		}
	}
}
